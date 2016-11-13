using Newtonsoft.Json;

namespace Objects.Bestiaire.WebServices
{
    public class Edition
    {
		public string Nom { get; set; }
		[JsonProperty("Edition")]
		public string EditionID { get; set; }
		public int Premiums { get; set; }
		[JsonProperty("Tricolor")]
        public int Tricolors { get; set; }
        public int Mythics { get; set; }
		public int Lands { get; set; }
		[JsonProperty("Transform")]
        public int Transforms { get; set; }
		public double Nb_Mythics { get; set; }
		public double Nb_Rares { get; set; }
		public double Nb_Uncos { get; set; }
		public double Nb_Communes { get; set; }
		public double Nb_Rares_Speciales { get; set; }
		public double Nb_Uncos_Speciales { get; set; }
		public double Nb_Communes_Speciales { get; set; }
    }
}
