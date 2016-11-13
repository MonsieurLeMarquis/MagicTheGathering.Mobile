namespace MTG.DataExtractor.Ressources.Interface
{
    public class Interface_Icone_Taille
	{

		public enum TYPE_ICONE_TAILLE
		{
            TOUTES_LES_TAILLES,
            TAILLE_8_x_8,
            TAILLE_16_x_16,
            TAILLE_24_x_24,
            TAILLE_32_x_32,
            TAILLE_48_x_48,
            TAILLE_64_x_64,
            TAILLE_96_x_96,
            TAILLE_128_x_128,
            TAILLE_256_x_256,
            TAILLE_512_x_512,
            TAILLE_768_x_768,
            TAILLE_1024_x_1024,
            SVG,
            SMALL,
            MEDIUM,
            LARGE
		}

        public TYPE_ICONE_TAILLE TypeIconeTaille;

		public override string ToString()
		{
            switch (TypeIconeTaille)
			{
                case TYPE_ICONE_TAILLE.TOUTES_LES_TAILLES:
                    return "<Toutes les tailles>";
                case TYPE_ICONE_TAILLE.TAILLE_8_x_8:
                    return "8 x 8";
                case TYPE_ICONE_TAILLE.TAILLE_16_x_16:
                    return "16 x 16";
                case TYPE_ICONE_TAILLE.TAILLE_24_x_24:
                    return "24 x 24";
                case TYPE_ICONE_TAILLE.TAILLE_32_x_32:
                    return "32 x 32";
                case TYPE_ICONE_TAILLE.TAILLE_48_x_48:
                    return "48 x 48";
                case TYPE_ICONE_TAILLE.TAILLE_64_x_64:
                    return "64 x 64";
                case TYPE_ICONE_TAILLE.TAILLE_96_x_96:
                    return "96 x 96";
                case TYPE_ICONE_TAILLE.TAILLE_128_x_128:
                    return "128 x 128";
                case TYPE_ICONE_TAILLE.TAILLE_256_x_256:
                    return "256 x 256";
                case TYPE_ICONE_TAILLE.TAILLE_512_x_512:
                    return "512 x 512";
                case TYPE_ICONE_TAILLE.TAILLE_768_x_768:
                    return "768 x 768";
                case TYPE_ICONE_TAILLE.TAILLE_1024_x_1024:
                    return "1024 x 1024";
                case TYPE_ICONE_TAILLE.SVG:
                    return "SVG";
                case TYPE_ICONE_TAILLE.SMALL:
                    return "Small";
                case TYPE_ICONE_TAILLE.MEDIUM:
                    return "Medium";
                case TYPE_ICONE_TAILLE.LARGE:
                    return "Large";
				default:
					return "???";
			}
		}

        public Interface_Icone_Taille(TYPE_ICONE_TAILLE typeIconeTaille)
		{
            TypeIconeTaille = typeIconeTaille;
		}

	}
}
