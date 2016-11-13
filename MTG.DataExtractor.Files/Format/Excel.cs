using System;
using System.Collections.Generic;
using MTG.DataExtractor.Objects;
using MTG.DataExtractor.Objects.Managers;
using MTGRessources = MTG.DataExtractor.Ressources;

namespace MTG.DataExtractor.Files.Format
{
    public class Excel
    {

        public static string GenererExcel_EnTete(List<DonneeEdition> ListeDonneesEdition, List<DonneeCarte> ListeDonneesCarte)
        {			
            
            string Excel = string.Empty;
			bool bFirst = true;

            foreach (DonneeEdition Donnee in ListeDonneesEdition)
            {
                if (bFirst)
                    bFirst = false;
                else
                    Excel += ";";
                Excel += string.Format("[{0}]", ManageDonneeEdition.ID(Donnee));
            }
            foreach (DonneeCarte Donnee in ListeDonneesCarte)
            {
                if (bFirst)
                    bFirst = false;
                else
                    Excel += ";";
                Excel += string.Format("[{0}]", ManageDonneeCarte.ID(Donnee));
            }

            return Excel;
        }

        public static string GenererExcel_Ligne(EditionCartes Edition, Carte Carte, List<DonneeEdition> ListeDonneesEdition, List<DonneeCarte> ListeDonneesCarte)
        {

            string Excel = System.Environment.NewLine;
            bool bFirst = true;

            foreach (DonneeEdition Donnee in ListeDonneesEdition)
            {
                if (bFirst)
                    bFirst = false;
                else
                    Excel += ";";
                Excel += ManageDonneeEdition.Value(Donnee, Edition);
            }
            foreach (DonneeCarte Donnee in ListeDonneesCarte)
            {
                if (bFirst)
                    bFirst = false;
                else
                    Excel += ";";
                Excel += ManageDonneeCarte.Value(Carte, Edition, Donnee, true);
            }

            return Excel;

        }

        public static string GenererExcel_Ligne(EditionCartes_X Edition, Carte_X Carte, List<DonneeEdition> ListeDonneesEdition, List<DonneeCarte> ListeDonneesCarte)
        {

            string Excel = System.Environment.NewLine;
            bool bFirst = true;

            foreach (DonneeEdition Donnee in ListeDonneesEdition)
            {
                if (bFirst)
                    bFirst = false;
                else
                    Excel += ";";
                Excel += ManageDonneeEdition.Value(Donnee, Edition);
            }
            foreach (DonneeCarte Donnee in ListeDonneesCarte)
            {
                if (bFirst)
                    bFirst = false;
                else
                    Excel += ";";
                Excel += ManageDonneeCarte.Value(Carte, Edition, Donnee, true);
            }

            return Excel;

        }

        public static string GenererExcel(EditionCartes Edition, List<DonneeEdition> ListeDonneesEdition, List<DonneeCarte> ListeDonneesCarte)
        {

            string Excel = GenererExcel_EnTete(ListeDonneesEdition, ListeDonneesCarte);

			foreach (Carte Carte in Edition.cards)
			{
                Excel += GenererExcel_Ligne(Edition, Carte, ListeDonneesEdition, ListeDonneesCarte);
			}

			return Excel;
        }

        public static string GenererExcel(EditionCartes_X Edition, List<DonneeEdition> ListeDonneesEdition, List<DonneeCarte> ListeDonneesCarte)
        {

            string Excel = GenererExcel_EnTete(ListeDonneesEdition, ListeDonneesCarte);

            foreach (Carte_X Carte in Edition.cards)
            {
                Excel += GenererExcel_Ligne(Edition, Carte, ListeDonneesEdition, ListeDonneesCarte);
            }

            return Excel;
        }

        public static string DEBUG_EDITIONS_GenererExcel(List<Edition> Editions)
        {

            string Excel = string.Empty;

            List<string> EditionsBestiaire = MTGRessources.Ressources.ListeEditionsBestiaire;
            int iNumero = 1;
            Excel = "N°;Nom;ID MtgJson; ID Bestiaire;ID Gatherer";

            foreach (Edition Edition in Editions)
            {
                Excel += System.Environment.NewLine;
                Excel += iNumero;
                Excel += ";";
                Excel += Edition.name;
                Excel += ";";
                Excel += Edition.code;
                Excel += ";";
                Excel += EditionsBestiaire.Contains(MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_BestiaireID(Edition.code))? MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_GathererID(Edition.code) : "";
                Excel += ";";
                Excel += EditionsBestiaire.Contains(MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_BestiaireID(Edition.code))? MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_BestiaireID(Edition.code) : "";
                iNumero++;
            }

            return Excel;
        }
        
    }
}
