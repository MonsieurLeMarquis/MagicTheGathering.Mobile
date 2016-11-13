using System;
using System.Linq;
using MTG.DataExtractor.Files;
using System.Diagnostics;
using MTG.DataExtractor.Business.Helpers;
using MTG.DataExtractor.Business;
using Newtonsoft.Json;
using System.Collections.Generic;
using MTG.DataExtractor.Objects;

namespace MTG.DataExtractor.Business.Statistics
{
	public class BusinessStatistics
	{

		public static void GenerateAllStatistics()
		{
			var outputdirectory = CreateDirectory();
			GenerateCsvListEditionsBestiaire(outputdirectory);
			GenerateCsvListEditionsMtgJson(outputdirectory);
		}

		private static void GenerateCsvListEditionsMtgJson(string directory)
		{
			var file = Fichier.LoadFile(@"C:\Android\Xamarin\MagicTheGathering.Mobile\Resources\Json\MtgJson\mtgjson_editions.json");
			var editions = JsonConvert.DeserializeObject<List<Edition>> (file);
			var linesCSV = editions.Select (edition => edition.releaseDate + ";" + edition.code + ";" + edition.name).ToList();
			var CSV = string.Join (System.Environment.NewLine, linesCSV);
			Fichier.SaveFile (CSV, directory, "EditionsMtgJson.csv");
		}

		private static void GenerateCsvListEditionsBestiaire(string directory)
		{
            var file = Fichier.LoadFile(@"C:\Android\Xamarin\MagicTheGathering.Mobile\Resources\Json\Bestiaire\bestiaire_editions.json");
			var editions = JsonConvert.DeserializeObject<List<BestiaireEdition>> (file)
				.Where(edition => !edition.Edition.StartsWith("-"))
				.Reverse()
				.ToList();
			var linesCSV = editions.Select (edition => edition.Edition + ";" + edition.Nom).ToList();
			var CSV = string.Join (System.Environment.NewLine, linesCSV);
			Fichier.SaveFile (CSV, directory, "EditionsBestiaire.csv");
        }

		private static string CreateDirectory()
		{
			var directory = HelperPath.GetOutputDirectory("Statistics");
			Fichier.CreateIfNotExists(directory);
			Process.Start(directory);
			return directory;
		}

	}
}

