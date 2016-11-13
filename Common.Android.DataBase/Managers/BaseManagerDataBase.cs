using Android.Content;
using Android.Database.Sqlite;
using DataBase.Bestiaire.Tables;
using DataBase.Managers;
using DataBase.Objects;
using System.Collections.Generic;

namespace Common.Android.DataBase.Managers
{

    public abstract class BaseManagerDataBase : SQLiteOpenHelper
    {

        public virtual List<BaseTable> Tables { get { return new List<BaseTable>(); } }

        public BaseManagerDataBase(Context context)
            : base(context, "DATABASE_NAME", null, 1)
        {
        }

        public BaseManagerDataBase(Context context, string dataBaseName, int dataBaseVersion)
            : base(context, dataBaseName, null, dataBaseVersion)
        {
        }

        public override void OnCreate(SQLiteDatabase db)
        {
			Tables.ForEach(table => db.ExecSQL(ManagerScripts.GenerateCreateTable(table)));
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
        }

    }
}