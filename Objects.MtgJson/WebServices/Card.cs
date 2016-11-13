using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Objects.MtgJson.WebServices
{
    public class Card
    {
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("multiverseid")]
		public string MultiverseID { get; set; }
		[JsonProperty("type")]
		public string Type { get; set; }
		[JsonProperty("types")]
		public List<string> Types { get; set; }
		[JsonProperty("subtypes")]
		public List<string> SubTypes { get; set; }
		[JsonProperty("supertypes")]
		public List<string> SuperTypes { get; set; }
		[JsonProperty("colors")]
		public List<string> Colors { get; set; }
		[JsonProperty("cmc")]
		public string CMC { get; set; }
		[JsonProperty("manaCost")]
		public string ManaCost { get; set; }
		[JsonProperty("rarity")]
		public string Rarity { get; set; }
		[JsonProperty("power")]
		public string Power { get; set; }
		[JsonProperty("toughness")]
		public string Toughness { get; set; }
		[JsonProperty("loyalty")]
		public string loyalty { get; set; }
		[JsonProperty("text")]
		public string Text { get; set; }
		[JsonProperty("imageName")]
		public string ImageName { get; set; }
		[JsonProperty("number")]
		public string Number { get; set; }
    }

}
