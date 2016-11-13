using Newtonsoft.Json;

namespace Objects.Bestiaire.WebServices
{

    public class DraftEdition
    {
        [JsonProperty("1")]
        public string Set1 { get; set; }
        [JsonProperty("2")]
        public string Set2 { get; set; }
        [JsonProperty("3")]
        public string Set3 { get; set; }
    }

    public class Draft
    {
        public DraftEdition Editions { get; set; }
        public string Nom { get; set; }
		public int Highlander { get; set; }
        public int ID { get; set; }
    }

}
