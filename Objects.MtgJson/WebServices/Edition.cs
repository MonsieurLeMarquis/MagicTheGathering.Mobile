using System;

namespace Objects.MtgJson.WebServices
{
    public class Edition
    {

        public string name = "";
        public string code = "";
        public DateTime releaseDate = DateTime.MinValue;

        public override string ToString()
        {
            return string.Format("{0} - {1}", code, name);
        }

        public Edition(string Name)
        {
            name = Name;
        }

        /*
        public Edition(string Code, string Name)
        {
            code = Code;
            name = Name;
        }
        */

    }
}
