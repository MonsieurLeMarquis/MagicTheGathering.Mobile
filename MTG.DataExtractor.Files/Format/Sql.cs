using System;
using MTG.DataExtractor.Objects;
using MTGRessources = MTG.DataExtractor.Ressources;

namespace MTG.DataExtractor.Files.Format
{
    public class Sql
    {

        public static string ModeEmploi()
        {
            string SQL = string.Empty;

            SQL += "Le modèle de script est utilisé pour chaque carte de l'édition traitée.";
            SQL += System.Environment.NewLine;
            SQL += System.Environment.NewLine;
            SQL += @"La liste des ""marqueurs"" qui seront automatiquement remplacés lors de la génération du script SQL :";
            SQL += System.Environment.NewLine;
            SQL += "    	[EDITION_NAME]";
            SQL += System.Environment.NewLine;
            SQL += "    	[EDITION_CODE_BESTIAIRE]";
            SQL += System.Environment.NewLine;
            SQL += "    	[EDITION_CODE_GATHERER]";
            SQL += System.Environment.NewLine;
            SQL += "    	[EDITION_CODE_MTGJSON]";
            SQL += System.Environment.NewLine;
            SQL += "    	[EDITION_RELEASE_DATE]";
            SQL += System.Environment.NewLine;
            SQL += "    	[EDITION_BORDER]";
            SQL += System.Environment.NewLine;
            SQL += "    	[EDITION_TYPE]";
            SQL += System.Environment.NewLine;
            SQL += "    	[EDITION_BOOSTER]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_NAME]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_NAMES]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_FOREIGN_NAME_CHINESE_TRADITIONAL]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_FOREIGN_NAME_CHINESE_SIMPLIFIED]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_FOREIGN_NAME_FRENCH]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_FOREIGN_NAME_GERMAN]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_FOREIGN_NAME_ITALIAN]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_FOREIGN_NAME_JAPANESE]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_FOREIGN_NAME_KOREAN]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_FOREIGN_NAME_PORTUGUESE]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_FOREIGN_NAME_PORTUGUESE_BRAZIL]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_FOREIGN_NAME_RUSSIAN]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_FOREIGN_NAME_SPANISH]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_MUTIVERSEID]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_VARIATIONS]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_LAYOUT]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_TYPE]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_ORIGINAL_TYPE]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_TYPES]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_SUBTYPES]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_SUPERTYPES]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_COLORS]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_CMC]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_MANACOST]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_RARITY]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_POWER]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_TOUGHNESS]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_LOYALTY]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_TEXT]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_ORIGINAL_TEXT]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_ARTIST]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_FLAVOR]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_IMAGENAME]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_NUMBER]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_WATERMARK]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_BORDER]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_HAND]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_LIFE]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_LEGALITY_STANDARD]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_LEGALITY_MODERN]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_LEGALITY_LEGACY]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_LEGALITY_VINTAGE]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_LEGALITY_FREEFORM]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_LEGALITY_PRISMATIC]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_LEGALITY_TRIBAL_WARS_LEGACY]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_LEGALITY_TRIBAL_WARS_STANDARD]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_LEGALITY_SINGLETON_100]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_LEGALITY_COMMANDER]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_PRINTINGS]";
            SQL += System.Environment.NewLine;
            SQL += "    	[CARD_RULINGS]";

            return SQL;
        }

        public static string Template()
        {
            string SQL = string.Empty;

            SQL += System.Environment.NewLine;
            SQL += "/* 	Script d'INSERT/UPDATE de la carte '[CARTE_NOM]'	*/";
            SQL += System.Environment.NewLine;
            SQL += System.Environment.NewLine;
            SQL += "/*  Exemple d'INSERT */";
            SQL += System.Environment.NewLine;
            SQL += "INSERT INTO TABLE_CARTES (COLONNE_NOM, COLONNE_CCM, COLONNE_TYPE, COLONNE_FORCE_ENDURANCE, COLONNE_TEXTE, COLONNE_RARETE) VALUES('[CARTE_NOM_BESTIAIRE]', '[CARTE_CCM]', '[CARTE_TYPE]', '[CARTE_FORCE_ENDURANCE]', '[CARTE_TEXTE]', '[CARTE_RARETE]');";
            SQL += System.Environment.NewLine;
            SQL += System.Environment.NewLine;
            SQL += "/*  Exemple d'UPDATE */";
            SQL += System.Environment.NewLine;
            SQL += "UPDATE TABLE_CARTES	SET COLONNE_CCM = '[CARTE_CCM]', COLONNE_FORCE_ENDURANCE = '[CARTE_FORCE_ENDURANCE]', COLONNE_TEXTE = '[CARTE_TEXTE]' WHERE COLONNE_NOM = '[CARTE_NOM_BESTIAIRE]' AND COLONNE_EDITION_ID = '[EDITION_ID]';";
            SQL += System.Environment.NewLine;
            SQL += System.Environment.NewLine;
            return SQL;
        }

        public static string InsererCaracteresEchappement(string SQL)
        {
            Char RetourLigne = '\n';
            Char RetourLigneBis = '\r';
            string NouveauRetourLigne = @"\n";
            return SQL.Replace("'", @"\'").Replace(RetourLigne.ToString(), NouveauRetourLigne).Replace(RetourLigneBis.ToString(), NouveauRetourLigne);
        }

        public static string GenererScriptSQL(EditionCartes_X Edition)
        {
            string ScriptSQL = string.Empty;
            string Template = Fichier.LoadFile(Fichier.GetAbsolutePath("TemplateSQL/TemplateScriptCarte.sql"));
            foreach (Carte_X Carte in Edition.cards)
            {
                string TemplateCarte = Template;
                TemplateCarte = TemplateCarte.Replace("[EDITION_NAME]", Edition.name);
                TemplateCarte = TemplateCarte.Replace("[EDITION_CODE_BESTIAIRE]", MTGRessources.Ressources.ConversionEditionID_MTGJSON_To_BestiaireID(Edition.code));
                TemplateCarte = TemplateCarte.Replace("[EDITION_CODE_GATHERER]", Edition.gathererCode);
                TemplateCarte = TemplateCarte.Replace("[EDITION_CODE_MTGJSON]", Edition.code);
                TemplateCarte = TemplateCarte.Replace("[EDITION_RELEASE_DATE]", Edition.releaseDate);
                TemplateCarte = TemplateCarte.Replace("[EDITION_BORDER]", Edition.border);
                TemplateCarte = TemplateCarte.Replace("[EDITION_TYPE]", Edition.type);
                //TemplateCarte = TemplateCarte.Replace("[EDITION_BOOSTER]", Edition.booster);
                TemplateCarte = TemplateCarte.Replace("[CARD_NAME]", Carte.name);
                //TemplateCarte = TemplateCarte.Replace("[CARD_NAMES]", Carte.names);
                //TemplateCarte = TemplateCarte.Replace("[CARD_FOREIGN_NAME_CHINESE_TRADITIONAL]", Carte.);
                //TemplateCarte = TemplateCarte.Replace("[CARD_FOREIGN_NAME_CHINESE_SIMPLIFIED]", Carte.);
                //TemplateCarte = TemplateCarte.Replace("[CARD_FOREIGN_NAME_FRENCH]", Carte.);
                //TemplateCarte = TemplateCarte.Replace("[CARD_FOREIGN_NAME_GERMAN]", Carte.);
                //TemplateCarte = TemplateCarte.Replace("[CARD_FOREIGN_NAME_ITALIAN]", Carte.);
                //TemplateCarte = TemplateCarte.Replace("[CARD_FOREIGN_NAME_JAPANESE]", Carte.);
                //TemplateCarte = TemplateCarte.Replace("[CARD_FOREIGN_NAME_KOREAN]", Carte.);
                //TemplateCarte = TemplateCarte.Replace("[CARD_FOREIGN_NAME_PORTUGUESE]", )Carte.;
                //TemplateCarte = TemplateCarte.Replace("[CARD_FOREIGN_NAME_PORTUGUESE_BRAZIL]", Carte.);
                //TemplateCarte = TemplateCarte.Replace("[CARD_FOREIGN_NAME_RUSSIAN]", Carte.);
                //TemplateCarte = TemplateCarte.Replace("[CARD_FOREIGN_NAME_SPANISH]", Carte.);
                TemplateCarte = TemplateCarte.Replace("[CARD_MUTIVERSEID]", Carte.multiverseid);
                //TemplateCarte = TemplateCarte.Replace("[CARD_VARIATIONS]", Carte.variations);
                TemplateCarte = TemplateCarte.Replace("[CARD_LAYOUT]", Carte.layout);
                TemplateCarte = TemplateCarte.Replace("[CARD_TYPE]", Carte.type);
                TemplateCarte = TemplateCarte.Replace("[CARD_ORIGINAL_TYPE]", Carte.originalType);
                //TemplateCarte = TemplateCarte.Replace("[CARD_TYPES]", Carte.types);
                //TemplateCarte = TemplateCarte.Replace("[CARD_SUBTYPES]", Carte.subtypes);
                //TemplateCarte = TemplateCarte.Replace("[CARD_SUPERTYPES]", Carte.supertypes);
                //TemplateCarte = TemplateCarte.Replace("[CARD_COLORS]", Carte.colors);
                TemplateCarte = TemplateCarte.Replace("[CARD_CMC]", Carte.cmc);
                TemplateCarte = TemplateCarte.Replace("[CARD_MANACOST]", Carte.manaCost);
                TemplateCarte = TemplateCarte.Replace("[CARD_RARITY]", Carte.rarity);
                TemplateCarte = TemplateCarte.Replace("[CARD_POWER]", Carte.power);
                TemplateCarte = TemplateCarte.Replace("[CARD_TOUGHNESS]", Carte.toughness);
                TemplateCarte = TemplateCarte.Replace("[CARD_LOYALTY]", Carte.loyalty);
                TemplateCarte = TemplateCarte.Replace("[CARD_TEXT]", InsererCaracteresEchappement(Carte.text));
                TemplateCarte = TemplateCarte.Replace("[CARD_ORIGINAL_TEXT]", InsererCaracteresEchappement(Carte.originalText));
                TemplateCarte = TemplateCarte.Replace("[CARD_ARTIST]", Carte.artist);
                TemplateCarte = TemplateCarte.Replace("[CARD_FLAVOR]", Carte.flavor);
                TemplateCarte = TemplateCarte.Replace("[CARD_IMAGENAME]", Carte.imageName);
                TemplateCarte = TemplateCarte.Replace("[CARD_NUMBER]", Carte.number);
                TemplateCarte = TemplateCarte.Replace("[CARD_WATERMARK]", Carte.watermark);
                TemplateCarte = TemplateCarte.Replace("[CARD_BORDER]", Carte.border);
                TemplateCarte = TemplateCarte.Replace("[CARD_HAND]", Carte.hand);
                TemplateCarte = TemplateCarte.Replace("[CARD_LIFE]", Carte.life);
                /*
                TemplateCarte = TemplateCarte.Replace("[CARD_LEGALITY_STANDARD]", Carte.legalities.Standard);
                TemplateCarte = TemplateCarte.Replace("[CARD_LEGALITY_MODERN]", Carte.legalities.Modern);
                TemplateCarte = TemplateCarte.Replace("[CARD_LEGALITY_LEGACY]", Carte.legalities.Legacy);
                TemplateCarte = TemplateCarte.Replace("[CARD_LEGALITY_VINTAGE]", Carte.legalities.Vintage);
                TemplateCarte = TemplateCarte.Replace("[CARD_LEGALITY_FREEFORM]", Carte.legalities.Freeform);
                TemplateCarte = TemplateCarte.Replace("[CARD_LEGALITY_PRISMATIC]", Carte.legalities.Prismatic);
                TemplateCarte = TemplateCarte.Replace("[CARD_LEGALITY_TRIBAL_WARS_LEGACY]", Carte.legalities.TribalWarsLegacy);
                TemplateCarte = TemplateCarte.Replace("[CARD_LEGALITY_TRIBAL_WARS_STANDARD]", Carte.legalities.TribalWarsStandard);
                TemplateCarte = TemplateCarte.Replace("[CARD_LEGALITY_SINGLETON_100]", Carte.legalities.Singleton100);
                TemplateCarte = TemplateCarte.Replace("[CARD_LEGALITY_COMMANDER]", Carte.legalities.Commander);
                */
                //TemplateCarte = TemplateCarte.Replace("[CARD_PRINTINGS]", Carte.printings);
                //TemplateCarte = TemplateCarte.Replace("[CARD_RULINGS]", Carte.rulings);
                ScriptSQL += TemplateCarte;
                ScriptSQL += System.Environment.NewLine;
                ScriptSQL += System.Environment.NewLine;
            }
            return ScriptSQL;
        }
        
    }
}
