using System.Collections.Generic;
//using Objects.MtgJson.Enumerations;

namespace Objects.Bestiaire.DataBase.Cards
{
	public class Card
	{

		public int DataBaseID { get; set; }
		public int ID { get; set; }
		public string Name { get; set; }
		public string EditionID { get; set; }
		public string Color { get; set; }
		public string Rarity { get; set; }
		public double CMC { get; set; }
		public bool Actif { get; set; }
		public string Transform { get; set; }
		public string Type { get; set; }
		public List<double> Notes { get; set; }
		public List<int> Picks { get; set; }

        public Card()
        {
            DataBaseID = 0;
            ID = 0;
            Name = "";
            EditionID = "";
            Color = "";
            Rarity = "";
            CMC = 0d;
            Actif = false;
            Transform = "";
            Type = "";
			Notes = new List<double>();
            Picks = new List<int>();
        }

	}
}

