using System;
using System.Collections.Generic;

namespace Objects.Bestiaire.DataBase.Cards
{
	public class AllCards
	{

		public List<CardComplete> Cards { get; set; }
		public Edition Edition { get; set; }

        public AllCards()
        {
            Cards = new List<CardComplete>();
            Edition = new Edition();
        }

    }
}

