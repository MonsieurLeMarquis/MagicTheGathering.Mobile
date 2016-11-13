using System;
using Objects.Bestiaire.DataBase.Cards;
using System.Collections.Generic;

namespace Objects.Bestiaire.DataBase.Drafts
{
	public class DraftPlay
	{
		
		public Player HumanPlayer { get; set; }
		public List<Player> ComputerPlayers { get; set; }
		public Draft Draft { get; set; }
		public DraftSequence DraftSequence { get; set; }
		public List<Booster> BoxBoosters { get; set; }
		public Deck Deck { get; set; }
	
	}
}

