using MTG.DataExtractor.Business.Constants;
using MTG.DataExtractor.Network;
using MTG.DataExtractor.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MTG.DataExtractor.Business
{
    public class MtgJson
    {

        public static List<Edition> DownloadEditions()
        {
            List<Edition> result = new List<Edition>();
            string json = HttpRequest.Get(Url.URL_MTGJSON_LIST_EDITIONS);
            if (!string.IsNullOrEmpty(json))
            {
                result = JsonConvert.DeserializeObject<List<Edition>>(json);
            }
            return result;
        }

        public static EditionCartes DownloadEdition(string editionID)
        {
            return JsonConvert.DeserializeObject<EditionCartes>(HttpRequest.Get(Url.URL_MTGJSON_EDITION(editionID)));
        }

        public static EditionCartes_X DownloadEdition_X(string editionID)
        {
            return JsonConvert.DeserializeObject<EditionCartes_X>(HttpRequest.Get(Url.URL_MTGJSON_EDITION_X(editionID)));
        }

    }
}
