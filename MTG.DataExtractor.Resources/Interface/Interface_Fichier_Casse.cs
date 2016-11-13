namespace MTG.DataExtractor.Ressources.Interface
{
	public class Interface_Fichier_Casse
	{

		public enum TYPE_FICHIER_CASSE
		{
			MINUSCULE,
			MAJUSCULE
		}

		public TYPE_FICHIER_CASSE TypeFichierCasse;

		public override string ToString()
		{
			switch(TypeFichierCasse)
			{
				case TYPE_FICHIER_CASSE.MINUSCULE:
					return "Minuscule";
				case TYPE_FICHIER_CASSE.MAJUSCULE:
					return "Majuscule";
				default:
					return "???";
			}
		}

		public Interface_Fichier_Casse (TYPE_FICHIER_CASSE typeFichierCasse)
		{
			TypeFichierCasse = typeFichierCasse;
		}

	}
}
