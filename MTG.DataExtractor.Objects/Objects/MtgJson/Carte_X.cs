﻿using System;
using System.Collections.Generic;

namespace MTG.DataExtractor.Objects
{
    public class Carte_X
    {

        public string layout = "";
        public string type = "";
        public List<string> types = new List<string>();
        public List<string> supertypes = new List<string>();
        public List<string> colors = new List<string>();
        public string multiverseid = "";
        public List<string> variations = new List<string>();
        public string name = "";
        public List<string> names = new List<string>();
        public List<string> subtypes = new List<string>();
        public string originalType = "";
        public string cmc = "";
        public string rarity = "";
        public string artist = "";
        public string power = "";
        public string toughness = "";
        public string manaCost = "";
        public string text = "";
        public string originalText = "";
        public string flavor = "";
        public string imageName = "";
        public List<NomEtranger> foreignNames = new List<NomEtranger>();
        public List<Legalite> legalities = new List<Legalite>();
        public List<string> printings = new List<string>();
        public List<Regle> rulings = new List<Regle>();
        public string number = "";
        public string loyalty = "";
        public string watermark = "";
        public string border = "";
        public string hand = "";
        public string life = "";

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
