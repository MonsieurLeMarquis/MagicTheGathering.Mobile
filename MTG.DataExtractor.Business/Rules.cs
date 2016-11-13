using MTG.DataExtractor.Business.Constants;
using MTG.DataExtractor.Business.Helpers;
using MTG.DataExtractor.Files;
using MTG.DataExtractor.Files.Format;
using MTG.DataExtractor.Network;
using MTG.DataExtractor.Report;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MTG.DataExtractor.Business
{
    public class Rules
    {

        private static string MarqueurNoeudFileName = @"<a target=""_blank"" href=""";
        private static string MarqueurFileName = "http://media.wizards.com/images/magic/tcg/resources/rules/MagicCompRules";
        private static string MarqueurDebutSommaire = "Contents";
        private static string MarqueurDebutGlossaire = "Glossary";
        private static string MarqueurDebutCredits = "Credits";
        private static char[] SautsLignes = { (char)10, (char)13 };
        private static string ExtensionPdf = ".pdf";
        private static string ExtensionDocx = ".docx";

        public static void LoadRules()
        {

            // Création de l'arborescence des répertoires
            var directory = HelperPath.GetOutputDirectory("Rules");
            directory = Path.Combine(directory, DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss"));
            Fichier.CreateIfNotExists(directory);            

            // Ouverture du répertoire de sortie
            ReportConsole.WriteLine("[Output] Répertoire de sortie : " + directory);
            Process.Start(directory);

            // Chargement des fichiers
            var urlPdf = GetUrlPdf();
            var urlDocx = GetUrlDocx();
            ReportConsole.WriteLine("[Rules] " + urlPdf);
            DownloadFile(directory, urlPdf);
            ReportConsole.WriteLine("[Rules] " + urlDocx);
            var filePathDocx = DownloadFile(directory, urlDocx);

            // Découpage des règles en sous-fichiers
            SplitRulesFile(directory, filePathDocx);

        }

        private static string GetUrlPdf()
        {
            return GetUrlGeneric(ExtensionPdf);
        }

        private static string GetUrlDocx()
        {
            return GetUrlGeneric(ExtensionDocx);
        }

        private static string GetUrlGeneric(string extension)
        {
            var url = "";
            string WizardsPage = HttpRequest.Get(Url.URL_GATHERER_RULES);
            int iIndexFileNameDebut = WizardsPage.IndexOf(MarqueurNoeudFileName + MarqueurFileName);
            iIndexFileNameDebut += MarqueurNoeudFileName.Length;
            int iIndexFileNameFin = WizardsPage.IndexOf(@"""", iIndexFileNameDebut);
            string strFileName = WizardsPage.Substring(iIndexFileNameDebut, iIndexFileNameFin - iIndexFileNameDebut);
            iIndexFileNameDebut = WizardsPage.IndexOf(MarqueurNoeudFileName + MarqueurFileName, iIndexFileNameDebut);
            if (extension == ExtensionDocx && strFileName.IndexOf(ExtensionDocx) > -1)
                url = strFileName;
            if (extension == ExtensionPdf && strFileName.IndexOf(ExtensionPdf) > -1)
                url = strFileName;
            iIndexFileNameDebut = WizardsPage.IndexOf(MarqueurNoeudFileName + MarqueurFileName, iIndexFileNameFin);
            iIndexFileNameDebut += MarqueurNoeudFileName.Length;
            iIndexFileNameFin = WizardsPage.IndexOf(@"""", iIndexFileNameDebut);
            strFileName = WizardsPage.Substring(iIndexFileNameDebut, iIndexFileNameFin - iIndexFileNameDebut);
            iIndexFileNameDebut = WizardsPage.IndexOf(MarqueurNoeudFileName + MarqueurFileName, iIndexFileNameDebut);
            if (extension == ExtensionDocx && strFileName.IndexOf(ExtensionDocx) > -1)
                url = strFileName;
            if (extension == ExtensionPdf && strFileName.IndexOf(ExtensionPdf) > -1)
                url = strFileName;
            return url;
        }

        private static string DownloadFile(string directory, string url)
        {
            string fileName = url.Substring(url.LastIndexOf(@"/") + 1);
            string filePath = directory + @"\" + fileName;
            HttpRequest.DownloadRemoteDocxFile(url, filePath);
            return filePath;
        }

        private static void SplitRulesFile(string directory, string filePath)
        {

            DocxToText DocX = new DocxToText(filePath);
            string Rules = DocX.ExtractText();

            int IndexSommaireDebut = Rules.IndexOf(MarqueurDebutSommaire) + MarqueurDebutSommaire.Length;
            int IndexSommaireFin = Rules.IndexOf(MarqueurDebutCredits) - 1;
            string Sommaire = Rules.Substring(IndexSommaireDebut, IndexSommaireFin - IndexSommaireDebut);
            Rules = Rules.Substring(IndexSommaireFin);

            int IndexReglesDebut = MarqueurDebutGlossaire.Length;
            int IndexReglesFin = Rules.IndexOf(MarqueurDebutGlossaire) - 1;
            string Regles = Rules.Substring(IndexReglesDebut, IndexReglesFin);
            Rules = Rules.Substring(IndexReglesFin);

            int IndexGlossaireDebut = 0;
            int IndexGlossaireFin = Rules.IndexOf(MarqueurDebutCredits) - 1;
            string Glossaire = Rules.Substring(IndexGlossaireDebut, IndexGlossaireFin);
            Rules = Rules.Substring(IndexGlossaireFin);

            string[] LignesSommaire = Sommaire.Split(SautsLignes);
            string[] LignesRegles = Regles.Split(SautsLignes);
            string[] LignesGlossaire = Glossaire.Split(SautsLignes);

            string RepertoireSommaire = directory + @"\Sommaire";
            string RepertoireRegles = directory + @"\Regles";
            string RepertoireGlossaire = directory + @"\Glossaire";

            Fichier.CreateIfNotExists(RepertoireSommaire);
            Fichier.CreateIfNotExists(RepertoireRegles);
            Fichier.CreateIfNotExists(RepertoireGlossaire);

            List<string> Paragraphes = new List<string>();

            string FichierSommaire = string.Empty;
            foreach (string Ligne in LignesSommaire)
            {
                if (!Ligne.Equals(string.Empty))
                {
                    string Titre = Ligne.IndexOf(" ") > 0 ? Ligne.Substring(0, Ligne.IndexOf(" ") - 1) : Ligne;
                    if (!Titre.Equals(MarqueurDebutGlossaire))
                    {
                        Paragraphes.Add(Titre);
                    }
                    if (!FichierSommaire.Equals(string.Empty))
                    {
                        FichierSommaire += System.Environment.NewLine;
                    }
                    FichierSommaire += Ligne;
                }
            }
            ReportConsole.WriteLine("[Rules] Sommaire");
            Fichier.SaveFile(FichierSommaire, RepertoireSommaire, "Sommaire", "rules");

            string Numero = string.Empty;
            string Texte = string.Empty;
            foreach (string Ligne in LignesRegles)
            {
                if (!Ligne.Equals(string.Empty))
                {

                    bool NewRule = Ligne.StartsWith("0") || Ligne.StartsWith("1") || Ligne.StartsWith("2") || Ligne.StartsWith("3") || Ligne.StartsWith("4") || Ligne.StartsWith("5") || Ligne.StartsWith("6") || Ligne.StartsWith("7") || Ligne.StartsWith("8") || Ligne.StartsWith("9");
                    if (NewRule)
                    {
                        Numero = Ligne.Substring(0, Ligne.IndexOf(" ") - 1);
                        Texte = Ligne.Substring(Ligne.IndexOf(" ") + 1);
                        if (Numero.EndsWith("."))
                        {
                            Numero = Numero.Substring(0, Numero.Length - 1);
                        }
                    }
                    else
                    {
                        Fichier.DeleteFile(RepertoireRegles + @"\" + Numero + ".rules");
                        Texte += System.Environment.NewLine;
                    }
                    ReportConsole.WriteLine("[Rules] " + Numero);
                    Fichier.SaveFile(Texte, RepertoireRegles, Numero, "rules");
                }
            }

            string MotClef = string.Empty;
            string Definition = string.Empty;
            int NbLignesVidesConsecutives = 0;
            foreach (string Ligne in LignesGlossaire)
            {
                if (!Ligne.Equals(string.Empty) && !Ligne.Equals(MarqueurDebutGlossaire))
                {
                    NbLignesVidesConsecutives = 0;
                    if (MotClef.Equals(string.Empty))
                    {
                        MotClef = Ligne;
                    }
                    else
                    {
                        if (!Definition.Equals(string.Empty))
                        {
                            Fichier.DeleteFile(RepertoireGlossaire + @"\" + MotClef + ".rules");
                            Definition += System.Environment.NewLine;
                        }
                        Definition += Ligne;
                        ReportConsole.WriteLine("[Rules] " + MotClef);
                        Fichier.SaveFile(Definition, RepertoireGlossaire, MotClef, "rules");
                    }
                }
                else
                {

                    NbLignesVidesConsecutives++;

                    if (NbLignesVidesConsecutives >= 6)
                    {
                        MotClef = string.Empty;
                        Definition = string.Empty;
                    }

                }
            }

        }

    }
}
