using System;

namespace Business.Ressources.Constants
{
	public class ConstantsFiles
	{

		public static string FileJsonBestiaireListDrafts { get { return string.Format (@"{0}/drafts.json", ConstantsFolders.FolderJsonBestiaire); } }  
		public static string FileJsonBestiaireListEditions { get { return string.Format (@"{0}/editions.json", ConstantsFolders.FolderJsonBestiaire); } }  
		public static string FileJsonBestiaireEdition(string edition) { return string.Format(@"{0}/{1}.json" , ConstantsFolders.FolderJsonBestiaire, edition); }  

	}
}

