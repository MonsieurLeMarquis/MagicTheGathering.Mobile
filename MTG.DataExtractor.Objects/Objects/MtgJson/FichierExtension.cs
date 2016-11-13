namespace MTG.DataExtractor.Objects
{
    public class FichierExtension
	{

		public enum TYPE_EXTENSION
		{
			GIF,
			JPG,
			PNG,
			SVG,
			SQL,
			CSV,
			TXT
		}

		public TYPE_EXTENSION TypeExtension;

		public FichierExtension (TYPE_EXTENSION typeExtension)
		{
			TypeExtension = typeExtension;
		}

	}
}
