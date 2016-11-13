using System.Collections.Generic;
using DataBase.Objects;
using DataBase.Bestiaire.Constants;

namespace DataBase.Bestiaire.Tables
{
	public class TableDrafts : BaseTable
    {
        public string Name { get { return ConstantsTables.TABLE_DRAFTS; } }
        public Dictionary<int, Column> Columns { get { return ConstantsColumns.COLUMNS_DRAFTS; } }
    }
}

