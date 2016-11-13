using System;
using System.Collections.Generic;

namespace MTG.DataExtractor.Objects
{
	public class EditionCartes_Optimized
    {

        public string name = "";
        public string code = "";
        public string gathererCode = "";
        public string releaseDate = "";
		public List<Carte_Optimized> cards = new List<Carte_Optimized>();

    }
}
