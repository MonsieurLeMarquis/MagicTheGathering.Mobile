using System;
using Objects.Bestiaire.DataBase.Cards;
using System.Collections.Generic;
using Objects.Bestiaire.Enumerations;

namespace Objects.Bestiaire.DataBase.Drafts
{
	public class Player
	{

		public String Name;
		public Enums.TYPE_PLAYER TypePlayer;
		public List<List<CardComplete>>  ChosenCardsByBoosters;
		public Booster Booster;

	}
}

