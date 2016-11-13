using System;

namespace Objects.Bestiaire
{
	public class ManagerEdition
	{

		public static string GetEditionCodeMtgJson(string editionCodeBestiaire)
		{
			var code = editionCodeBestiaire;
			code = code.ToUpper() == "A" ? "LEA" : code;
			code = code.ToUpper() == "B" ? "LEB" : code;
			code = code.ToUpper() == "AN" ? "ARN" : code;
			code = code.ToUpper() == "U" ? "2ED" : code;
			code = code.ToUpper() == "AQ" ? "ATQ" : code;
			code = code.ToUpper() == "R" ? "3ED" : code;
			code = code.ToUpper() == "LG" ? "LEG" : code;
			code = code.ToUpper() == "DK" ? "DRK" : code;
			code = code.ToUpper() == "FE" ? "FEM" : code;
			code = code.ToUpper() == "4E" ? "4ED" : code;
			code = code.ToUpper() == "IA" ? "ICE" : code;
			code = code.ToUpper() == "CH" ? "CHR" : code;
			code = code.ToUpper() == "HL" ? "HML" : code;
			code = code.ToUpper() == "AL" ? "ALL" : code;
			code = code.ToUpper() == "MI" ? "MIR" : code;
			code = code.ToUpper() == "VI" ? "VIS" : code;
			code = code.ToUpper() == "5E" ? "5ED" : code;
			code = code.ToUpper() == "PT" ? "POR" : code;
			code = code.ToUpper() == "WE" ? "WTH" : code;
			code = code.ToUpper() == "TP" ? "TMP" : code;
			code = code.ToUpper() == "ST" ? "STH" : code;
			code = code.ToUpper() == "P2" ? "PO2" : code;
			code = code.ToUpper() == "EX" ? "EXO" : code;
			code = code.ToUpper() == "UG" ? "UGL" : code;
			code = code.ToUpper() == "US" ? "USG" : code;
			code = code.ToUpper() == "UL" ? "ULG" : code;
			code = code.ToUpper() == "6E" ? "6ED" : code;
			code = code.ToUpper() == "P3" ? "PTK" : code;
			code = code.ToUpper() == "UD" ? "UDS" : code;
			code = code.ToUpper() == "P4" ? "S99" : code;
			code = code.ToUpper() == "MM" ? "MMQ" : code;
			code = code.ToUpper() == "BR" ? "BRB" : code;
			code = code.ToUpper() == "NE" ? "NMS" : code;
			code = code.ToUpper() == "PY" ? "PCY" : code;
			code = code.ToUpper() == "IN" ? "INV" : code;
			code = code.ToUpper() == "PS" ? "PLS" : code;
			code = code.ToUpper() == "7E" ? "7ED" : code;
			code = code.ToUpper() == "AP" ? "APC" : code;
			code = code.ToUpper() == "OD" ? "ODY" : code;
			code = code.ToUpper() == "TO" ? "TOR" : code;
			code = code.ToUpper() == "JU" ? "JUD" : code;
			code = code.ToUpper() == "ON" ? "ONS" : code;
			code = code.ToUpper() == "LE" ? "LGN" : code;
			code = code.ToUpper() == "SC" ? "SCG" : code;
			code = code.ToUpper() == "8E" ? "8ED" : code;
			code = code.ToUpper() == "MR" ? "MRD" : code;
			code = code.ToUpper() == "DS" ? "DST" : code;
			code = code.ToUpper() == "FD" ? "5DN" : code;
			code = code.ToUpper() == "UHN" ? "UNH" : code;
			code = code.ToUpper() == "9E" ? "9ED" : code;
			code = code.ToUpper() == "GP" ? "GPT" : code;
			code = code.ToUpper() == "CS" ? "CSP" : code;
			code = code.ToUpper() == "TSP" ? "TSP" : code;
			code = code.ToUpper() == "TSP" ? "TSB" : code;
			code = code.ToUpper() == "PC" ? "PLC" : code;
			code = code.ToUpper() == "LOR" ? "LRW" : code;
			code = code.ToUpper() == "CFX" ? "CON" : code;
			code = code.ToUpper() == "REB" ? "ARB" : code;
			code = code.ToUpper() == "MOM" ? "MMA" : code;
			return code;
		}

	}
}

