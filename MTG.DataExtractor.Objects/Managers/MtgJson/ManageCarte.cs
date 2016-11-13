namespace MTG.DataExtractor.Objects.Managers
{
    public class ManageCarte
    {

        public static string NomBestiaire(Carte carte)
        {
            return ConversionNomBestiaire(carte.name);
        }

        public static string NomBestiaire(Carte_X carte)
        {
            return ConversionNomBestiaire(carte.name);
        }

        protected static string ConversionNomBestiaire(string name)
        {
            return name.Replace(" ", "_").Replace("'", "").Replace("-", "_").Replace(",", "").Replace(":", "").Replace("(", "").Replace(")", "").Replace("!", "");
        }

    }
}
