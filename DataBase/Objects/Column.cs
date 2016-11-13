using DataBase.Enumerations;

namespace DataBase.Objects
{
    public class Column
	{
		
		public string Name { get; set; }
		public Enums.DATABASE_TYPE Type { get; set; }
		public bool PrimaryKey { get; set; }

		public Column (string name, Enums.DATABASE_TYPE type, bool primaryKey)
		{
			Name = name;
			Type = type;
			PrimaryKey = primaryKey;
		}

	}
}

