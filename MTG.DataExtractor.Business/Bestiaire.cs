using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using MTG.DataExtractor.Business.Constants;
using MTG.DataExtractor.Objects;
using MTG.DataExtractor.Network;

namespace MTG.DataExtractor.Business
{
    public class Bestiaire
    {

        public static List<BestiaireEdition> GetEditions()
        {
            var result = new List<BestiaireEdition>();
            try
            {
                result = JsonConvert.DeserializeObject<List<BestiaireEdition>>(HttpRequest.Get(Url.URL_BESTIAIRE_LISTE_EDITIONS));
            }
            catch
            {
                result = new List<BestiaireEdition>();
            }
            result.Reverse();
            return result;
        }

        public static List<BestiaireDraft> GetDrafts()
        {
            var result = new List<BestiaireDraft>();
            try
            {
                var data = JsonConvert.DeserializeObject<Dictionary<int, BestiaireDraft>>(HttpRequest.Get(Url.URL_BESTIAIRE_LISTE_DRAFTS));
                data.Keys.ToList().ForEach(key => data[key].ID = key);
                data.Keys.ToList().ForEach(key => result.Add(data[key]));
            }
            catch
            {
                result = new List<BestiaireDraft>();
            }
            result.Reverse();
            return result;
        }

    }
}
