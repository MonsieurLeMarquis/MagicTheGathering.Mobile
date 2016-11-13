using Android.Content;
using Common.Android.DataBase.Managers;
using DataBase.Bestiaire.Managers;
using DataBase.Bestiaire.Tables;

namespace Common.Android.DataBase.Objects.Bestiaire
{
    public class CardBDD : BaseObjectBDD
    {

		public CardBDD(Context context)
        {
            ManagerDataBase = new ManagerDataBaseBestiaire(context);
            ManagerObjectConverter = new ManagerObjectConverterCard();
            Table = new TableCards();
        }

    }
}