using System.Collections.Generic;
using DataBase.Objects;
using DataBase.Enumerations;
using System.Linq;

namespace DataBase.Managers
{
	public class ManagerScripts
	{
		
		public static string GenerateCreateTable(BaseTable table)
		{
			var columns = new List<string> ();
            table.Columns.Values.ToList().ForEach(value => columns.Add(GenerateScriptColumn(value)));
			return string.Format ("CREATE TABLE {0} ({1})", table.Name, string.Join(", ", columns));
		}

        public static string GenerateBulkInsert(BaseTable table)
        {
            var columns = table.Columns
                .Select(column => column.Value)
                .Where(column => !column.PrimaryKey)
                .Select(column => column.Name)
                .ToList();
            return string.Format("INSERT INTO {0} ({1}) VALUES ({2});", 
                table.Name,
                string.Join(",", columns),
                string.Join(",", columns.Select(column => "?")));
        }

		protected static string GenerateScriptColumn(Column column)
		{
			var name = column.Name;
			var type = "";
			var primaryKey = column.PrimaryKey ? "PRIMARY KEY AUTOINCREMENT" : "";
			switch (column.Type) {
			case Enums.DATABASE_TYPE.INTEGER:
				type = "INTEGER";
				break;
			case Enums.DATABASE_TYPE.DOUBLE:
				type = "REAL";
				break;
			case Enums.DATABASE_TYPE.TEXT:
				type = "TEXT";
				break;
			}
			return string.Format("{0} {1} {2}", name, type, primaryKey);
		}

	}
}

