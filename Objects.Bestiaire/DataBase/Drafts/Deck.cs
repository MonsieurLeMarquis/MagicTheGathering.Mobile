using System;
using Objects.Bestiaire.DataBase.Cards;
using System.Collections.Generic;

namespace Objects.Bestiaire.DataBase.Drafts
{
	public class Deck
	{
		public List<CardComplete> MainDeck { get; set; }
		public List<CardComplete> Side { get; set; }
		public int AdditionalPlains { get; set; }
		public int AdditionalIslands { get; set; }
		public int AdditionalSwamps { get; set; }
		public int AdditionalMountains { get; set; }
		public int AdditionalForests { get; set; }

	}
}

