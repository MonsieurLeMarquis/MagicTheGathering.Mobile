using System.Collections.Generic;
using DataBase.Objects;
using DataBase.Bestiaire.Constants;

namespace DataBase.Bestiaire.Tables
{
	public class TableCards : BaseTable
    {
        public string Name { get { return ConstantsTables.TABLE_CARDS; } }
        public Dictionary<int, Column> Columns { get { return ConstantsColumns.COLUMNS_CARDS; } }
    }
}

