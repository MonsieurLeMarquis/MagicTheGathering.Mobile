namespace MTG.DataExtractor.Ressources.Interface
{
	public class Interface_Source_Donnees
	{

		public enum TYPE_SOURCE_DONNEES
		{
			MTGIMAGE,
			GATHERER
		}

		public TYPE_SOURCE_DONNEES TypeSourcesDonnees;

		public override string ToString()
		{
			switch (TypeSourcesDonnees)
			{
				case TYPE_SOURCE_DONNEES.MTGIMAGE:
					return "http://mtgimage.com/";
				case TYPE_SOURCE_DONNEES.GATHERER:
					return "http://gatherer.wizards.com/";
				default:
					return "???";
			}
		}

		public Interface_Source_Donnees(TYPE_SOURCE_DONNEES typeSourcesDonnees)
		{
			TypeSourcesDonnees = typeSourcesDonnees;
		}

	}
}
