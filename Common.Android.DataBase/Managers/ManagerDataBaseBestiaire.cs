using Android.Database.Sqlite;
using Android.Content;
using DataBase.Bestiaire.Tables;
using DataBase.Managers;
using Bestiaire = DataBase.Bestiaire.Constants;
using System.Collections.Generic;
using DataBase.Objects;

namespace Common.Android.DataBase.Managers
{
	public class ManagerDataBaseBestiaire : BaseManagerDataBase
	{

        public override List<BaseTable> Tables {
            get {
                return new List<BaseTable> {
                    new TableDrafts(),
                    new TableEditions(),
                    new TableCards()};
            }
        }

        public ManagerDataBaseBestiaire(Context context)
			: base(context, Bestiaire.ConstantsDataBase.DATABASE_NAME, Bestiaire.ConstantsDataBase.DATABASE_VERSION)
        {
		}

	}
}

