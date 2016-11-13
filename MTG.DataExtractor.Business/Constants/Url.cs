using System;
using System.Collections.Generic;
using MTG.DataExtractor.Objects;
using MTGRessources = MTG.DataExtractor.Ressources;

namespace MTG.DataExtractor.Business.Constants
{
    public class Url
    {

        public static string URL_MTGJSON_LIST_EDITIONS = "http://mtgjson.com/json/SetList.json";

        public static string URL_MTGJSON_EDITION_FORMAT = "http://mtgjson.com/json/{0}.json";
        public static string URL_MTGJSON_EDITION_X_FORMAT = "http://mtgjson.com/json/{0}-x.json";
        public static string URL_MTGJSON_EDITION(Edition Edition)
        {
            return URL_MTGJSON_EDITION(Edition.code);
        }
        public static string URL_MTGJSON_EDITION(string EditionID)
        {
            return string.Format(URL_MTGJSON_EDITION_FORMAT, EditionID);
        }
        public static string URL_MTGJSON_EDITION_X(Edition Edition)
        {
            return URL_MTGJSON_EDITION_X(Edition.code);
        }
        public static string URL_MTGJSON_EDITION_X(string EditionID)
        {
            return string.Format(URL_MTGJSON_EDITION_X_FORMAT, EditionID);
        }

        public static string URL_MTGJSON_CARD_IMAGE_FORMAT = "http://mtgimage.com/multiverseid/{0}.{1}";
        public static string URL_MTGJSON_CARD_IMAGE_HQ_FORMAT = "http://mtgimage.com/multiverseid/{0}.hq.{1}";
        public static string URL_MTGJSON_CARD_IMAGE(Carte_X Carte, string FichierExtension)
        {
            return string.Format(URL_MTGJSON_CARD_IMAGE_FORMAT, Carte.multiverseid, FichierExtension);
        }
        public static string URL_MTGJSON_CARD_IMAGE_HQ(Carte_X Carte, string FichierExtension)
        {
            return string.Format(URL_MTGJSON_CARD_IMAGE_HQ_FORMAT, Carte.multiverseid, FichierExtension);
        }

        public static string URL_MTGJSON_SET_SYMBOLE_FORMAT = "http://mtgimage.com/symbol/set/{0}/{1}/{2}.{3}";
        public static string URL_MTGJSON_SET_SYMBOLE_SVG_FORMAT = "http://mtgimage.com/symbol/set/{0}/{1}.svg";
        public static string URL_MTGJSON_SET_SYMBOLE(Edition Edition, string Rarete, string Taille, string Format)
        {
            if (Taille.Equals("SVG"))
            {
                return string.Format(URL_MTGJSON_SET_SYMBOLE_SVG_FORMAT, Edition.code, Rarete);
            }
            else
            {
                return string.Format(URL_MTGJSON_SET_SYMBOLE_FORMAT, Edition.code, Rarete, Taille, Format);
            }
        }

        public static string URL_MTGJSON_SYMBOLE_FORMAT = "http://mtgimage.com/symbol/mana/{0}/{1}.{2}";
        public static string URL_MTGJSON_SYMBOLE_SVG_FORMAT = "http://mtgimage.com/symbol/mana/{0}.svg";
        public static string URL_MTGJSON_SYMBOLE_OTHER_FORMAT = "http://mtgimage.com/symbol/other/{0}/{1}.{2}";
        public static string URL_MTGJSON_SYMBOLE_OTHER_SVG_FORMAT = "http://mtgimage.com/symbol/other/{0}.svg";
        public static string URL_MTGJSON_SYMBOLE(string Symbole, string Taille, string Format)
        {
            List<string> IconesOthers = MTGRessources.Ressources.ListeIconesOthers;
            if (Taille.Equals("SVG"))
            {
                if (IconesOthers.Contains(Symbole))
                {
                    return string.Format(URL_MTGJSON_SYMBOLE_OTHER_SVG_FORMAT, Symbole);
                }
                else
                {
                    return string.Format(URL_MTGJSON_SYMBOLE_SVG_FORMAT, Symbole);
                }
            }
            else
            {
                if (IconesOthers.Contains(Symbole))
                {
                    return string.Format(URL_MTGJSON_SYMBOLE_OTHER_FORMAT, Symbole, Taille, Format);
                }
                else
                {
                    return string.Format(URL_MTGJSON_SYMBOLE_FORMAT, Symbole, Taille, Format);
                }
            }
        }

        public static string URL_GATHERER_RULES = "http://archive.wizards.com/Magic/tcg/article.aspx?x=magic/rules";
        /*
        public static string URL_EDITIONS_GATHERER = "http://gatherer.wizards.com/Pages/Default.aspx";
        public static string URL_EDITIONS_MAGICCARDS = "http://magiccards.info/sitemap.html";

        //protected static string FORMAT_URL_EDITION_GATHERER = "http://gatherer.wizards.com/Pages/Search/Default.aspx?output=spoiler&method=text&action=advanced&set=%5B%22{0}%22%5D";
        protected static string FORMAT_URL_EDITION_GATHERER = "http://gatherer.wizards.com/Pages/Search/Default.aspx?page={0}&set=%5B%22{1}%22%5D";
        protected static string FORMAT_URL_EDITION_MAGICCARDS = "http://magiccards.info/query?q=%2B%2Be%3Aths%2Fen&v=list&s=cname";

        public static string URL_EDITION_GATHERER(Edition Edition, int Page)
        {
            return string.Format(FORMAT_URL_EDITION_GATHERER, Page.ToString(), Edition.Libelle.Replace(" ", "%20"));
        }
        */
        
        public static string URL_BESTIAIRE_LISTE_EDITIONS = "http://draft.bestiaire.org/WS/ws_fetch_editions.php";
        public static string URL_BESTIAIRE_LISTE_DRAFTS = "http://draft.bestiaire.org/WS/ws_fetch_drafts.php";
        public static string URL_BESTIAIRE_EDITION_FORMAT = "http://draft.bestiaire.org/WS/ws_fetch_cards.php?edition={0}";
        public static string URL_BESTIAIRE_EDITION(Edition Edition)
        {
            return URL_BESTIAIRE_EDITION(Edition.code);
        }
        public static string URL_BESTIAIRE_EDITION(string EditionID)
        {
            return string.Format(URL_BESTIAIRE_EDITION_FORMAT, MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_BestiaireID(EditionID));
        }

        public static string URL_GATHERER_CARD_IMAGE_FORMAT = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid={0}&type=card";
        public static string URL_GATHERER_CARD_IMAGE(Carte_X Carte)
        {
            return string.Format(URL_GATHERER_CARD_IMAGE_FORMAT, Carte.multiverseid);
        }

    }
}
