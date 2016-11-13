namespace MTG.DataExtractor.Objects.Managers
{
    public class ManageFichierExtension
    {

        public static string Libelle(FichierExtension fichierExtension)
        {
            string Resultat = string.Empty;
            switch (fichierExtension.TypeExtension)
            {
                case FichierExtension.TYPE_EXTENSION.GIF:
                    Resultat = "GIF";
                    break;
                case FichierExtension.TYPE_EXTENSION.JPG:
                    Resultat = "JPG";
                    break;
                case FichierExtension.TYPE_EXTENSION.PNG:
                    Resultat = "PNG";
                    break;
                case FichierExtension.TYPE_EXTENSION.SVG:
                    Resultat = "SVG";
                    break;
                case FichierExtension.TYPE_EXTENSION.SQL:
                    Resultat = "SQL";
                    break;
                case FichierExtension.TYPE_EXTENSION.CSV:
                    Resultat = "CSV";
                    break;
                case FichierExtension.TYPE_EXTENSION.TXT:
                    Resultat = "TXT";
                    break;
            }
            return Resultat;
        }

        public string ID(FichierExtension fichierExtension)
        {
            string Resultat = string.Empty;
            switch (fichierExtension.TypeExtension)
            {
                case FichierExtension.TYPE_EXTENSION.GIF:
                    Resultat = "gif";
                    break;
                case FichierExtension.TYPE_EXTENSION.JPG:
                    Resultat = "jpg";
                    break;
                case FichierExtension.TYPE_EXTENSION.PNG:
                    Resultat = "png";
                    break;
                case FichierExtension.TYPE_EXTENSION.SVG:
                    Resultat = "svg";
                    break;
                case FichierExtension.TYPE_EXTENSION.SQL:
                    Resultat = "sql";
                    break;
                case FichierExtension.TYPE_EXTENSION.CSV:
                    Resultat = "csv";
                    break;
                case FichierExtension.TYPE_EXTENSION.TXT:
                    Resultat = "txt";
                    break;
            }
            return Resultat;
        }

    }
}
