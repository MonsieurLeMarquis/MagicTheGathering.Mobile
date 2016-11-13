using Android.Content;
using System.Collections.Generic;
using System.Linq;
using Common.Android.DataBase.Managers;
using DataBase.Bestiaire.Managers;
using DataBase.Bestiaire.Tables;
using Objects.Bestiaire.DataBase.Cards;

namespace Common.Android.DataBase.Objects.Bestiaire
{
    public class EditionBDD : BaseObjectBDD
    {

		public EditionBDD(Context context)
        {
            ManagerDataBase = new ManagerDataBaseBestiaire(context);
            ManagerObjectConverter = new ManagerObjectConverterEdition();
            Table = new TableEditions();
        }

        public override object CreateObject()
        {
            return new Edition();
        }

        public override List<object> CreateListObjects()
        {
            return new List<Edition>().Select(item => (object)item).ToList();
        }

        public List<Edition> GetEditions()
        {
			Open ();
			var editions = SelectAll().Select(edition => (Edition)edition).ToList();
			Close ();
			return editions;
        }

		public void BulkInsertEditions(List<Edition> editions)
		{
			Open ();
			BulkInsert(editions.Select(item => (object)item).ToList());
			Close ();
		}
        
    }
}