using System;
using System.Collections.Generic;
using MTG.DataExtractor.Objects;
using MTG.DataExtractor.Objects.Managers;

namespace MTG.DataExtractor.Files.Format
{
    public class Json
    {
        public static string GenererJSON(EditionCartes_X Edition, List<DonneeEdition> ListeDonneesEdition, List<DonneeCarte> ListeDonneesCarte)
        {
            string JSON = string.Empty;
            bool bDonneeEditionFirst = true;
            bool bFirstCarte = true;

            bDonneeEditionFirst = true;
            foreach (DonneeEdition Donnee in ListeDonneesEdition)
            {
                if (bDonneeEditionFirst)
                    bDonneeEditionFirst = false;
                else
                    JSON += ",";
                if (Donnee.TypeDonnee != DonneeEdition.TYPE_DONNEE.EDITION_BOOSTER)
                    JSON += @"""" + ManageDonneeEdition.JSON_ID(Donnee) + @""":""" + ManageDonneeEdition.Value(Donnee, Edition) + @"""";
                else
                    JSON += @"""" + ManageDonneeEdition.JSON_ID(Donnee) + @""":[" + BoosterToString(Edition.booster) + "]";
            }
            if (!bDonneeEditionFirst)
                JSON += ",";
            JSON += @"""cards"":[";
            foreach (Carte_X Carte in Edition.cards)
            {
                bool bDonneeCarteFirst = true;
                List<DonneeCarte> ListeNomsEtrangers = new List<DonneeCarte>();
                List<DonneeCarte> ListeLegalites = new List<DonneeCarte>();
                if (bFirstCarte)
                    bFirstCarte = false;
                else
                    JSON += ",";
                JSON += "{";
                foreach (DonneeCarte Donnee in ListeDonneesCarte)
                {
                    switch (Donnee.TypeDonnee)
                    {
                        case DonneeCarte.TYPE_DONNEE.CARD_TYPES:
                        case DonneeCarte.TYPE_DONNEE.CARD_SUBTYPES:
                        case DonneeCarte.TYPE_DONNEE.CARD_SUPERTYPES:
                        case DonneeCarte.TYPE_DONNEE.CARD_COLORS:
                        case DonneeCarte.TYPE_DONNEE.CARD_VARIATIONS:
                        case DonneeCarte.TYPE_DONNEE.CARD_NAMES:
                        case DonneeCarte.TYPE_DONNEE.CARD_PRINTINGS:
                            if (bDonneeCarteFirst)
                                bDonneeCarteFirst = false;
                            else
                                JSON += ",";
                            JSON += @"""" + ManageDonneeCarte.JSON_ID(Donnee) + @""":" + ListToString(Carte, Donnee.TypeDonnee);
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_RULINGS:
                            if (bDonneeCarteFirst)
                                bDonneeCarteFirst = false;
                            else
                                JSON += ",";
                            JSON += @"""" + ManageDonneeCarte.JSON_ID(Donnee) + @""":" + ListRulingsToString(Carte.rulings);
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_COMMANDER:
                            ListeLegalites.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_COMMANDER));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_FREEFORM:
                            ListeLegalites.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_FREEFORM));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_LEGACY:
                            ListeLegalites.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_LEGACY));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_MODERN:
                            ListeLegalites.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_MODERN));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_PRISMATIC:
                            ListeLegalites.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_PRISMATIC));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_SINGLETON_100:
                            ListeLegalites.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_SINGLETON_100));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_STANDARD:
                            ListeLegalites.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_STANDARD));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_LEGACY:
                            ListeLegalites.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_LEGACY));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_STANDARD:
                            ListeLegalites.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_STANDARD));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_VINTAGE:
                            ListeLegalites.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_VINTAGE));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_SIMPLIFIED:
                            ListeNomsEtrangers.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_SIMPLIFIED));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_TRADITIONAL:
                            ListeNomsEtrangers.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_TRADITIONAL));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_FRENCH:
                            ListeNomsEtrangers.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_FRENCH));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_GERMAN:
                            ListeNomsEtrangers.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_GERMAN));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_ITALIAN:
                            ListeNomsEtrangers.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_ITALIAN));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_JAPANESE:
                            ListeNomsEtrangers.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_JAPANESE));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_KOREAN:
                            ListeNomsEtrangers.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_KOREAN));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE:
                            ListeNomsEtrangers.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE_BRAZIL:
                            ListeNomsEtrangers.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE_BRAZIL));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_RUSSIAN:
                            ListeNomsEtrangers.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_RUSSIAN));
                            break;
                        case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_SPANISH:
                            ListeNomsEtrangers.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_SPANISH));
                            break;
                        default:
                            if (bDonneeCarteFirst)
                                bDonneeCarteFirst = false;
                            else
                                JSON += ",";
                            JSON += @"""" + ManageDonneeCarte.JSON_ID(Donnee) + @""":""" + ManageDonneeCarte.Value(Carte, Edition, Donnee, false) + @"""";
                            break;
                    }
                    //JSON += @"""" + Donnee.JSON_ID + @""":""" + Donnee.JSON_Value(Edition) + @"""";
                }
                if (ListeLegalites.Count > 0)
                {                    
                    if (bDonneeCarteFirst)
                        bDonneeCarteFirst = false;
                    else
                        JSON += ",";
                    DonneeCarte DonneLegalite = new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY);
                    JSON += @"""" + ManageDonneeCarte.JSON_ID(DonneLegalite) + @""":""" + "TO FINISH"; //ListLegalitiesToString(Carte.legalities, ListeLegalites);
                }
                if (ListeNomsEtrangers.Count > 0)
                {
                    if (bDonneeCarteFirst)
                        bDonneeCarteFirst = false;
                    else
                        JSON += ",";
                    DonneeCarte DonneNomsEtrangers = new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME);
                    JSON += @"""" + ManageDonneeCarte.JSON_ID(DonneNomsEtrangers) + @""":""" + ListForeignNamesToString(Carte.foreignNames, ListeNomsEtrangers);
                }
                JSON += "}";
            }
            JSON += "]";

            JSON = "{" + JSON + "}";

            return JSON;
        }

        protected static string BoosterToString(List<object> ContenuBooster)
        {
            string Booster = string.Empty;
            if (ContenuBooster != null && ContenuBooster.Count > 0)
            {
                bool bFirstCarte = true;
                foreach (object Element in ContenuBooster)
                {
                    if (bFirstCarte)
                        bFirstCarte = false;
                    else
                        Booster += ",";
                    if (Element is string)
                    {
                        Booster += @"""" + Element + @"""";
                    }
                    else if (Element is Newtonsoft.Json.Linq.JArray)
                    {
                        Booster += "[";
                        bool bFirst = true;
                        foreach (var item in ((Newtonsoft.Json.Linq.JArray)Element))
                        {
                            if (bFirst)
                                bFirst = false;
                            else
                                Booster += ",";
                            Booster += @"""" + (string)item + @"""";
                        }
                        Booster += "]";
                    }
                }
            }
            return Booster;
        }

        protected static string ListToString(Carte_X Carte, DonneeCarte.TYPE_DONNEE TypeDonnee)
        {
            string JSON = string.Empty;
            List<string> Liste = new List<string>();
            switch (TypeDonnee)
            {
                case DonneeCarte.TYPE_DONNEE.CARD_TYPES:
                    Liste = Carte.types;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_SUBTYPES:
                    Liste = Carte.subtypes;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_SUPERTYPES:
                    Liste = Carte.supertypes;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_COLORS:
                    Liste = Carte.colors;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_VARIATIONS:
                    Liste = Carte.variations;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_NAMES:
                    Liste = Carte.names;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_PRINTINGS:
                    Liste = Carte.printings;
                    break;
                default:
                    Liste = new List<string>();
                    break;
            }
            if (Liste.Count > 0)
            {
                bool bFirst = true;
                foreach (string Element in Liste)
                {
                    if (bFirst)
                        bFirst = false;
                    else
                        JSON += ",";
                    JSON += @"""" + Element + @"""";
                }
            }
            JSON = "[" + JSON + "]";
            return JSON;
        }

        protected static string ListRulingsToString(List<Regle> Regles)
        {
            string JSON = string.Empty;
            if (Regles.Count > 0)
            {
                bool bFirst = true;
                foreach (Regle Element in Regles)
                {
                    if (bFirst)
                        bFirst = false;
                    else
                        JSON += ",";
                    JSON += @"{""date"":""" + Element.date + @""",""text"":" + Element.text + @"""}";
                }
            }
            JSON = "[" + JSON + "]";
            return JSON;
        }

        protected static string ListLegalitiesToString(Legalite Legalite, List<DonneeCarte> ListeLegalites)
        {
            string JSON = string.Empty;
            List<string> Liste = new List<string>();
            bool bFirst = true;
            foreach (DonneeCarte TypeLegalite in ListeLegalites)
            {
                if (bFirst)
                    bFirst = false;
                else
                    JSON += ",";
                switch (TypeLegalite.TypeDonnee)
                {
                    case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_COMMANDER:
                        JSON += @"""" + ManageDonneeCarte.JSON_ID(TypeLegalite) + @""":""" + Legalite.Commander + @"""";
                        break;
                    case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_FREEFORM:
                        JSON += @"""" + ManageDonneeCarte.JSON_ID(TypeLegalite) + @""":""" + Legalite.Freeform + @"""";
                        break;
                    case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_LEGACY:
                        JSON += @"""" + ManageDonneeCarte.JSON_ID(TypeLegalite) + @""":""" + Legalite.Legacy + @"""";
                        break;
                    case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_MODERN:
                        JSON += @"""" + ManageDonneeCarte.JSON_ID(TypeLegalite) + @""":""" + Legalite.Modern + @"""";
                        break;
                    case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_PRISMATIC:
                        JSON += @"""" + ManageDonneeCarte.JSON_ID(TypeLegalite) + @""":""" + Legalite.Prismatic + @"""";
                        break;
                    case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_SINGLETON_100:
                        JSON += @"""" + ManageDonneeCarte.JSON_ID(TypeLegalite) + @""":""" + Legalite.Singleton100 + @"""";
                        break;
                    case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_STANDARD:
                        JSON += @"""" + ManageDonneeCarte.JSON_ID(TypeLegalite) + @""":""" + Legalite.Standard + @"""";
                        break;
                    case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_LEGACY:
                        JSON += @"""" + ManageDonneeCarte.JSON_ID(TypeLegalite) + @""":""" + Legalite.TribalWarsLegacy + @"""";
                        break;
                    case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_STANDARD:
                        JSON += @"""" + ManageDonneeCarte.JSON_ID(TypeLegalite) + @""":""" + Legalite.TribalWarsStandard + @"""";
                        break;
                    case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_VINTAGE:
                        JSON += @"""" + ManageDonneeCarte.JSON_ID(TypeLegalite) + @""":""" + Legalite.Vintage + @"""";
                        break;
                }
            }
            JSON = "[" + JSON + "]";
            return JSON;
        }

        protected static string ListForeignNamesToString(List<NomEtranger> NomsEtrangers, List<DonneeCarte> ListeNomsEtrangers)
        {
            string JSON = string.Empty;
            List<string> Liste = new List<string>();
            bool bFirst = true;
            foreach (DonneeCarte TypeNomEtranger in ListeNomsEtrangers)
            {
                if (bFirst)
                    bFirst = false;
                else
                    JSON += ",";
                JSON += @"{""language"":""" + ManageDonneeCarte.JSON_ID(TypeNomEtranger) + @""",""name"":""" + ExtractForeignName(NomsEtrangers, TypeNomEtranger) + @"""}";
            }
            JSON = "[" + JSON + "]";
            return JSON;
        }

        protected static string ExtractForeignName(List<NomEtranger> NomsEtrangers, DonneeCarte Langue)
        {
            string Resultat = string.Empty;
            foreach (NomEtranger NomEtranger in NomsEtrangers)
            {
                if (NomEtranger.language.Equals(ManageDonneeCarte.JSON_ID(Langue)))
                {
                    Resultat = NomEtranger.name;
                }
            }
            return Resultat;
        }
    }

}
