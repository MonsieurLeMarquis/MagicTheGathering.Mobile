using Android.Content;
using System.Collections.Generic;
using System.Linq;
using Common.Android.DataBase.Managers;
using DataBase.Bestiaire.Managers;
using DataBase.Bestiaire.Tables;
using Objects.Bestiaire.DataBase.Cards;

namespace Common.Android.DataBase.Objects.Bestiaire
{
    public class DraftBDD : BaseObjectBDD
    {

		public DraftBDD(Context context)
        {
            ManagerDataBase = new ManagerDataBaseBestiaire(context);
            ManagerObjectConverter = new ManagerObjectConverterDraft();
            Table = new TableDrafts();
		}

		public override object CreateObject()
		{
			return new Draft();
		}

		public override List<object> CreateListObjects()
		{
			return new List<Draft>().Select(item => (object)item).ToList();
		}

		public List<Draft> GetDrafts()
		{
			Open ();
			var drafts = SelectAll().Select(draft => (Draft)draft).ToList();
			Close ();
			return drafts;
		}

		public void BulkInsertDrafts(List<Draft> drafts)
		{
			Open ();
			BulkInsert(drafts.Select(item => (object)item).ToList());
			Close ();
		}

    }
}