using System;
using Objects.Bestiaire.DataBase.Cards;
using System.Collections.Generic;

namespace Business.Ressources
{
	public class CacheObjects
	{

		public static AllDrafts BestiaireDrafts { get; set; }
		public static AllEditions BestiaireEditions { get; set; }
		public static Dictionary<string, AllCards> BestiairesCards { get; set; }

	}
}

