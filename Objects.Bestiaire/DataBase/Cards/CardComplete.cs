using Objects.MtgJson;

namespace Objects.Bestiaire.DataBase.Cards
{
	public class CardComplete
	{

		public Card Card { get; set; }
		public Edition Edition { get; set; }
		public GathererCard GathererCard { get; set; }

		public CardComplete()
        {
            Card = new Card();
            Edition = new Edition();
			GathererCard = new GathererCard ();
        }

	}
}

