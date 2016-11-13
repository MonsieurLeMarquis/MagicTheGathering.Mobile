namespace MTG.DataExtractor.Ressources.Interface
{
    public class Interface_Image_Taille
	{

		public enum TYPE_IMAGE_TAILLE
		{
			TOUTES_LES_TAILLES,
			PETITE,
			MOYENNE,
			GRANDE,
			SVG
		}

		public TYPE_IMAGE_TAILLE TypeImageTaille;

		public override string ToString()
		{
			switch (TypeImageTaille)
			{
				case TYPE_IMAGE_TAILLE.TOUTES_LES_TAILLES:
					return "<Toutes les tailles>";
				case TYPE_IMAGE_TAILLE.PETITE:
					return "Petite";
				case TYPE_IMAGE_TAILLE.MOYENNE:
					return "Moyenne";
				case TYPE_IMAGE_TAILLE.GRANDE:
					return "Grande";
				case TYPE_IMAGE_TAILLE.SVG:
					return "SVG";
				default:
					return "???";
			}
		}

		public Interface_Image_Taille(TYPE_IMAGE_TAILLE typeImageTaille)
		{
			TypeImageTaille = typeImageTaille;
		}

	}
}
