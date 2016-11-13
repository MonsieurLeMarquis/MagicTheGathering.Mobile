using System;
using System.Collections.Generic;
using MTG.DataExtractor.Objects;
using MTG.DataExtractor.Objects.Managers;
using MTG.DataExtractor.Ressources.Interface;
using MTG.DataExtractor.Business.Constants;
using MTG.DataExtractor.Files;
using MTG.DataExtractor.Files.Format;
using MTG.DataExtractor.Network;
using Newtonsoft.Json;
using MTGRessources = MTG.DataExtractor.Ressources;
using System.IO;

namespace MTG.DataExtractor.Business.Obsolete
{
    public class DownloadObsolete
    {

        public static void Cards(object Edition, Interface_Fichier_Format Format, Interface_Fichier_Nom NomFichier, Interface_Fichier_Casse CasseFichier, List<object> ListeEditions, List<DonneeEdition> ListeDonneesEdition, List<DonneeCarte> ListeDonneesCarte, bool FusionTimeSpiralEtTimeSpiralTimeShifted)
        {
            
            List<Edition> EditionsChargees = new List<Edition>();

            string Repertoire = Fichier.GetAbsolutePath(string.Format(Repertoires.REPERTOIRE_FORMAT, Repertoires.REPERTOIRE_TELECHARGEMENT, Repertoires.REPERTOIRE_CARTES_TEXTES, DateTime.Now.ToString(Repertoires.REPERTOIRE_FORMAT_DATE)));

            System.Diagnostics.Process.Start(Fichier.CreateIfNotExists(Repertoire));

            bool bEditionFusionneeTimeSpiralDejaChargee = false;

            if (Edition != null && (Edition is Edition || Edition is Interface_Ligne_Speciale))
            {

                if (Edition is Interface_Ligne_Speciale && ((Interface_Ligne_Speciale)Edition).TypeLigne == Interface_Ligne_Speciale.TYPE_LIGNE.TOUTES_EDITIONS)
                {
                    ListeEditions.Remove(ListeEditions[0]);
                    foreach (object EditionEnCours in ListeEditions)
                    {
                        if (EditionEnCours is Edition)
                            EditionsChargees.Add((Edition)EditionEnCours);
                    }
                }
                else if (Edition is Edition)
                {
                    EditionsChargees.Add(((Edition)Edition));
                }

                foreach (Edition EditionTemp in EditionsChargees)
                {

                    Edition EditionEnCours = new Edition(EditionTemp.name);
                    EditionEnCours.code = EditionTemp.code;
                    bool bEditionFusion = EditionEnCours.code.Equals("TSP") || EditionEnCours.code.Equals("TSB");
                    bool bToutesLesInformations = ListeDonneesEdition.Count == ManageDonneeEdition.ListeDonneesEditions().Count && ListeDonneesCarte.Count == ManageDonneeCarte.ListeDonneesCartes_X().Count;
                    
                    if (!(bEditionFusion && bEditionFusionneeTimeSpiralDejaChargee))
                    {

                        EditionCartes_X Cartes = new EditionCartes_X();
                        if (bEditionFusion && FusionTimeSpiralEtTimeSpiralTimeShifted)
                        {
                            EditionEnCours = new Edition("Time Spiral \"Timeshifted\"");
                            EditionEnCours.code = "TSB";
                            EditionCartes_X CartesTSB = JsonConvert.DeserializeObject<EditionCartes_X>(HttpRequest.Get(Url.URL_MTGJSON_EDITION_X(EditionEnCours)));
                            EditionEnCours = new Edition("Time Spiral");
                            EditionEnCours.code = "TSP";
                            EditionCartes_X CartesTSP = JsonConvert.DeserializeObject<EditionCartes_X>(HttpRequest.Get(Url.URL_MTGJSON_EDITION_X(EditionEnCours)));
                            Cartes = CartesTSP;
                            foreach (Carte_X Carte in CartesTSB.cards)
                            {
                                Cartes.cards.Add(Carte);
                            }
                            bEditionFusionneeTimeSpiralDejaChargee = true;
                        }
                        else if (!bToutesLesInformations)
                        {
                            Cartes = JsonConvert.DeserializeObject<EditionCartes_X>(HttpRequest.Get(Url.URL_MTGJSON_EDITION_X(EditionEnCours)));
                        }

                        string NomFichierEnCours = "";
                        switch (NomFichier.TypeFichierNom)
                        {
                            case Interface_Fichier_Nom.TYPE_FICHIER_NOM.ID_MTGJSON:
                                NomFichierEnCours = EditionEnCours.code;
                                break;
                            case Interface_Fichier_Nom.TYPE_FICHIER_NOM.ID_BESTIAIRE:
                                NomFichierEnCours = MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_BestiaireID(EditionEnCours.code);
                                break;
                            case Interface_Fichier_Nom.TYPE_FICHIER_NOM.ID_GATHERER:
                                NomFichierEnCours = MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_GathererID(EditionEnCours.code);
                                break;
                            default:
                                NomFichierEnCours = EditionEnCours.name.Replace(@"""", "").Replace("'", "").Replace(".", "").Replace(",", "").Replace(":", "_").Replace(" ", "_");
                                break;
                        }
                        if (CasseFichier.TypeFichierCasse == Interface_Fichier_Casse.TYPE_FICHIER_CASSE.MAJUSCULE)
                        {
                            NomFichierEnCours = NomFichierEnCours.ToUpper();
                        }
                        else
                        {
                            NomFichierEnCours = NomFichierEnCours.ToLower();
                        }

                        switch (Format.TypeFichierCartes)
                        {
                            case Interface_Fichier_Format.TYPE_FICHIER_FORMAT.JSON:
                                if (bToutesLesInformations && !(FusionTimeSpiralEtTimeSpiralTimeShifted && bEditionFusion))
                                {
                                    Fichier.SaveFile(HttpRequest.Get(Url.URL_MTGJSON_EDITION_X(EditionEnCours)), Repertoire, NomFichierEnCours, "json");
                                }
                                else
                                {
                                    Fichier.SaveFile(Json.GenererJSON(Cartes, ListeDonneesEdition, ListeDonneesCarte), Repertoire, NomFichierEnCours, "json");
                                }
                                break;
                            case Interface_Fichier_Format.TYPE_FICHIER_FORMAT.EXCEL:
                                Fichier.SaveFile(Excel.GenererExcel(Cartes, ListeDonneesEdition, ListeDonneesCarte), Repertoire, NomFichierEnCours, "csv");
                                break;
                            case Interface_Fichier_Format.TYPE_FICHIER_FORMAT.SQL:
                                break;
                        }

                    }

                }

            }

        }

        public static void Images(object Carte, Interface_Image_Qualite TypeQualite, Interface_Image_Nom NomFichier, Interface_Fichier_Casse CasseFichier, Interface_Fichier_Extension FichierExtension, EditionCartes_X EditionEnCours, Interface_Source_Donnees Source, string Repertoire = "")
        {

            List<int> ListeCompressions = new List<int>() { 0, 25, 50, 75, 100, 125, 150 };
            string strSousRepertoireImagesOriginales = "original";
            string strSousRepertoireImagesCompressees = "compression_{0}";

            bool OpenDirectory = Repertoire.Equals(string.Empty);
            if (Repertoire.Equals(string.Empty))
            {
                switch (Source.TypeSourcesDonnees)
                {
                    case Interface_Source_Donnees.TYPE_SOURCE_DONNEES.GATHERER:
                        Repertoire = Fichier.GetAbsolutePath(string.Format(Repertoires.REPERTOIRE_FORMAT, Repertoires.REPERTOIRE_TELECHARGEMENT, "Gatherer", DateTime.Now.ToString(Repertoires.REPERTOIRE_FORMAT_DATE))) + @"\" + EditionEnCours.code.ToUpper();
                        break;
                    case Interface_Source_Donnees.TYPE_SOURCE_DONNEES.MTGIMAGE:
                        Repertoire = Fichier.GetAbsolutePath(string.Format(Repertoires.REPERTOIRE_FORMAT, Repertoires.REPERTOIRE_TELECHARGEMENT, (TypeQualite.TypeImageQualite == Interface_Image_Qualite.TYPE_IMAGE_QUALITE.HAUTE_QUALITE ? Repertoires.REPERTOIRE_CARTES_IMAGES_HAUTE_QUALITE : Repertoires.REPERTOIRE_CARTES_IMAGES_COMPRESSEES), DateTime.Now.ToString(Repertoires.REPERTOIRE_FORMAT_DATE))) + @"\" + EditionEnCours.code.ToUpper();
                        break;
                }
            }

            if (!Directory.Exists(Repertoire + @"\" + strSousRepertoireImagesOriginales))
            {
                Directory.CreateDirectory(Repertoire + @"\" + strSousRepertoireImagesOriginales);
            }
            foreach (int iCompression in ListeCompressions)
            {
                if (!Directory.Exists(Repertoire + @"\" + string.Format(strSousRepertoireImagesCompressees, iCompression.ToString())))
                {
                    Directory.CreateDirectory(Repertoire + @"\" + string.Format(strSousRepertoireImagesCompressees, iCompression.ToString()));
                }
            }

            if (OpenDirectory)
            {
                System.Diagnostics.Process.Start(Fichier.CreateIfNotExists(Repertoire));
            }

            List<Carte_X> ListeCartes = new List<Carte_X>();
            if (Carte is Interface_Ligne_Speciale && ((Interface_Ligne_Speciale)Carte).TypeLigne == Interface_Ligne_Speciale.TYPE_LIGNE.TOUTES_CARTES)
            {
                ListeCartes = new List<Carte_X>(EditionEnCours.cards);
            }
            else
            {
                ListeCartes.Add(((Carte_X)Carte));
            }

            foreach (Carte_X CarteEnCours in ListeCartes)
            {

                string UrlImage = string.Empty;
                switch (Source.TypeSourcesDonnees)
                {
                    case Interface_Source_Donnees.TYPE_SOURCE_DONNEES.GATHERER:
                        UrlImage = Url.URL_GATHERER_CARD_IMAGE(CarteEnCours);
                        break;
                    case Interface_Source_Donnees.TYPE_SOURCE_DONNEES.MTGIMAGE:
                        if (TypeQualite.TypeImageQualite == Interface_Image_Qualite.TYPE_IMAGE_QUALITE.HAUTE_QUALITE)
                        {
                            UrlImage = Url.URL_MTGJSON_CARD_IMAGE_HQ(CarteEnCours, FichierExtension.ToString());
                        }
                        else
                        {
                            UrlImage = Url.URL_MTGJSON_CARD_IMAGE(CarteEnCours, FichierExtension.ToString());
                        }
                        break;
                }

                string FichierImage = NomFichier.TypeImageNom == Interface_Image_Nom.TYPE_IMAGE_NOM.ID_MULTIVERSE ? CarteEnCours.multiverseid : CarteEnCours.imageName;
                if (CasseFichier.TypeFichierCasse == Interface_Fichier_Casse.TYPE_FICHIER_CASSE.MAJUSCULE)
                {
                    FichierImage = FichierImage.ToUpper();
                }
                else
                {
                    FichierImage = FichierImage.ToLower();
                }

                string strRepertoireImagesOriginales = Repertoire + @"\" + strSousRepertoireImagesOriginales + @"\" + FichierImage + "." + FichierExtension.ToString();
                string strRepertoireImagesCompressees = Repertoire + @"\" + strSousRepertoireImagesCompressees + @"\" + FichierImage + "." + FichierExtension.ToString();

                HttpRequest.DownloadRemoteImageFile(UrlImage, strRepertoireImagesOriginales);

                foreach (int iCompression in ListeCompressions)
                {
                    Jpeg.VaryQualityLevel(strRepertoireImagesOriginales, string.Format(strRepertoireImagesCompressees, iCompression.ToString()), iCompression);
                }

            }

        }

        public static void IconesEditions(object Edition, Interface_Source_Donnees Source, Interface_Icone_Taille Taille, Interface_Fichier_Nom NomFichier, Interface_Fichier_Casse CasseFichier, Interface_Fichier_Extension FichierExtension, List<object> ListeEditions)
        {

            List<string> Raretes = MTGRessources.Ressources.ListeRaretes;
            List<string> Tailles = new List<string>();
            if (Source.TypeSourcesDonnees == Interface_Source_Donnees.TYPE_SOURCE_DONNEES.MTGIMAGE)
            {
                switch (Taille.TypeIconeTaille)
                {
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_8_x_8:
                        Tailles.Add("8");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_16_x_16:
                        Tailles.Add("16");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_24_x_24:
                        Tailles.Add("24");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_32_x_32:
                        Tailles.Add("32");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_48_x_48:
                        Tailles.Add("48");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_64_x_64:
                        Tailles.Add("64");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_96_x_96:
                        Tailles.Add("96");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_128_x_128:
                        Tailles.Add("128");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_256_x_256:
                        Tailles.Add("256");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_512_x_512:
                        Tailles.Add("512");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_768_x_768:
                        Tailles.Add("768");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_1024_x_1024:
                        Tailles.Add("1024");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.SVG:
                        if (Source.TypeSourcesDonnees == Interface_Source_Donnees.TYPE_SOURCE_DONNEES.MTGIMAGE)
                        {
                            Tailles.Add("SVG");
                        }
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TOUTES_LES_TAILLES:
                        Tailles.Add("8");
                        Tailles.Add("16");
                        Tailles.Add("24");
                        Tailles.Add("32");
                        Tailles.Add("48");
                        Tailles.Add("64");
                        Tailles.Add("96");
                        Tailles.Add("128");
                        Tailles.Add("256");
                        Tailles.Add("512");
                        Tailles.Add("768");
                        Tailles.Add("1024");
                        if (Source.TypeSourcesDonnees == Interface_Source_Donnees.TYPE_SOURCE_DONNEES.MTGIMAGE)
                        {
                            Tailles.Add("SVG");
                        }
                        break;
                }
            }
            else
            {
                switch (Taille.TypeIconeTaille)
                {
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.SMALL:
                        Tailles.Add("small");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.MEDIUM:
                        Tailles.Add("medium");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.LARGE:
                        Tailles.Add("large");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TOUTES_LES_TAILLES:
                        Tailles.Add("small");
                        Tailles.Add("medium");
                        Tailles.Add("large");
                        break;
                }
            }
            List<Edition> EditionsChargees = new List<Edition>();

            string RepertoireGlobal = Fichier.GetAbsolutePath(string.Format(Repertoires.REPERTOIRE_FORMAT, Repertoires.REPERTOIRE_TELECHARGEMENT, Repertoires.REPERTOIRE_ICONES_EDITIONS, DateTime.Now.ToString(Repertoires.REPERTOIRE_FORMAT_DATE)));
            foreach (string TailleEnCours in Tailles)
            {
                Fichier.CreateIfNotExists(RepertoireGlobal + @"\" + TailleEnCours);
            }

            System.Diagnostics.Process.Start(Fichier.CreateIfNotExists(RepertoireGlobal));

            if (Edition != null && (Edition is Edition || Edition is Interface_Ligne_Speciale))
            {

                if (Edition is Interface_Ligne_Speciale && ((Interface_Ligne_Speciale)Edition).TypeLigne == Interface_Ligne_Speciale.TYPE_LIGNE.TOUTES_EDITIONS)
                {
                    ListeEditions.Remove(ListeEditions[0]);
                    foreach (object EditionEnCours in ListeEditions)
                    {
                        if (EditionEnCours is Edition)
                            EditionsChargees.Add((Edition)EditionEnCours);
                    }
                }
                else if (Edition is Edition)
                {
                    EditionsChargees.Add(((Edition)Edition));
                }

                foreach (Edition EditionEnCours in EditionsChargees)
                {

                    foreach (string Rarete in Raretes)
                    {

                        foreach (string TailleImage in Tailles)
                        {

                            string Repertoire = RepertoireGlobal + @"\" + TailleImage;
                            string FichierImage = "";
                            switch (NomFichier.TypeFichierNom)
                            {
                                case Interface_Fichier_Nom.TYPE_FICHIER_NOM.ID_MTGJSON:
                                    FichierImage = EditionEnCours.code;
                                    break;
                                case Interface_Fichier_Nom.TYPE_FICHIER_NOM.ID_BESTIAIRE:
                                    FichierImage = MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_BestiaireID(EditionEnCours.code);
                                    break;
                                case Interface_Fichier_Nom.TYPE_FICHIER_NOM.ID_GATHERER:
                                    FichierImage = MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_GathererID(EditionEnCours.code);
                                    break;
                                default:
                                    FichierImage = EditionEnCours.name.Replace(@"""", "").Replace("'", "").Replace(".", "").Replace(",", "").Replace(":", "_").Replace(" ", "_");
                                    break;
                            }
                            FichierImage += "_" + Rarete;
                            if (CasseFichier.TypeFichierCasse == Interface_Fichier_Casse.TYPE_FICHIER_CASSE.MAJUSCULE)
                            {
                                FichierImage = FichierImage.ToUpper();
                            }
                            else
                            {
                                FichierImage = FichierImage.ToLower();
                            }
                            string UrlImage = "";
                            if (Source.TypeSourcesDonnees == Interface_Source_Donnees.TYPE_SOURCE_DONNEES.MTGIMAGE)
                            {
                                UrlImage = Url.URL_MTGJSON_SET_SYMBOLE(EditionEnCours, Rarete, TailleImage, FichierExtension.ToString());
                            }
                            else
                            {
                                switch (TailleImage)
                                {
                                    case "small":
                                        UrlImage = string.Format("http://gatherer.wizards.com/Handlers/Image.ashx?type=symbol&set={0}&size=small&rarity={1}", MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_GathererID(EditionEnCours.code), Rarete);
                                        break;
                                    case "medium":
                                        UrlImage = string.Format("http://gatherer.wizards.com/Handlers/Image.ashx?type=symbol&set={0}&size=medium&rarity={1}", MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_GathererID(EditionEnCours.code), Rarete);
                                        break;
                                    case "large":
                                        UrlImage = string.Format("http://gatherer.wizards.com/Handlers/Image.ashx?type=symbol&set={0}&size=large&rarity={1}", MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_GathererID(EditionEnCours.code), Rarete);
                                        break;
                                }
                            }
                            string Format = TailleImage.Equals("SVG") ? "svg" : FichierExtension.ToString();
                            HttpRequest.DownloadRemoteImageFile(UrlImage, Repertoire + @"\" + FichierImage + "." + Format);

                        }

                    }

                }

            }

        }

        public static void IconesOthers(object Icone, Interface_Source_Donnees Source, Interface_Icone_Taille Taille, Interface_Fichier_Casse CasseFichier, Interface_Fichier_Extension FichierExtension, List<object> ListeIcones)
        {

            List<string> Raretes = MTGRessources.Ressources.ListeRaretes;
            List<string> Tailles = new List<string>();
            if (Source.TypeSourcesDonnees == Interface_Source_Donnees.TYPE_SOURCE_DONNEES.MTGIMAGE)
            {
                switch (Taille.TypeIconeTaille)
                {
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_8_x_8:
                        Tailles.Add("8");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_16_x_16:
                        Tailles.Add("16");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_24_x_24:
                        Tailles.Add("24");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_32_x_32:
                        Tailles.Add("32");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_48_x_48:
                        Tailles.Add("48");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_64_x_64:
                        Tailles.Add("64");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_96_x_96:
                        Tailles.Add("96");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_128_x_128:
                        Tailles.Add("128");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_256_x_256:
                        Tailles.Add("256");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_512_x_512:
                        Tailles.Add("512");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_768_x_768:
                        Tailles.Add("768");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TAILLE_1024_x_1024:
                        Tailles.Add("1024");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.SVG:
                        if (Source.TypeSourcesDonnees == Interface_Source_Donnees.TYPE_SOURCE_DONNEES.MTGIMAGE)
                        {
                            Tailles.Add("SVG");
                        }
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TOUTES_LES_TAILLES:
                        Tailles.Add("8");
                        Tailles.Add("16");
                        Tailles.Add("24");
                        Tailles.Add("32");
                        Tailles.Add("48");
                        Tailles.Add("64");
                        Tailles.Add("96");
                        Tailles.Add("128");
                        Tailles.Add("256");
                        Tailles.Add("512");
                        Tailles.Add("768");
                        Tailles.Add("1024");
                        if (Source.TypeSourcesDonnees == Interface_Source_Donnees.TYPE_SOURCE_DONNEES.MTGIMAGE)
                        {
                            Tailles.Add("SVG");
                        }
                        break;
                }
            }
            else
            {
                switch (Taille.TypeIconeTaille)
                {
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.SMALL:
                        Tailles.Add("small");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.MEDIUM:
                        Tailles.Add("medium");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.LARGE:
                        Tailles.Add("large");
                        break;
                    case Interface_Icone_Taille.TYPE_ICONE_TAILLE.TOUTES_LES_TAILLES:
                        Tailles.Add("small");
                        Tailles.Add("medium");
                        Tailles.Add("large");
                        break;
                }
            }
            List<string> IconesChargees = new List<string>();

            string RepertoireGlobal = Fichier.GetAbsolutePath(string.Format(Repertoires.REPERTOIRE_FORMAT, Repertoires.REPERTOIRE_TELECHARGEMENT, Repertoires.REPERTOIRE_ICONES_EDITIONS, DateTime.Now.ToString(Repertoires.REPERTOIRE_FORMAT_DATE)));
            foreach (string TailleEnCours in Tailles)
            {
                Fichier.CreateIfNotExists(RepertoireGlobal + @"\" + TailleEnCours);
            }

            System.Diagnostics.Process.Start(Fichier.CreateIfNotExists(RepertoireGlobal));

            if (Icone != null && !Icone.Equals(string.Empty))
            {

                if (Icone is Interface_Ligne_Speciale && ((Interface_Ligne_Speciale)Icone).TypeLigne == Interface_Ligne_Speciale.TYPE_LIGNE.TOUTES_ICONES)
                {
                    ListeIcones.Remove(ListeIcones[0]);
                    foreach (object IconeEnCours in ListeIcones)
                    {
                        if (IconeEnCours is string)
                            IconesChargees.Add((string)IconeEnCours);
                    }
                }
                else if (Icone is string)
                {
                    IconesChargees.Add((string)Icone);
                }

                foreach (string IconeEnCours in IconesChargees)
                {

                    foreach (string TailleImage in Tailles)
                    {

                        string Repertoire = RepertoireGlobal + @"\" + TailleImage;
                        string FichierImage = IconeEnCours;
                        if (CasseFichier.TypeFichierCasse == Interface_Fichier_Casse.TYPE_FICHIER_CASSE.MAJUSCULE)
                        {
                            FichierImage = FichierImage.ToUpper();
                        }
                        else
                        {
                            FichierImage = FichierImage.ToLower();
                        }
                        string UrlImage = "";
                        if (Source.TypeSourcesDonnees == Interface_Source_Donnees.TYPE_SOURCE_DONNEES.MTGIMAGE)
                        {
                            UrlImage = Url.URL_MTGJSON_SYMBOLE(IconeEnCours, TailleImage, FichierExtension.ToString());
                        }
                        else
                        {
                            switch (TailleImage)
                            {
                                case "small":
                                    UrlImage = string.Format("http://gatherer.wizards.com/Handlers/Image.ashx?size=small&name={0}&type=symbol", IconeEnCours);
                                    break;
                                case "medium":
                                    UrlImage = string.Format("http://gatherer.wizards.com/Handlers/Image.ashx?size=medium&name={0}&type=symbol", IconeEnCours);
                                    break;
                                case "large":
                                    UrlImage = string.Format("http://gatherer.wizards.com/Handlers/Image.ashx?size=large&name={0}&type=symbol", IconeEnCours);
                                    break;
                            }
                        }
                        string Format = TailleImage.Equals("SVG") ? "svg" : FichierExtension.ToString();
                        HttpRequest.DownloadRemoteImageFile(UrlImage, Repertoire + @"\" + FichierImage + "." + Format);

                    }

                }

            }

        }

        public static void Bestiaire_JSON_Edition(object Edition, Interface_Fichier_Casse CasseFichier, List<object> ListeEditions)
        {

            List<Edition> EditionsChargees = new List<Edition>();

            string Repertoire = Fichier.GetAbsolutePath(string.Format(Repertoires.REPERTOIRE_FORMAT, Repertoires.REPERTOIRE_TELECHARGEMENT, "Bestiaire", DateTime.Now.ToString(Repertoires.REPERTOIRE_FORMAT_DATE)));

            System.Diagnostics.Process.Start(Fichier.CreateIfNotExists(Repertoire));

            if (Edition != null && (Edition is Edition || Edition is Interface_Ligne_Speciale))
            {

                if (Edition is Interface_Ligne_Speciale && ((Interface_Ligne_Speciale)Edition).TypeLigne == Interface_Ligne_Speciale.TYPE_LIGNE.TOUTES_EDITIONS)
                {
                    ListeEditions.Remove(ListeEditions[0]);
                    foreach (object EditionEnCours in ListeEditions)
                    {
                        if (EditionEnCours is Edition)
                            EditionsChargees.Add((Edition)EditionEnCours);
                    }
                }
                else if (Edition is Edition)
                {
                    EditionsChargees.Add(((Edition)Edition));
                }

                foreach (Edition EditionEnCours in EditionsChargees)
                {

                    string NomFichierEnCours = CasseFichier.TypeFichierCasse == Interface_Fichier_Casse.TYPE_FICHIER_CASSE.MINUSCULE ? MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_BestiaireID(EditionEnCours.code).ToLower() : MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_BestiaireID(EditionEnCours.code).ToUpper();

                    Fichier.SaveFile(HttpRequest.Get(Url.URL_BESTIAIRE_EDITION(EditionEnCours)), Repertoire, NomFichierEnCours, "json");

                }

            }

        }

        public static void Bestiaire_JSON_Liste_Editions(Interface_Fichier_Casse CasseFichier)
        {

            List<Edition> EditionsChargees = new List<Edition>();
            string Repertoire = Fichier.GetAbsolutePath(string.Format(Repertoires.REPERTOIRE_FORMAT, Repertoires.REPERTOIRE_TELECHARGEMENT, "Bestiaire", DateTime.Now.ToString(Repertoires.REPERTOIRE_FORMAT_DATE)));
            System.Diagnostics.Process.Start(Fichier.CreateIfNotExists(Repertoire));
            string NomFichierEnCours = CasseFichier.TypeFichierCasse == Interface_Fichier_Casse.TYPE_FICHIER_CASSE.MINUSCULE ? "editions" : "EDITIONS";
            Fichier.SaveFile(HttpRequest.Get(Url.URL_BESTIAIRE_LISTE_EDITIONS), Repertoire, NomFichierEnCours, "json");

        }

        public static void Bestiaire_JSON_Liste_Drafts(Interface_Fichier_Casse CasseFichier)
        {

            List<Edition> EditionsChargees = new List<Edition>();
            string Repertoire = Fichier.GetAbsolutePath(string.Format(Repertoires.REPERTOIRE_FORMAT, Repertoires.REPERTOIRE_TELECHARGEMENT, "Bestiaire", DateTime.Now.ToString(Repertoires.REPERTOIRE_FORMAT_DATE)));
            System.Diagnostics.Process.Start(Fichier.CreateIfNotExists(Repertoire));
            string NomFichierEnCours = CasseFichier.TypeFichierCasse == Interface_Fichier_Casse.TYPE_FICHIER_CASSE.MINUSCULE ? "drafts" : "DRAFTS";
            Fichier.SaveFile(HttpRequest.Get(Url.URL_BESTIAIRE_LISTE_DRAFTS), Repertoire, NomFichierEnCours, "json");

        }


    }
}
