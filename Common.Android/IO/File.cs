using System;
using System.Collections.Generic;
using Android.App;
using System.IO;
using Java.IO;
using Common.Android.Debug;

namespace Common.Android.IO
{
	public class File
	{

		// Lecture d'un fichier
		public static string ReadFileFromAsset(Activity activity, string filePath) {
			string file = "";
			try {
				using (var input = activity.Assets.Open(filePath))
				using (StreamReader sr = new System.IO.StreamReader(input))
				{
					file = sr.ReadToEnd();
				}
			}
			catch (Exception ex) {
				ManagerTraces.AddTrace (new Error { Exception = ex });
			}
			return file;
		}

		/*

		// Sauvegarde un fichier
		public static void WriteFile(String FilePath, String Data) {
			try {
				//outputStream = Activity.getApplicationContext().openFileOutput(FileName, Context.MODE_PRIVATE);
				if (!DirectorySystem.DirectoryExists(DirectorySystem.GetDirectoryFromFilePath(FilePath))) {
					DirectorySystem.CreateDirectory(DirectorySystem.GetDirectoryFromFilePath(FilePath));
				}
				OutputStream file = new FileOutputStream(FilePath);
				OutputStream buffer = new BufferedOutputStream(file);
				ObjectOutput output = new ObjectOutputStream(buffer);
				output.writeUTF(Data);
				output.close();
			} catch(IOException e){
				Logging.Error(Logging.GetClassMethod(Thread.currentThread().getStackTrace()), e.toString());
			}
		}

		// Sauvegarde un fichier
		public static void WriteFile(String FilePath, DataObject Object) {
			try {
				//outputStream = Activity.getApplicationContext().openFileOutput(FileName, Context.MODE_PRIVATE);
				if (!DirectorySystem.DirectoryExists(DirectorySystem.GetDirectoryFromFilePath(FilePath))) {
					DirectorySystem.CreateDirectory(DirectorySystem.GetDirectoryFromFilePath(FilePath));
				}
				OutputStream file = new FileOutputStream(FilePath);
				OutputStream buffer = new BufferedOutputStream(file);
				ObjectOutput output = new ObjectOutputStream(buffer);
				output.writeObject(Object);
				output.close();
			} catch(IOException e){
				Logging.Error(Logging.GetClassMethod(Thread.currentThread().getStackTrace()), e.toString());
			}
		}

		// Lecture d'un fichier
		public static DataObject ReadFile(String FilePath) {
			DataObject Object = null;
			try {
				if (FileExists(FilePath)) {
					File outputFile = new File(FilePath);
					InputStream file = new FileInputStream(outputFile);
					InputStream buffer = new BufferedInputStream(file);
					ObjectInput input = new ObjectInputStream (buffer);
					Object = (DataObject)input.readObject();
					file.close ( ) ;
				}
			} catch (IOException e) {
				Logging.Error(Logging.GetClassMethod(Thread.currentThread().getStackTrace()), e.toString());
			} catch (ClassNotFoundException e) {
				Logging.Error(Logging.GetClassMethod(Thread.currentThread().getStackTrace()), e.toString());
			}
			return Object;
		}

		// Lecture d'un fichier
		public static InputStreamReader ReadFileFromAsset_Stream(Activity Activity, String FilePath) {
			InputStreamReader inputStreamReader = null;
			try {
				InputStream inputStream = Activity.getAssets().open(FilePath);
				if ( inputStream != null ) {
					inputStreamReader = new InputStreamReader(inputStream);
				}
			}
			catch (FileNotFoundException e) {
				Log.e("login activity", "File not found: " + e.toString());
			} catch (IOException e) {
				Log.e("login activity", "Can not read file: " + e.toString());
			}
			return inputStreamReader;
		}

		// Transfert des fichiers du repertoire ASSETS vers le repertoire DATA
		public static void CopyFileFromAssetsToData(android.content.Context Context, String FileAssets, String FileData)
		{

			// Initialisation
			AssetManager assetManager = Context.getAssets();

			// Traitement du fichier
			if (!FileSystem.FileExists(FileData))
			{
				InputStream input = null;
				OutputStream output = null;
				try {
					input = assetManager.Open(FileAssets);
					File outFile = new File(FileData);
					output = new FileOutputStream(outFile);
					FileSystem.CopyFile(input, output);
					input.close();
					input = null;
					output.Flush();
					outout.Close();
					output = null;
				} catch(IOException e) {
				}  
			}

		}

		// Sauvegarde une image au format PNG
		public static void SavePNG(Bitmap Image, String Filepath)
		{
			OutputStream fOut = null;
			File file = new File(Filepath);
			try
			{
				fOut = new FileOutputStream(file);
				Image.compress(Bitmap.CompressFormat.PNG, 85, fOut);
				try 
				{
					fOut.flush();
					fOut.close();
				}
				catch (IOException e) 
				{   
					e.printStackTrace();  
				}
			} 
			catch (FileNotFoundException e) 
			{
				e.printStackTrace();    
			}

		}

		// Test l'existence d'un fichier
		public static boolean FileExists(String FilePath) {
			boolean bResult = false;
			if (DirectorySystem.DirectoryExists(DirectorySystem.GetDirectoryFromFilePath(FilePath))) {
				File file = new File(FilePath);
				bResult = file.exists();
			}
			return bResult;
		}    

		// Supprime un fichier
		public static void DeleteFile(String FilePath) {
			if (FileSystem.FileExists(FilePath)) {
				File File = new File(FilePath);
				File.delete();
			}
		}

		// Renomme un fichier
		public static void RenameFile(String FilePath, String NewFilePath) {
			if (FileSystem.FileExists(FilePath)) {
				File File = new File(FilePath);
				File NewFile = new File(NewFilePath);
				File.renameTo(NewFile);
			}
		}

		// Copie un fichier
		public static void CopyFile(InputStream input, OutputStream output) {
			byte[] buffer = new byte[1024];
			int read;
			while((read = input.read(buffer)) != -1){
				output.write(buffer, 0, read);
			}
		}

		// Supprime tous les fichiers d'un repertoire
		public static void DeleteAllFiles(String Directory) {

			// Test d'existence du repertoire
			if (DirectorySystem.DirectoryExists(Directory)) {

				// Recuperation des fichiers du repertoire
				File Folder = new File(Directory);
				File[] Files = Folder.listFiles();

				// Parcours des fichiers
				for (int i = 0; i < Files.length; i++) {

					File File = Files[i];
					if (File.isFile()) {
						// Suppression du fichier
						File.delete();
					} else if (File.isDirectory()) {
						// Suppression du repertoire
						DirectorySystem.DeleteDirectory(File.getAbsolutePath());
					}

				}

			}

		}

		// Renvoie tous les fichiers d'un repertoire ([PATH].[NAME])
		public static List<String> GetAllFiles(String Directory, bool CompletePath) {

			// Initialisation
			ArrayList<String> alFiles = new ArrayList<String>();

			// Test d'existence du repertoire
			if (DirectorySystem.DirectoryExists(Directory)) {

				// Recuperation des fichiers du repertoire
				File Folder = new File(Directory);
				File[] Files = Folder.listFiles();

				// Parcours des fichiers
				for (int i = 0; i < Files.length; i++) {

					File File = Files[i];
					if (File.isFile()) {

						// Cas d'un fichier
						if (CompletePath) {
							alFiles.Add(File.GetAbsolutePath());
						}
						else {
							alFiles.Add(File.GetAbsolutePath().Replace(String.Format("%s%s", Context.getApplicationDirectoryPath(), DirectorySystem.SEPARATOR), ""));
						}

					} else if (File.isDirectory()) {

						// Cas d'un repertoire : appel recursif pour lister les fichiers des sous-repertoire
						List<String> alFilesFolder = GetAllFiles(File.GetAbsolutePath(), CompletePath);
						foreach (string FileFolder in alFilesFolder) {
							alFiles.Add(FileFolder);
						}

					}

				}

			}

			return alFiles;

		}

		// Sauvegarde une image depuis une URL
		public static boolean SaveJpegFromURL(String UrlImage, String PathImage) {
			boolean bLoadFail = false;
			try {
				URL url = new URL(UrlImage);
				InputStream input = url.openStream();
				try {
					//The sdcard directory e.g. '/sdcard' can be used directly, or 
					//more safely abstracted with getExternalStorageDirectory()
					OutputStream output = new FileOutputStream(PathImage);
					try {
						byte[] buffer = new byte[1024];
						int bytesRead = 0;
						while ((bytesRead = input.read(buffer, 0, buffer.length)) >= 0) {
							output.write(buffer, 0, bytesRead);
						}
					} finally {
						output.close();
					}
				} finally {
					input.close();
				}
			} catch (Exception e) {
				Logging.Error(Logging.GetClassMethod(Thread.currentThread().getStackTrace()), e.toString());
				bLoadFail = true;
				if (UrlImage.contains("www.wizards.com")) {
					bLoadFail = true;
				}
			}
			return bLoadFail; 
		}


		// Renvoie la taille d'un repertoire
		public static long GetDirectorySize(String Directory) {

			// Initialisation
			long lSize = 0;

			// Test d'existence du repertoire
			if (DirectorySystem.DirectoryExists(Directory)) {

				// Recuperation des fichiers du repertoire
				File Folder = new File(Directory);
				File[] Files = Folder.listFiles();

				// Parcours des fichiers
				for (int i = 0; i < Files.length; i++) {

					File File = Files[i];
					if (File.isFile()) {

						// Cas d'un fichier
						lSize += File.length();

					} else if (File.isDirectory()) {

						// Cas d'un repertoire : appel recursif pour lister les fichiers des sous-repertoire
						lSize += GetDirectorySize(File.getAbsolutePath());

					}

				}

			}

			return lSize;

		}
		*/

	}
}

