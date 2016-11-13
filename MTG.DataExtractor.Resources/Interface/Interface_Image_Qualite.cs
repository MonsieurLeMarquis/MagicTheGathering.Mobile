namespace MTG.DataExtractor.Ressources.Interface
{
    public class Interface_Image_Qualite
	{

		public enum TYPE_IMAGE_QUALITE
		{
			COMPRESSEE,
			HAUTE_QUALITE
		}

		public TYPE_IMAGE_QUALITE TypeImageQualite;

		public override string ToString()
		{
			switch (TypeImageQualite)
			{
				case TYPE_IMAGE_QUALITE.COMPRESSEE:
					return "Compressé";
				case TYPE_IMAGE_QUALITE.HAUTE_QUALITE:
					return "Haute qualité";
				default:
					return "???";
			}
		}

		public Interface_Image_Qualite(TYPE_IMAGE_QUALITE typeImageQualite)
		{
			TypeImageQualite = typeImageQualite;
		}



	}
}
