using Newtonsoft.Json;

namespace MTG.DataExtractor.Objects
{
    public class Legalite
    {
        
        public string Standard = "";
        public string Modern = "";
        public string Legacy = "";
        public string Vintage = "";
        public string Freeform = "";
        public string Prismatic = "";
        [JsonProperty("Tribal Wars Legacy")]
        public string TribalWarsLegacy = "";
        [JsonProperty("Tribal Wars Standard")]
        public string TribalWarsStandard = "";
        [JsonProperty("Singleton 100")]
        public string Singleton100 = "";
        public string Commander = "";

    }
}
