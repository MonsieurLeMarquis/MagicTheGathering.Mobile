namespace MTG.DataExtractor.Ressources.Interface
{
    public class Interface_Fichier_Extension
	{

		public enum TYPE_FICHIER_EXTENSION
		{
			PNG,
			GIF,
            JPG
		}

        public TYPE_FICHIER_EXTENSION TypeFichierExtension;

		public override string ToString()
		{
            switch (TypeFichierExtension)
			{
                case TYPE_FICHIER_EXTENSION.PNG:
					return "png";
                case TYPE_FICHIER_EXTENSION.GIF:
					return "gif";
                case TYPE_FICHIER_EXTENSION.JPG:
					return "jpg";
				default:
					return "???";
			}
		}

        public Interface_Fichier_Extension(TYPE_FICHIER_EXTENSION typeFichierExtension)
		{
            TypeFichierExtension = typeFichierExtension;
		}

	}
}
