using System;
using System.Collections.Generic;

namespace MTG.DataExtractor.Ressources
{
    public class Ressources
    {

        public static List<string> ListeIcones = new List<string>
        {
            //"0",
            //"1",
            //"2",
            //"3",
            //"4",
            //"5",
            //"6",
            //"7",
            //"8",
            //"9",
            //"10",
            //"11",
            //"12",
            //"13",
            //"14",
            //"15",
            //"16",
            //"17",
            //"18",
            //"19",
            //"20",
            //"100",
            //"1000000",
            //"w",
            //"u",
            //"b",
            //"r",
            //"g",
            //"s",
            //"x",
            //"y",
            //"z",
            //"wu",
            //"wb",
            //"ub",
            //"ur",
            //"br",
            //"bg",
            //"rg",
            //"rw",
            //"gw",
            //"gu",
            //"2w",
            //"2u",
            //"2b",
            //"2r",
            //"2g",
            //"p",
            //"pw",
            //"pu",
            //"pb",
            //"pr",
            //"pg",
            //"wp",
            //"up",
            //"bp",
            //"rp",
            //"gp",
            //"∞",
            //"h",
            //"hw",
            //"hu",
            //"hb",
            //"hr",
            //"hg",
            //"t",
            //"q",
            //"artifact",
            //"creature",
            //"enchantment",
            //"instant",
            //"land",
            //"multiple",
            //"planeswalker",
            //"sorcery",
            //"power",
            //"toughness",
            //"chaosdice",
            //"planeswalk",
            //"forwardslash",
            "wp",
            "up",
            "bp",
            "rp",
            "gp",
            "pw",
            "pu",
            "pb",
            "pr",
            "pg"
        };

        public static List<string> ListeIconesOthers = new List<string>
        {
            "t",
            "q",
            "artifact",
            "creature",
            "enchantment",
            "instant",
            "land",
            "multiple",
            "planeswalker",
            "sorcery",
            "power",
            "toughness",
            "chaosdice",
            "planeswalk",
            "forwardslash"
        };

        public static List<string> ListeEditionsBestiaire = new List<string>
        {
            "ORI",
            "MM2",
            "M15",
            "JOU",
            "BNG",
            "THS",
            "M14",
            "MOM",
            "DGM",
            "GTC",
            "RTR",
            "M13",
            "AVR",
            "DKA",
            "ISD",
            "M12",
            "NPH",
            "MBS",
            "SOM",
            "M11",
            "ROE",
            "WWK",
            "ZEN",
            "ME3",
            "M10",
            "REB",
            "CFX",
            "ALA",
            "EVE",
            "SHM",
            "MOR",
            "LOR",
            "10E",
            "FUT",
            "PC",
            "TSB",
            "TSP",
            "CS",
            "DIS",
            "GP",
            "RAV",
            "9E",
            "SOK",
            "BOK",
            "CHK",
            "UNH",
            "FD",
            "DS",
            "MR",
            "8E",
            "SC",
            "LE",
            "ON",
            "JU",
            "TO",
            "OD",
            "7E",
            "AP",
            "PS",
            "IN",
            "PY",
            "NE",
            "MM",
            "6E",
            "UD",
            "UL",
            "US",
            "EX",
            "ST",
            "TP",
            "5E",
            "WE",
            "VI",
            "MI",
            "AL",
            "HL",
            "IA",
            "4E",
            "FE",
            "DK",
            "LG",
            "R",
            "AQ",
            "AN",
            "U",
            "B",
            "A",
            "UHN",
            "UG",
            "CH",
            //"CUB",
            //"CU2",
            "BR",
            "BD",
            "P4",
            "P3",
            "P2",
            "PT"
        };

        public static string ConversionEditionID_MTGJSON_To_GathererID(string EditionID)
        {
            switch (EditionID.ToUpper())
            {
                case "MOR":
                    EditionID = "MT";
                    break;
                case "TSP":
                    EditionID = "TS";
                    break;
                case "MRD":
                    EditionID = "MI";
                    break;
                case "LGN":
                    EditionID = "LE";
                    break;
                case "ODY":
                    EditionID = "OD";
                    break;
                case "APC":
                    EditionID = "AP";
                    break;
                case "PLS":
                    EditionID = "PS";
                    break;
                case "INV":
                    EditionID = "IN";
                    break;
                case "PCY":
                    EditionID = "PR";
                    break;
                case "NMS":
                    EditionID = "NE";
                    break;
                case "MMQ":
                    EditionID = "MM";
                    break;
                case "UDS":
                    EditionID = "UD";
                    break;
                case "ULG":
                    EditionID = "UL";
                    break;
                case "USG":
                    EditionID = "US";
                    break;
                case "EXO":
                    EditionID = "EX";
                    break;
                case "STH":
                    EditionID = "SH";
                    break;
                case "TMP":
                    EditionID = "TP";
                    break;
                case "WTH":
                    EditionID = "WL";
                    break;
                case "VIS":
                    EditionID = "VI";
                    break;
                case "MIR":
                    EditionID = "MR";
                    break;
                case "ALL":
                    EditionID = "AI";
                    break;
                case "HML":
                    EditionID = "HL";
                    break;
                case "ICE":
                    EditionID = "IA";
                    break;
                case "FEM":
                    EditionID = "FE";
                    break;
                case "DRK":
                    EditionID = "DK";
                    break;
                case "LEG":
                    EditionID = "LG";
                    break;
                case "3ED":
                    EditionID = "RV";
                    break;
                case "ATQ":
                    EditionID = "AQ";
                    break;
                case "ARN":
                    EditionID = "AN";
                    break;
                case "2ED":
                    EditionID = "UN";
                    break;
                case "LEB":
                    EditionID = "BE";
                    break;
                case "LEA":
                    EditionID = "AL";
                    break;
                case "UHN":
                    EditionID = "UNH";
                    break;
                case "UGL":
                    EditionID = "UG";
                    break;
                case "CHR":
                    EditionID = "CH";
                    break;
                case "BRB":
                    EditionID = "BR";
                    break;
                case "BTD":
                    EditionID = "BD";
                    break;
                case "S99":
                    EditionID = "P4";
                    break;
                case "PTK":
                    EditionID = "PK";
                    break;
                case "PO2":
                    EditionID = "P2";
                    break;
                case "POR":
                    EditionID = "PO";
                    break;
            }
            return EditionID;
        }

        public static string ConversionEditionID_MTGJSON_To_BestiaireID(string EditionID)
        {
            switch (EditionID.ToUpper())
            {
                case "MMA":
                    EditionID = "MOM";
                    break;
                case "ARB":
                    EditionID = "REB";
                    break;
                case "CON":
                    EditionID = "CFX";
                    break;
                case "LRW":
                    EditionID = "LOR";
                    break;
                case "PLC":
                    EditionID = "PC";
                    break;
                case "CSP":
                    EditionID = "CS";
                    break;
                case "GPT":
                    EditionID = "GP";
                    break;
                case "9ED":
                    EditionID = "9E";
                    break;
                case "UNH":
                    EditionID = "UHN";
                    break;
                case "5DN":
                    EditionID = "FD";
                    break;
                case "DST":
                    EditionID = "DS";
                    break;
                case "MRD":
                    EditionID = "MR";
                    break;
                case "8ED":
                    EditionID = "8E";
                    break;
                case "SCG":
                    EditionID = "SC";
                    break;
                case "LGN":
                    EditionID = "LE";
                    break;
                case "ONS":
                    EditionID = "ON";
                    break;
                case "JUD":
                    EditionID = "JU";
                    break;
                case "TOR":
                    EditionID = "TO";
                    break;
                case "ODY":
                    EditionID = "OD";
                    break;
                case "7ED":
                    EditionID = "7E";
                    break;
                case "APC":
                    EditionID = "AP";
                    break;
                case "PLS":
                    EditionID = "PS";
                    break;
                case "INV":
                    EditionID = "IN";
                    break;
                case "PCY":
                    EditionID = "PY";
                    break;
                case "NMS":
                    EditionID = "NE";
                    break;
                case "MMQ":
                    EditionID = "MM";
                    break;
                case "6ED":
                    EditionID = "6E";
                    break;
                case "UDS":
                    EditionID = "UD";
                    break;
                case "ULG":
                    EditionID = "UL";
                    break;
                case "USG":
                    EditionID = "US";
                    break;
                case "EXO":
                    EditionID = "EX";
                    break;
                case "STH":
                    EditionID = "ST";
                    break;
                case "TMP":
                    EditionID = "TP";
                    break;
                case "5ED":
                    EditionID = "5E";
                    break;
                case "WTH":
                    EditionID = "WE";
                    break;
                case "VIS":
                    EditionID = "VI";
                    break;
                case "MIR":
                    EditionID = "MI";
                    break;
                case "ALL":
                    EditionID = "AL";
                    break;
                case "HML":
                    EditionID = "HL";
                    break;
                case "ICE":
                    EditionID = "IA";
                    break;
                case "4ED":
                    EditionID = "4E";
                    break;
                case "FEM":
                    EditionID = "FE";
                    break;
                case "DRK":
                    EditionID = "DK";
                    break;
                case "LEG":
                    EditionID = "LG";
                    break;
                case "3ED":
                    EditionID = "R";
                    break;
                case "ATQ":
                    EditionID = "AQ";
                    break;
                case "ARN":
                    EditionID = "AN";
                    break;
                case "2ED":
                    EditionID = "U";
                    break;
                case "LEB":
                    EditionID = "B";
                    break;
                case "LEA":
                    EditionID = "A";
                    break;
                case "UGL":
                    EditionID = "UG";
                    break;
                case "CHR":
                    EditionID = "CH";
                    break;
                case "BRB":
                    EditionID = "BR";
                    break;
                case "BTD":
                    EditionID = "BD";
                    break;
                case "S99":
                    EditionID = "P4";
                    break;
                case "PTK":
                    EditionID = "P3";
                    break;
                case "PO2":
                    EditionID = "P2";
                    break;
                case "POR":
                    EditionID = "PT";
                    break;
            }
            return EditionID;
        }

        /*
        public static List<string> ListeEditions()
        {
            List<string> Editions = new List<string>();
            Editions.Add("M15");
            Editions.Add("AL");
            Editions.Add("ZEN");
            Editions.Add("ROE");
            Editions.Add("ME3");
            Editions.Add("CG");
            Editions.Add("GU");
            Editions.Add("UZ");
            Editions.Add("TE");
            Editions.Add("ST");
            Editions.Add("AL");
            Editions.Add("IA");
            Editions.Add("HM");
            Editions.Add("1E");
            Editions.Add("2E");
            Editions.Add("2U");
            Editions.Add("3E");
            Editions.Add("PO");
            Editions.Add("P2");
            Editions.Add("PK");
            Editions.Add("UG");
            Editions.Add("UNH");
            Editions.Add("P3");
            Editions.Add("P4");
            Editions.Add("BD");
            Editions.Add("BR");
            Editions.Add("LGN");
            Editions.Add("MRD");
            Editions.Add("CON");
            Editions.Add("MOR");
            Editions.Add("LRW");
            Editions.Add("PLC");
            Editions.Add("CSP");
            Editions.Add("GPT");
            Editions.Add("8ED");
            Editions.Add("9ED");
            Editions.Add("DIS");
            Editions.Add("DST");
            Editions.Add("JUD");
            Editions.Add("TOR");
            Editions.Add("ONS");
            Editions.Add("SCG");
            Editions.Add("TSP");
            Editions.Add("10E");
            Editions.Add("4E");
            Editions.Add("5E");
            Editions.Add("6E");
            Editions.Add("7E");
            Editions.Add("8ED");
            Editions.Add("9ED");
            Editions.Add("AI");
            Editions.Add("AL");
            Editions.Add("ALA");
            Editions.Add("AN");
            Editions.Add("AP");
            Editions.Add("AQ");
            Editions.Add("AVR");
            Editions.Add("BE");
            Editions.Add("BNG");
            Editions.Add("BOK");
            Editions.Add("CON");
            Editions.Add("CH");
            Editions.Add("CHK");
            Editions.Add("CSP");
            Editions.Add("DGM");
            Editions.Add("DI");
            Editions.Add("DK");
            Editions.Add("DKA");
            Editions.Add("DIS");
            Editions.Add("DST");
            Editions.Add("EVE");
            Editions.Add("EX");
            Editions.Add("5DN");
            Editions.Add("FE");
            Editions.Add("FUT");
            Editions.Add("GPT");
            Editions.Add("GTC");
            Editions.Add("HL");
            Editions.Add("IN");
            Editions.Add("ISD");
            Editions.Add("JOU");
            Editions.Add("JUD");
            Editions.Add("LE");
            Editions.Add("LG");
            Editions.Add("LRW");
            Editions.Add("M10");
            Editions.Add("M11");
            Editions.Add("M12");
            Editions.Add("M13");
            Editions.Add("M14");
            Editions.Add("MBS");
            Editions.Add("MI");
            Editions.Add("MOR");
            Editions.Add("MR");
            Editions.Add("MM");
            Editions.Add("MMA");
            Editions.Add("MT");
            Editions.Add("NE");
            Editions.Add("NPH");
            Editions.Add("OD");
            Editions.Add("ONS");
            Editions.Add("PLC");
            Editions.Add("PS");
            Editions.Add("PR");
            Editions.Add("RV");
            Editions.Add("RAV");
            Editions.Add("ARB");
            Editions.Add("ROE");
            Editions.Add("RTR");
            Editions.Add("SCG");
            Editions.Add("SHM");
            Editions.Add("SOK");
            Editions.Add("SOM");
            Editions.Add("SH");
            Editions.Add("THS");
            Editions.Add("TOR");
            Editions.Add("TP");
            Editions.Add("TSP");
            Editions.Add("UN");
            Editions.Add("UD");
            Editions.Add("UG");
            Editions.Add("UL");
            Editions.Add("US");
            Editions.Add("VI");
            Editions.Add("WL");
            Editions.Add("WWK");
            Editions.Add("ZEN");
            return Editions;
        }
        */

        /*
        public static string ConversionEditionID_BestiaireID(string EditionID)
        {
            switch (EditionID)
            {
                case "P3":
                    EditionID = "PK";
                    break;
                case "PK":
                    EditionID = "P3";
                    break;
                case "TE":
                    EditionID = "TP";
                    break;
                case "HM":
                    EditionID = "HL";
                    break;
                case "1E":
                    EditionID = "A";
                    break;
                case "2E":
                    EditionID = "B";
                    break;
                case "2U":
                    EditionID = "U";
                    break;
                case "3E":
                    EditionID = "R";
                    break;
                case "PO":
                    EditionID = "PT";
                    break;
                case "CG":
                    EditionID = "UD";
                    break;
                case "GU":
                    EditionID = "UL";
                    break;
                case "UZ":
                    EditionID = "US";
                    break;
                case "UNH":
                    EditionID = "UHN";
                    break;
                case "5DN":
                    EditionID = "FD";
                    break;
                case "8ED":
                    EditionID = "8E";
                    break;
                case "9ED":
                    EditionID = "9E";
                    break;
                case "AI":
                    EditionID = "AL";
                    break;
                case "CON":
                    EditionID = "CFX";
                    break;
                case "CSP":
                    EditionID = "CS";
                    break;
                case "DST":
                    EditionID = "DS";
                    break;
                case "GPT":
                    EditionID = "GP";
                    break;
                case "JUD":
                    EditionID = "JU";
                    break;
                case "LGN":
                    EditionID = "LE";
                    break;
                case "LRW":
                    EditionID = "LOR";
                    break;
                case "MRD":
                    EditionID = "MR";
                    break;
                case "MR":
                    EditionID = "MI";
                    break;
                case "MMA":
                    EditionID = "MoM";
                    break;
                case "MT":
                    EditionID = "MOR";
                    break;
                case "ONS":
                    EditionID = "ON";
                    break;
                case "PLC":
                    EditionID = "PC";
                    break;
                case "PR":
                    EditionID = "PY";
                    break;
                case "RV":
                    EditionID = "R";
                    break;
                case "ARB":
                    EditionID = "REB";
                    break;
                case "SH":
                    EditionID = "ST";
                    break;
                case "SCG":
                    EditionID = "SC";
                    break;
                case "TOR":
                    EditionID = "TO";
                    break;
                case "UN":
                    EditionID = "U";
                    break;
                case "WL":
                    EditionID = "WE";
                    break;
            }
            return EditionID;
        }
        */

        public static List<string> Manas = new List<string>
        {
            "W",
            "B",
            "U",
            "R",
            "G",
            "X",
            "P",
            "SI",
            "WB",
            "WU",
            "BR",
            "BG",
            "UB",
            "UR",
            "RW",
            "RG",
            "GW",
            "GU",
            "WP",
            "BP",
            "UP",
            "RP",
            "GP",
            "2W",
            "2U",
            "2B",
            "2R",
            "2G",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "P",
            "snow"
        };

        public static List<string> ListeRaretes = new List<string>
        {
            "C",
            "U",
            "R",
            "M",
            "S"
        };

        static List<string> ListeIconesAutres = new List<string>
        {
            "tap",
            "untap"
        };

    }
}
