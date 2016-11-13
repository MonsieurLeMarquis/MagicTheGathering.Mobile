namespace MTG.DataExtractor.Ressources.Interface
{
    public class Interface_Image_Nom
	{

		public enum TYPE_IMAGE_NOM
		{
			ID_MULTIVERSE,
			LIBELLE_CARTE
		}

		public TYPE_IMAGE_NOM TypeImageNom;

		public override string ToString()
		{
			switch (TypeImageNom)
			{
				case TYPE_IMAGE_NOM.ID_MULTIVERSE:
					return "ID mutiverse";
				case TYPE_IMAGE_NOM.LIBELLE_CARTE:
					return "Libellé carte";
				default:
					return "???";
			}
		}

		public Interface_Image_Nom(TYPE_IMAGE_NOM typeImageNom)
		{
			TypeImageNom = typeImageNom;
		}


	}
}
