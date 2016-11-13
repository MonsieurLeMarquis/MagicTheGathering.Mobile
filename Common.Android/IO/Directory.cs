using System;
using System.IO;

namespace Common.Android.IO
{
	public class Directory
	{

		// Subsitution e l'instruction File.separator qui ne marche pas sous Android
		public static char SEPARATOR = '/';

		/*

		// Extraction du repertoire e partir d'un chemin complet de fichier
		public static String GetDirectoryFromFilePath(string FilePath){
			return FilePath.Substring(0, FilePath.LastIndexOf(SEPARATOR.ToString()));
		}

		// Creation d'un repertoire
		public static void CreateDirectory(String DirectoryPath) {
			if (!DirectoryExists(DirectoryPath)) {
				File Directory = new File(DirectoryPath);
				Directory.mkdirs();
			}
		}

		// Test l'existence d'un repertoire
		public static bool DirectoryExists(String DirectoryPath) {
			File Directory = new File(DirectoryPath);
			return Directory.exists();
		}

		// Supprime un repertoire et son contenu
		public static void DeleteDirectory(String DirectoryPath) {

			// Test d'existence du repertoire
			if(DirectoryExists(DirectoryPath)){

				// Recuperation des fichiers du repertoire
				File Directory = new File(DirectoryPath);
				File[] Files = Directory.listFiles();

				// Parcours des fichiers du repertoire
				for(int i=0; i<Files.Length; i++) {

					File File = Files[i];
					if (File.IsFile()) {
						// Suppression du fichier
						File.Delete();
					} else if (File.IsDirectory()) {
						// Suppression du repertoire
						DirectorySystem.DeleteDirectory(File.GetAbsolutePath());
					}

				}

			}

		}

		// Compte les fichiers
		public static int CountFilesInDirectory(String DirectoryPath) {

			// Initialisation
			int iCount = 0;

			// Test d'existence du repertoire
			if(DirectoryExists(DirectoryPath)){

				// Recuperation des fichiers du repertoire
				File Directory = new File(DirectoryPath);
				iCount = Directory.listFiles().length;

			}

			// Resultat
			return iCount;

		}

		// Compte les fichiers
		public static int CountFilesInAssetsDirectory(Context Context, String DirectoryPath) {
			return GetListeFilesInAssetsDirectory(Context, DirectoryPath).size();
		}

		// Liste les fichiers d'un repertoire ASSETS
		public static ArrayList<String> GetListeFilesInAssetsDirectory(Context Context, String DirectoryPath) {

			// Initialisation
			String[] FichiersTemp = new String[0];
			ArrayList<String> Fichiers = new ArrayList<String>();

			// Liste des fichiers
			try {
				AssetManager assetManager = Context.getAssets();
				FichiersTemp = assetManager.list(DirectoryPath);
				if (FichiersTemp != null)
				{
					for (int Index = 0; Index < FichiersTemp.length; Index++)
					{
						Fichiers.add(FichiersTemp[Index]);
					}
				}
			} catch (IOException e) {

			}

			// Resultat
			return Fichiers;

		}

		// Transfert des fichiers du repertoire ASSETS vers le repertoire DATA
		public static void CopyFolderFromAssetsToData(Context Context, String DirectoryPathAssets, String DirectoryPathData)
		{

			// Initialisation
			AssetManager assetManager = Context.getAssets();

			// Liste des fichiers
			ArrayList<String> Files = GetListeFilesInAssetsDirectory(Context, DirectoryPathAssets);

			// Creation du repertoire DATA si necessaire
			if (!DirectoryExists(DirectoryPathData))
			{
				CreateDirectory(DirectoryPathData);
			}

			// Traitement de tous les fichiers
			foreach(string File in Files)
			{
				// Fichiers
				String FileAssets = DirectoryPathAssets + "/" + File;
				String FileData = DirectoryPathData + File;
				if (!FileSystem.FileExists(FileData))
				{
					InputStream in = null;
					OutputStream out = null;
					try {
						in = assetManager.open(FileAssets);
						File outFile = new File(FileData);
						out = new FileOutputStream(outFile);
						FileSystem.CopyFile(in, out);
						in.close();
						in = null;
						out.flush();
						out.close();
						out = null;
					} catch(IOException e) {
					}  
				}
			}

		}

		*/

	}
}

