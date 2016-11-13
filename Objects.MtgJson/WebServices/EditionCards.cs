using System;
using System.Collections.Generic;

namespace Objects.MtgJson.WebServices
{
    public class EditionCards
    {

        public string name = "";
        public string code = "";
        public string gathererCode = "";
        public string releaseDate = "";
        public string border = "";
        public string type = "";
        public List<object> booster = new List<object>();
        public List<Card> cards = new List<Card>();

    }
}
