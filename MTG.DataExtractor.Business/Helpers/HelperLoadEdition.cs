using System.IO;

namespace MTG.DataExtractor.Business.Helpers
{
    public class HelperLoadEdition
    {

		protected static string SUFFIXE_BESTIAIRE = "bestiaire_"; 
		protected static string SUFFIXE_MTGJSON = "mtgjson_"; 

		public static string FileNameMtgJsonEditions { get { return SUFFIXE_MTGJSON + "editions.json"; } }
		public static string FileNameBestiaireEditions { get { return SUFFIXE_BESTIAIRE + "editions.json"; } }
		public static string FileNameBestiaireDrafts { get { return SUFFIXE_BESTIAIRE + "drafts.json"; } }

        public static string FileNameBestiaireEdition(string editionID)
        {
			return SUFFIXE_BESTIAIRE + editionID + ".json";
        }

        public static string FileNameMtgJsonEdition(string editionID)
        {
			return SUFFIXE_MTGJSON + editionID + ".json";
        }

        public static string PathDataBestiaire(string path)
        {
            return Path.Combine(path, @"assets\data\bestiaire");
        }

        public static string PathDataGatherer(string path)
        {
            return Path.Combine(path, @"assets\data\gatherer");
        }

        public static string PathIcons(string path)
        {
            return Path.Combine(path, @"assets\icons");
        }

        public static string PathIconsSmall(string path)
        {
            return Path.Combine(path, @"assets\icons\small");
        }

        public static string PathIconsMedium(string path)
        {
            return Path.Combine(path, @"assets\icons\medium");
        }

        public static string PathIconsLarge(string path)
        {
            return Path.Combine(path, @"assets\icons\large");
        }

        public static string PathImages(string path, string editionID)
        {
            return Path.Combine(path, @"assets\images\" + editionID);
        }
        
    }
}
