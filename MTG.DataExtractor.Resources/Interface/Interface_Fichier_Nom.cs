namespace MTG.DataExtractor.Ressources.Interface
{
    public class Interface_Fichier_Nom
	{

		public enum TYPE_FICHIER_NOM
		{
			LIBELLE,
			ID_BESTIAIRE,
			ID_MTGJSON,
			ID_GATHERER
		}

		public TYPE_FICHIER_NOM TypeFichierNom;

		public override string ToString()
		{
			switch (TypeFichierNom)
			{
				case TYPE_FICHIER_NOM.LIBELLE:
					return "Libellé édition";
				case TYPE_FICHIER_NOM.ID_BESTIAIRE:
					return "ID édition Bestiaire";
				case TYPE_FICHIER_NOM.ID_MTGJSON:
					return "ID édition MtgJson";
				case TYPE_FICHIER_NOM.ID_GATHERER:
					return "ID édition Gatherer";
				default:
					return "???";
			}
		}

		public Interface_Fichier_Nom(TYPE_FICHIER_NOM typeFichierNom)
		{
			TypeFichierNom = typeFichierNom;
		}

	}
}
