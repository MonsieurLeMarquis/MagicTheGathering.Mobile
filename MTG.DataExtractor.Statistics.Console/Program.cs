using System;
using MTG.DataExtractor.Business.Statistics;

namespace MTG.DataExtractor.Statistiques.Console
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			BusinessStatistics.GenerateAllStatistics ();
		}
	}
}
