using System;
using System.Collections.Generic;

namespace MTG.DataExtractor.Objects
{
    public class EditionCartes_X
    {

        public string name = "";
        public string code = "";
        public string gathererCode = "";
        public string releaseDate = "";
        public string border = "";
        public string type = "";
        public List<object> booster = new List<object>();
        public List<Carte_X> cards = new List<Carte_X>();

    }
}
