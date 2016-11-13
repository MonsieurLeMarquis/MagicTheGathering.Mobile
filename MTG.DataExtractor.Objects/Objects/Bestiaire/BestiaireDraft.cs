using Newtonsoft.Json;

namespace MTG.DataExtractor.Objects
{

    public class BestiaireDraftEdition
    {
        [JsonProperty("1")]
        public string Set1 { get; set; }
        [JsonProperty("2")]
        public string Set2 { get; set; }
        [JsonProperty("3")]
        public string Set3 { get; set; }
    }

    public class BestiaireDraft
    {
        public BestiaireDraftEdition Editions { get; set; }
        public string Nom { get; set; }
        public string Highlander { get; set; }
        public int ID { get; set; }
    }

}
