using System;
using System.Collections.Generic;

namespace MTG.DataExtractor.Objects
{
	public class Carte_Optimized
    {

        public string type = "";
        public List<string> types = new List<string>();
        public List<string> supertypes = new List<string>();
        public List<string> colors = new List<string>();
        public string multiverseid = "";
        public string name = "";
        public List<string> subtypes = new List<string>();
        public string cmc = "";
        public string rarity = "";
        public string power = "";
        public string toughness = "";
        public string manaCost = "";
        public string text = "";
        public string imageName = "";
        public string number = "";
        public string loyalty = "";

        public override string ToString()
        {
            return name;
        }

        public string NomBestiaire
        {
            get
            {
                return name.Replace(" ", "_").Replace("'", "").Replace("-", "_").Replace(",", "").Replace(":", "").Replace("(", "").Replace(")", "").Replace("!", "");
            }
        }

    }

}
