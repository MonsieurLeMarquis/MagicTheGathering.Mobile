using MTG.DataExtractor.Business.Constants;
using MTG.DataExtractor.Business.Helpers;
using MTG.DataExtractor.Files;
using MTG.DataExtractor.Files.Format;
using MTG.DataExtractor.Network;
using MTG.DataExtractor.Objects;
using MTG.DataExtractor.Objects.Managers;
using MTG.DataExtractor.Report;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using MTGRessources = MTG.DataExtractor.Ressources;
using System.Linq;
using MTG.DataExtractor.Business.Debug;

namespace MTG.DataExtractor.Business
{
    public class Hybrid
	{

		public static void LoadAllJsonFilesMtgJson()
		{
			//	\assets\data\gatherer\	editions.json
			//                          KTK.json
			//							...
			var directory = CreateDirectoriesBestiaire();
			LoadGathererData(directory);            
		}

		public static void LoadAllJsonFilesBestiaire()
		{
			//	\assets\data\bestiaire\ drafts.json
			//                          editions.json
			//                          KTK.json
			//							...
			var directory = CreateDirectoriesMtgJson();
			LoadBestiaireData(directory);
		}

		public static void LoadAllEdition(string editionID)
		{
			// Exemple avec l'édition KTK (on suppose que l'ID d'édition de MtgJson est le même que l'ID d'édition du Bestiaire)
			//
			//      \assets\data\bestiaire\ drafts.json
			//                              editions.json
			//                              KTK.json
			//      \assets\data\gatherer\  KTK.json
			//      \assets\icons\small\    ktk_c.gif
			//                              ktk_u.gif
			//                              ktk_r.gif
			//                              ktk_m.gif
			//      \assets\icons\medium\   ... idem ...
			//      \assets\icons\large\    ... idem ...
			//      \assets\images\KTK\     386672.jpg
			//                              ...
			var directory = CreateDirectoriesEdition(editionID);
			LoadBestiaireData(editionID, directory);
			LoadGathererData(editionID, directory);            
			LoadGathererEditionIcons(editionID, directory);
			LoadGathererEditionImages(editionID, directory);
		}

		private static string CreateDirectoriesEdition(string editionID)
		{
			var directory = HelperPath.GetOutputDirectory("Edition " + editionID);
			// Création de l'arborescence des répertoires
			Fichier.CreateIfNotExists(directory);
			Fichier.CreateIfNotExists(HelperLoadEdition.PathDataBestiaire(directory));
			Fichier.CreateIfNotExists(HelperLoadEdition.PathDataGatherer(directory));
			Fichier.CreateIfNotExists(HelperLoadEdition.PathIconsSmall(directory));
			Fichier.CreateIfNotExists(HelperLoadEdition.PathIconsMedium(directory));
			Fichier.CreateIfNotExists(HelperLoadEdition.PathIconsLarge(directory));
			Fichier.CreateIfNotExists(HelperLoadEdition.PathImages(directory, editionID));
			// Ouverture du répertoire de sortie
			ReportConsole.WriteLine("[Output] Répertoire de sortie : " + directory);
			Process.Start(directory);
			return directory;
		}

		private static string CreateDirectoriesBestiaire()
		{
			var directory = HelperPath.GetOutputDirectory("Bestiaire JSON Files");
			// Création de l'arborescence des répertoires
			Fichier.CreateIfNotExists(directory);
			Fichier.CreateIfNotExists(HelperLoadEdition.PathDataBestiaire(directory));
			// Ouverture du répertoire de sortie
			ReportConsole.WriteLine("[Output] Répertoire de sortie : " + directory);
			Process.Start(directory);
			return directory;
		}

		private static string CreateDirectoriesMtgJson()
		{
			var directory = HelperPath.GetOutputDirectory("MTG JSON Files");
			// Création de l'arborescence des répertoires
			Fichier.CreateIfNotExists(directory);
			Fichier.CreateIfNotExists(HelperLoadEdition.PathDataGatherer(directory));
			// Ouverture du répertoire de sortie
			ReportConsole.WriteLine("[Output] Répertoire de sortie : " + directory);
			Process.Start(directory);
			return directory;
		}

		private static void LoadBestiaireData(string directory)
		{
			LoadBestiaireData ("", directory);
		}

		private static void LoadBestiaireData(string editionID, string directory)
		{
			// Chargement des données du Bestiaire : liste des éditions et liste des drafts
			//      \assets\data\bestiaire\ drafts.json
			//                              editions.json
			//                              KTK.json
			var editions = Bestiaire.GetEditions().Where(edition => !edition.Edition.StartsWith("-"));
			Fichier.SaveFile(HttpRequest.Get(Url.URL_BESTIAIRE_LISTE_EDITIONS), HelperLoadEdition.PathDataBestiaire(directory), HelperLoadEdition.FileNameBestiaireEditions);
			ReportConsole.WriteLine("[Bestiaire] Editions list");
			Fichier.SaveFile(HttpRequest.Get(Url.URL_BESTIAIRE_LISTE_DRAFTS), HelperLoadEdition.PathDataBestiaire(directory), HelperLoadEdition.FileNameBestiaireDrafts);
			ReportConsole.WriteLine("[Bestiaire] Drafts list");
			if (string.IsNullOrEmpty (editionID)) {
				foreach (var edition in editions) {
					Fichier.SaveFile (HttpRequest.Get (Url.URL_BESTIAIRE_EDITION (edition.Edition)), HelperLoadEdition.PathDataBestiaire (directory), HelperLoadEdition.FileNameBestiaireEdition (edition.Edition));
					ReportConsole.WriteLine ("[Bestiaire] Cards list " + edition.Edition);
				}
			} else {
				Fichier.SaveFile (HttpRequest.Get (Url.URL_BESTIAIRE_EDITION (editionID)), HelperLoadEdition.PathDataBestiaire (directory), HelperLoadEdition.FileNameBestiaireEdition (editionID));
				ReportConsole.WriteLine ("[Bestiaire] Cards list");
			}
		}

		private static void LoadGathererData(string directory)
		{
			LoadGathererData ("", directory);
		}

		private static void LoadGathererData(string editionID, string directory)
		{
			// Chargement des données Gatherer
			//      \assets\data\gatherer\  KTK.json
			var editions = MtgJson.DownloadEditions();
			var donneesEdition = ManageDonneeEdition.ListDonneesEditions_Filtered();
			var donneesCarte = ManageDonneeCarte.ListDonneesCartes_Filtered();
			Fichier.SaveFile(HttpRequest.Get(Url.URL_MTGJSON_LIST_EDITIONS), HelperLoadEdition.PathDataGatherer(directory), HelperLoadEdition.FileNameMtgJsonEditions);
			ReportConsole.WriteLine("[Gatherer] Editions list");
			if (string.IsNullOrEmpty (editionID)) {
				foreach (var edition in editions) {
					var cards = JsonConvert.DeserializeObject<EditionCartes_Optimized>(HttpRequest.Get(Url.URL_MTGJSON_EDITION_X(edition.code)));
					Fichier.SaveFile(JsonConvert.SerializeObject(cards), HelperLoadEdition.PathDataGatherer(directory), HelperLoadEdition.FileNameMtgJsonEdition(edition.code));
					ReportConsole.WriteLine("[Gatherer] Cards list " + edition.code);
				}
			} else {
				var cards = JsonConvert.DeserializeObject<EditionCartes_Optimized>(HttpRequest.Get(Url.URL_MTGJSON_EDITION_X(editionID)));
				Fichier.SaveFile(JsonConvert.SerializeObject(cards), HelperLoadEdition.PathDataGatherer(directory), HelperLoadEdition.FileNameMtgJsonEdition(editionID));
				ReportConsole.WriteLine("[Gatherer] Cards list");
			}
		}

        private static void LoadGathererEditionIcons(string editionID, string directory)
        {
            //      \assets\icons\small\    ktk_c.gif
            //                              ktk_u.gif
            //                              ktk_r.gif
            //                              ktk_m.gif
            //      \assets\icons\medium\   ... idem ...
            //      \assets\icons\large\    ... idem ...
            foreach (string Rarete in MTGRessources.Ressources.ListeRaretes)
            {
                foreach (string TailleImage in new List<string>() { "small", "medium", "large" })
                {
                    string FichierImage = editionID.ToLower() + "_" + Rarete.ToLower() + ".gif";
                    string UrlImage = "";
                    switch (TailleImage)
                    {
                        case "small":
                            UrlImage = string.Format("http://gatherer.wizards.com/Handlers/Image.ashx?type=symbol&set={0}&size=small&rarity={1}", editionID, Rarete);
                            break;
                        case "medium":
                            UrlImage = string.Format("http://gatherer.wizards.com/Handlers/Image.ashx?type=symbol&set={0}&size=medium&rarity={1}", editionID, Rarete);
                            break;
                        case "large":
                            UrlImage = string.Format("http://gatherer.wizards.com/Handlers/Image.ashx?type=symbol&set={0}&size=large&rarity={1}", editionID, Rarete);
                            break;
                    }
                    HttpRequest.DownloadRemoteImageFile(UrlImage, HelperLoadEdition.PathIcons(directory) + @"\" + TailleImage + @"\" + FichierImage);
                    ReportConsole.WriteLine("[Icon] " + FichierImage + " (" + TailleImage + ")");

                }
            }
        }
        
        private static void LoadGathererEditionImages(string editionID, string directory)
        {
            //      \assets\images\KTK\     386672.jpg
            //                              ...
            var EditionEnCours = MtgJson.DownloadEdition_X(editionID);
            var index = 1;
            foreach (Carte_X CarteEnCours in EditionEnCours.cards)
            {
                string UrlImage = Url.URL_GATHERER_CARD_IMAGE(CarteEnCours);
                string FichierImage = CarteEnCours.multiverseid + ".jpg";                
                HttpRequest.DownloadRemoteImageFile(UrlImage, HelperLoadEdition.PathImages(directory, editionID) + @"\" + FichierImage);
                ReportConsole.WriteLine("[Image] " + index.ToString("000") + "/" + EditionEnCours.cards.Count.ToString() + " - " + FichierImage + " (" + CarteEnCours.name + ")");
                index++;
            }
		}

		public static void CreateEditionsHybridBestiaire()
		{
			var directory = CreateDirectoriesEdition("Bestiaire");

			var editions = JsonConvert.DeserializeObject<List<Edition>> (Fichier.LoadFile(@"C:\Android\Xamarin\MagicTheGathering.Mobile\Resources\Json\MtgJson\mtgjson_editions.json"));
			var editionsBestiaire = JsonConvert.DeserializeObject<List<BestiaireEdition>> (Fichier.LoadFile(@"C:\Android\Xamarin\MagicTheGathering.Mobile\Resources\Json\Bestiaire\bestiaire_editions.json"));

			var editionsAll = new List<EditionCartes_Optimized> ();
			var editionsTSP = new List<EditionCartes_Optimized> ();

			foreach(var edition in editions)
			{
				var editionMtgJson = JsonConvert.DeserializeObject<EditionCartes_Optimized> (Fichier.LoadFile(@"C:\Android\Xamarin\MagicTheGathering.Mobile\Resources\Json\MtgJson\mtgjson_" + edition.code +".json"));
				editionsAll.Add (editionMtgJson);
				if (edition.code == "TSP" || edition.code == "TSB") {
					editionsTSP.Add (editionMtgJson);
				}
			}

			// Recopie des éditions
			foreach (var edition in editionsBestiaire) {
				if (edition.Edition != "CUB" && edition.Edition != "CU2" && edition.Edition != "MSW" && edition.Edition != "TSP" && !edition.Edition.StartsWith("-")) {
					var id = edition.Edition;
					id = id.ToUpper() == "A" ? "LEA" : id;
					id = id.ToUpper() == "B" ? "LEB" : id;
					id = id.ToUpper() == "AN" ? "ARN" : id;
					id = id.ToUpper() == "U" ? "2ED" : id;
					id = id.ToUpper() == "AQ" ? "ATQ" : id;
					id = id.ToUpper() == "R" ? "3ED" : id;
					id = id.ToUpper() == "LG" ? "LEG" : id;
					id = id.ToUpper() == "DK" ? "DRK" : id;
					id = id.ToUpper() == "FE" ? "FEM" : id;
					id = id.ToUpper() == "4E" ? "4ED" : id;
					id = id.ToUpper() == "IA" ? "ICE" : id;
					id = id.ToUpper() == "CH" ? "CHR" : id;
					id = id.ToUpper() == "HL" ? "HML" : id;
					id = id.ToUpper() == "AL" ? "ALL" : id;
					id = id.ToUpper() == "MI" ? "MIR" : id;
					id = id.ToUpper() == "VI" ? "VIS" : id;
					id = id.ToUpper() == "5E" ? "5ED" : id;
					id = id.ToUpper() == "PT" ? "POR" : id;
					id = id.ToUpper() == "WE" ? "WTH" : id;
					id = id.ToUpper() == "TP" ? "TMP" : id;
					id = id.ToUpper() == "ST" ? "STH" : id;
					id = id.ToUpper() == "P2" ? "PO2" : id;
					id = id.ToUpper() == "EX" ? "EXO" : id;
					id = id.ToUpper() == "UG" ? "UGL" : id;
					id = id.ToUpper() == "US" ? "USG" : id;
					id = id.ToUpper() == "UL" ? "ULG" : id;
					id = id.ToUpper() == "6E" ? "6ED" : id;
					id = id.ToUpper() == "P3" ? "PTK" : id;
					id = id.ToUpper() == "UD" ? "UDS" : id;
					id = id.ToUpper() == "P4" ? "S99" : id;
					id = id.ToUpper() == "MM" ? "MMQ" : id;
					id = id.ToUpper() == "BR" ? "BRB" : id;
					id = id.ToUpper() == "NE" ? "NMS" : id;
					id = id.ToUpper() == "PY" ? "PCY" : id;
					id = id.ToUpper() == "IN" ? "INV" : id;
					id = id.ToUpper() == "PS" ? "PLS" : id;
					id = id.ToUpper() == "7E" ? "7ED" : id;
					id = id.ToUpper() == "AP" ? "APC" : id;
					id = id.ToUpper() == "OD" ? "ODY" : id;
					id = id.ToUpper() == "TO" ? "TOR" : id;
					id = id.ToUpper() == "JU" ? "JUD" : id;
					id = id.ToUpper() == "ON" ? "ONS" : id;
					id = id.ToUpper() == "LE" ? "LGN" : id;
					id = id.ToUpper() == "SC" ? "SCG" : id;
					id = id.ToUpper() == "8E" ? "8ED" : id;
					id = id.ToUpper() == "MR" ? "MRD" : id;
					id = id.ToUpper() == "DS" ? "DST" : id;
					id = id.ToUpper() == "FD" ? "5DN" : id;
					id = id.ToUpper() == "UHN" ? "UNH" : id;
					id = id.ToUpper() == "9E" ? "9ED" : id;
					id = id.ToUpper() == "GP" ? "GPT" : id;
					id = id.ToUpper() == "CS" ? "CSP" : id;
					id = id.ToUpper() == "TSP" ? "TSP" : id;
					id = id.ToUpper() == "TSP" ? "TSB" : id;
					id = id.ToUpper() == "PC" ? "PLC" : id;
					id = id.ToUpper() == "LOR" ? "LRW" : id;
					id = id.ToUpper() == "CFX" ? "CON" : id;
					id = id.ToUpper() == "REB" ? "ARB" : id;
					id = id.ToUpper() == "MOM" ? "MMA" : id;
					var editionMtgJson = editionsAll.FirstOrDefault(e => e.code == id);
					Fichier.SaveFile(JsonConvert.SerializeObject(editionMtgJson), HelperLoadEdition.PathDataGatherer(directory), HelperLoadEdition.FileNameMtgJsonEdition(id));
				}
			}

			// CUB
			var editionCUB = CreateEditionHybrid(editionsAll, JsonConvert.DeserializeObject<List<BestiaireCarte>> (Fichier.LoadFile(@"C:\Android\Xamarin\MagicTheGathering.Mobile\Resources\Json\Bestiaire\bestiaire_CUB.json")), "CUB", "CUB");
			// CU2
			var editionCU2 = CreateEditionHybrid(editionsAll, JsonConvert.DeserializeObject<List<BestiaireCarte>> (Fichier.LoadFile(@"C:\Android\Xamarin\MagicTheGathering.Mobile\Resources\Json\Bestiaire\bestiaire_CU2.json")), "CU2", "CU2");
			// MSW
			//var editionMSW = CreateEditionHybrid(editionsAll, JsonConvert.DeserializeObject<List<BestiaireCarte>> (Fichier.LoadFile(@"C:\Android\Xamarin\MagicTheGathering.Mobile\Resources\Json\Bestiaire\bestiaire_MSW.json")), "MSW", "MSW");
			// TSP
			var editionTSP = CreateEditionHybrid(editionsTSP, JsonConvert.DeserializeObject<List<BestiaireCarte>> (Fichier.LoadFile(@"C:\Android\Xamarin\MagicTheGathering.Mobile\Resources\Json\Bestiaire\bestiaire_TSP.json")), "TSP", "TSP");						

			Fichier.SaveFile(JsonConvert.SerializeObject(editionCUB), HelperLoadEdition.PathDataGatherer(directory), HelperLoadEdition.FileNameMtgJsonEdition("CUB"));
			Fichier.SaveFile(JsonConvert.SerializeObject(editionCU2), HelperLoadEdition.PathDataGatherer(directory), HelperLoadEdition.FileNameMtgJsonEdition("CU2"));
			//Fichier.SaveFile(JsonConvert.SerializeObject(editionMSW), HelperLoadEdition.PathDataGatherer(directory), HelperLoadEdition.FileNameMtgJsonEdition("MSW"));
			Fichier.SaveFile(JsonConvert.SerializeObject(editionTSP), HelperLoadEdition.PathDataGatherer(directory), HelperLoadEdition.FileNameMtgJsonEdition("TSP"));

		}

		private static EditionCartes_Optimized CreateEditionHybrid (List<EditionCartes_Optimized> editionsMtgJson, List<BestiaireCarte> cardsBestiaire, string editionName, string editionCode) {
			EditionCartes_Optimized editionHybrid = new EditionCartes_Optimized () 
			{
				code = editionCode,
				name = editionName,
				cards = new List<Carte_Optimized>()
			};

			List<string> Names = new List<string>();
			List<string> NamesLoaded = new List<string>();

			bool Finished = false;

			foreach (BestiaireCarte card in cardsBestiaire) {
				if (!Names.Contains(ProcessDebug.Convert_CardName_Generic(card.Nom)))
				{
					Names.Add(ProcessDebug.Convert_CardName_Generic(card.Nom));
				}
			}


			string CartesSuspectes = string.Empty;
			foreach (var edition in editionsMtgJson)
			{
				
				if (!Finished)
				{
					
					foreach (var card in edition.cards)
					{

						string CardName = ProcessDebug.Convert_CardName_Generic(card.imageName);

						if (!Finished)
						{
							
							if (Names.Contains(ProcessDebug.Convert_CardName_Generic(card.imageName)))
								//if (MultiverseIDsCUB.Contains(Carte.multiverseid))
							{
								if (!NamesLoaded.Contains(ProcessDebug.Convert_CardName_Generic(card.imageName)))
								{
									NamesLoaded.Add(ProcessDebug.Convert_CardName_Generic(card.imageName));
									card.number = NamesLoaded.Count().ToString();
									Finished = cardsBestiaire.Count == NamesLoaded.Count;
									editionHybrid.cards.Add(card);
								}
							}

						}

					}

				}

			}

			var debug = Names.Except (NamesLoaded).ToList();

			return editionHybrid;
		}

    }
}
