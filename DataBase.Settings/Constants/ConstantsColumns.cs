using DataBase.Objects;
using DB = DataBase.Settings.Enumerations;
using System.Collections.Generic;
using DataBase.Enumerations;

namespace DataBase.Settings.Constants
{
    public class ConstantsColumns
    {
        public static Dictionary<int, Column> COLUMNS_SETTINGS = 
            new Dictionary<int, Column>
            {
                { (int)DB.Enums.COLUMNS_SETTINGS.ID, new Column ("ID", Enums.DATABASE_TYPE.INTEGER, true) },
                { (int)DB.Enums.COLUMNS_SETTINGS.NAME, new Column ("NAME", Enums.DATABASE_TYPE.TEXT, false) },
                { (int)DB.Enums.COLUMNS_SETTINGS.VALUE, new Column ("VALUE", Enums.DATABASE_TYPE.TEXT, false) }
            };
    }
}