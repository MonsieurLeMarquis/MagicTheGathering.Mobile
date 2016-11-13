using System;
using System.Linq;
using System.Collections.Generic;

namespace MTG.DataExtractor.Objects.Managers
{
    public class ManageDonneeEdition
    {

        public static string ID(DonneeEdition donneeEdition)
        {
            string Resultat = string.Empty;
            switch (donneeEdition.TypeDonnee)
            {
                case DonneeEdition.TYPE_DONNEE.EDITION_NAME:
                    Resultat = "EDITION_NAME";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_BESTIAIRE:
                    Resultat = "EDITION_CODE_BESTIAIRE";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_GATHERER:
                    Resultat = "EDITION_CODE_GATHERER";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_MTGJSON:
                    Resultat = "EDITION_CODE_MTGJSON";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_RELEASE_DATE:
                    Resultat = "EDITION_RELEASE_DATE";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_BORDER:
                    Resultat = "EDITION_BORDER";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_TYPE:
                    Resultat = "EDITION_TYPE";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_BOOSTER:
                    Resultat = "EDITION_BOOSTER";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CARDS:
                    Resultat = "EDITION_CARDS";
                    break;
            }
            return Resultat;
        }

        public static string JSON_ID(DonneeEdition donneeEdition)
        {
            string Resultat = string.Empty;
            switch (donneeEdition.TypeDonnee)
            {
                case DonneeEdition.TYPE_DONNEE.EDITION_NAME:
                    Resultat = "name";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_BESTIAIRE:
                    Resultat = "bestiaireCode";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_GATHERER:
                    Resultat = "gathererCode";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_MTGJSON:
                    Resultat = "code";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_RELEASE_DATE:
                    Resultat = "releaseDate";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_BORDER:
                    Resultat = "border";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_TYPE:
                    Resultat = "type";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_BOOSTER:
                    Resultat = "booster";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CARDS:
                    Resultat = "cards";
                    break;
            }
            return Resultat;
        }

        public static string Libelle(DonneeEdition donneeEdition)
        {
            string Resultat = string.Empty;
            switch (donneeEdition.TypeDonnee)
            {
                case DonneeEdition.TYPE_DONNEE.EDITION_NAME:
                    Resultat = "Name";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_BESTIAIRE:
                    Resultat = "Code Bestiaire";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_GATHERER:
                    Resultat = "Code Gatherer";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_MTGJSON:
                    Resultat = "Code Mtgjson";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_RELEASE_DATE:
                    Resultat = "Release Date";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_BORDER:
                    Resultat = "Border";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_TYPE:
                    Resultat = "Type";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_BOOSTER:
                    Resultat = "Booster";
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CARDS:
                    Resultat = "Cards";
                    break;
            }
            return Resultat;
        }

        public static string Value(DonneeEdition donneeEdition, EditionCartes Edition)
        {
            string Resultat = string.Empty;
            switch (donneeEdition.TypeDonnee)
            {
                case DonneeEdition.TYPE_DONNEE.EDITION_NAME:
                    Resultat = Edition.name;
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_BESTIAIRE:
				Resultat = Ressources.Ressources.ConversionEditionID_MTGJSON_To_BestiaireID(Edition.code);
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_GATHERER:
                    Resultat = Ressources.Ressources.ConversionEditionID_MTGJSON_To_GathererID(Edition.code);
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_MTGJSON:
                    Resultat = Edition.code;
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_RELEASE_DATE:
                    Resultat = Edition.releaseDate;
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_BORDER:
                    Resultat = Edition.border;
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_TYPE:
                    Resultat = Edition.type;
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_BOOSTER:
                    Resultat = BoosterToString(Edition.booster);
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CARDS:
                    Resultat = "Not implemented";
                    break;
            }
            return Resultat;
        }

        public static string Value(DonneeEdition donneeEdition, EditionCartes_X Edition)
        {
            string Resultat = string.Empty;
            switch (donneeEdition.TypeDonnee)
            {
                case DonneeEdition.TYPE_DONNEE.EDITION_NAME:
                    Resultat = Edition.name;
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_BESTIAIRE:
                    Resultat = Ressources.Ressources.ConversionEditionID_MTGJSON_To_BestiaireID(Edition.code);
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_GATHERER:
                    Resultat = Ressources.Ressources.ConversionEditionID_MTGJSON_To_GathererID(Edition.code);
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_MTGJSON:
                    Resultat = Edition.code;
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_RELEASE_DATE:
                    Resultat = Edition.releaseDate;
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_BORDER:
                    Resultat = Edition.border;
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_TYPE:
                    Resultat = Edition.type;
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_BOOSTER:
                    Resultat = BoosterToString(Edition.booster);
                    break;
                case DonneeEdition.TYPE_DONNEE.EDITION_CARDS:
                    Resultat = "Not implemented";
                    break;
            }
            return Resultat;
        }

        public static bool Base(DonneeEdition donneeEdition)
        {
            switch (donneeEdition.TypeDonnee)
            {
                case DonneeEdition.TYPE_DONNEE.EDITION_NAME:
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_BESTIAIRE:
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_GATHERER:
                case DonneeEdition.TYPE_DONNEE.EDITION_CODE_MTGJSON:
                    return true;
                default:
                    return false;
            }
        }

        protected static string ListToString(List<string> Liste)
        {
            string Resultat = string.Empty;
            if (Liste != null && Liste.Count > 0)
            {
                foreach (string Element in Liste)
                {
                    Resultat += "[" + Element + "]";
                }
            }
            return Resultat;
        }

        protected static string BoosterToString(List<object> Liste)
        {
            string Resultat = string.Empty;
            if (Liste != null && Liste.Count > 0)
            {
                foreach (object Element in Liste)
                {
                    if (Element is string)
                    {
                        Resultat += "[" + Element + "]";
                    }
                    else if (Element is Newtonsoft.Json.Linq.JArray)
                    {
                        Resultat += "[";
                        foreach (var item in ((Newtonsoft.Json.Linq.JArray)Element))
                        {
                            Resultat += "[" + (string)item + "]";
                        }
                        Resultat += "]";
                    }
                }
            }
            return Resultat;
        }

        protected static string ListRulesToString(List<Regle> Liste)
        {
            string Resultat = string.Empty;
            if (Liste != null && Liste.Count > 0)
            {
                foreach (Regle Regle in Liste)
                {
                    Resultat += "[" + Regle.date + " : " + Formattestring(Regle.text) + "]";
                }
            }
            return Resultat;
        }

        protected static string Formattestring(string Element)
        {
            Char RetourLigne = '\n';
            Char RetourLigneBis = '\r';
            string NouveauRetourLigne = "[NewLine]";
            string PointVirgule = ";";
            string NouveauPointVirgule = "[SemiColon]";
            return Element.Replace(RetourLigne.ToString(), NouveauRetourLigne).Replace(RetourLigneBis.ToString(), NouveauRetourLigne).Replace(PointVirgule, NouveauPointVirgule);
        }

        protected static string ExtractForeignName(List<NomEtranger> NomsEtrangers, string Langue)
        {
            string Resultat = string.Empty;
            foreach (NomEtranger NomEtranger in NomsEtrangers)
            {
                if (NomEtranger.language.Equals(Langue))
                {
                    Resultat = NomEtranger.name;
                }
            }
            return Resultat;
        }

        public static List<DonneeEdition> ListeDonneesEditions()
        {
            List<DonneeEdition> Donnes = new List<DonneeEdition>();
            Donnes.Add(new DonneeEdition(DonneeEdition.TYPE_DONNEE.EDITION_NAME));
            Donnes.Add(new DonneeEdition(DonneeEdition.TYPE_DONNEE.EDITION_CODE_BESTIAIRE));
            Donnes.Add(new DonneeEdition(DonneeEdition.TYPE_DONNEE.EDITION_CODE_GATHERER));
            Donnes.Add(new DonneeEdition(DonneeEdition.TYPE_DONNEE.EDITION_CODE_MTGJSON));
            Donnes.Add(new DonneeEdition(DonneeEdition.TYPE_DONNEE.EDITION_RELEASE_DATE));
            Donnes.Add(new DonneeEdition(DonneeEdition.TYPE_DONNEE.EDITION_BORDER));
            Donnes.Add(new DonneeEdition(DonneeEdition.TYPE_DONNEE.EDITION_TYPE));
            Donnes.Add(new DonneeEdition(DonneeEdition.TYPE_DONNEE.EDITION_BOOSTER));
            return Donnes;
        }

        public static List<DonneeEdition> ListDonneesEditions_Filtered()
        {
            return ListeDonneesEditions().Where(donnee => Base(donnee)).ToList();
        }

    }
}
