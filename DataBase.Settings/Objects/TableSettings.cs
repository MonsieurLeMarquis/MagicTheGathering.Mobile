using System.Collections.Generic;
using DataBase.Objects;
using DataBase.Settings.Constants;

namespace DataBase.Settings.Objects
{
	public class TableSettings : BaseTable
    {
        public string Name { get { return ConstantsTables.TABLE_SETTINGS; } }
        public Dictionary<int, Column> Columns { get { return ConstantsColumns.COLUMNS_SETTINGS; } }
    }
}

