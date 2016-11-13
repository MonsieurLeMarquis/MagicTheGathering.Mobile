namespace MTG.DataExtractor.Ressources.Interface
{
    public class Interface_Fichier_Format
	{

		public enum TYPE_FICHIER_FORMAT
		{
			JSON,
			EXCEL,
			SQL
		}

		public TYPE_FICHIER_FORMAT TypeFichierCartes;

		public override string ToString()
		{
			switch(TypeFichierCartes)
			{
				case TYPE_FICHIER_FORMAT.JSON:
					return "Json";
				case TYPE_FICHIER_FORMAT.EXCEL:
					return "Excel (.csv)";
				case TYPE_FICHIER_FORMAT.SQL:
					return "Sql (pas encore implémenté)";
				default:
					return "???";
			}
		}

		public Interface_Fichier_Format(TYPE_FICHIER_FORMAT typeFichierCartes)
		{
			TypeFichierCartes = typeFichierCartes;
		}

	}
}
