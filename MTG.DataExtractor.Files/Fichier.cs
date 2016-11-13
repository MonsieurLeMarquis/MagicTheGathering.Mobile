using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MTG.DataExtractor.Files
{
    public class Fichier
    {

        protected static List<string> _ReservedFilesNames = new List<string>() {    "con",
                                                                                    "prn",
	                                                                                "aux",
	                                                                                "nul",
	                                                                                "com1",
	                                                                                "com2",
	                                                                                "com3",
	                                                                                "com4",
	                                                                                "com5",
	                                                                                "com6",
	                                                                                "com7",
	                                                                                "com8",
	                                                                                "com9",
	                                                                                "lpt1",
	                                                                                "lpt2",
	                                                                                "lpt3",
	                                                                                "lpt4",
	                                                                                "lpt5",
	                                                                                "lpt6",
	                                                                                "lpt7",
	                                                                                "lpt8",
	                                                                                "lpt9",
	                                                                                "clock$"};

        public static void SaveFile(string strFlow, string strPath, string strFileName, string strFileExtensionName)
        {
            SaveFile(strFlow, strPath, strFileExtensionName + "." + strFileExtensionName);
        }

        public static void SaveFile(string strFlow, string strPath, string strFileName)
        {
            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }
            var aFileName = strFileName.Split('.');
            if (aFileName.Length == 2)
            {
                if (_ReservedFilesNames.Contains(aFileName[0].ToLower()))
                {
                    aFileName[0] += "_Nom_Fichier_Interdit_Sous_Windows";
                }
                strFileName = string.Join(".", aFileName);
            }
            StreamWriter file = new StreamWriter(strPath + @"/" + strFileName, true, Encoding.UTF8);
            file.WriteLine(strFlow);
            file.Close();
        }

        public static void DeleteFile(string strFile)
        {
            if (File.Exists(strFile))
            {
                File.Delete(strFile);
            }
        }

        public static string LoadFile(string strPath)
        {
            string strResultat = string.Empty;
            string line;
            StreamReader file = new StreamReader(strPath);
            while ((line = file.ReadLine()) != null)
            {
                if (!strResultat.Equals(string.Empty))
                {
                    strResultat += Environment.NewLine;
                }
                strResultat += line;
            }
            file.Close();
            return strResultat;
        }

        public static List<string> LoadFileToList(string strPath)
        {
            List<string> lResultat = new List<string>();
            string line;
            StreamReader file = new StreamReader(strPath);
            while ((line = file.ReadLine()) != null)
            {
                lResultat.Add(line);
            }
            file.Close();
            return lResultat;
        }

        public static string GetAbsolutePath(string strRelativePath)
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\" + strRelativePath;
        }

        public static string CreateIfNotExists(string strPath)
        {
            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }
            return strPath;
        }

        public static void RenameAllFileInfolderInLowerCase(string Folder)
        {
            DirectoryInfo d = new DirectoryInfo(Folder);
            FileInfo[] infos = d.GetFiles();
            foreach(FileInfo f in infos)
            {
                File.Move(f.FullName, f.FullName.ToString().ToLower());
            }
        }

    }
}
