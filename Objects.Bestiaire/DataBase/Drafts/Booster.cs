using System;
using Objects.Bestiaire.DataBase.Cards;
using System.Collections.Generic;

namespace Objects.Bestiaire.DataBase.Drafts
{
	public class Booster
	{

		public Edition Edition  { get; set; }
		public List<CardComplete> Cards { get; set; }

	}
}

