using System;
using System.Linq;
using System.Collections.Generic;

namespace MTG.DataExtractor.Objects.Managers
{
    public class ManageDonneeCarte
    {

        public static string ID(DonneeCarte donneeCarte)
        {
            string Resultat = string.Empty;
            switch (donneeCarte.TypeDonnee)
            {
                case DonneeCarte.TYPE_DONNEE.CARD_NAME:
                    Resultat = "CARD_NAME";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_NAMES:
                    Resultat = "CARD_NAMES";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_TRADITIONAL:
                    Resultat = "CARD_FOREIGN_NAME_CHINESE_TRADITIONAL";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_SIMPLIFIED:
                    Resultat = "CARD_FOREIGN_NAME_CHINESE_SIMPLIFIED";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_FRENCH:
                    Resultat = "CARD_FOREIGN_NAME_FRENCH";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_GERMAN:
                    Resultat = "CARD_FOREIGN_NAME_GERMAN";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_ITALIAN:
                    Resultat = "CARD_FOREIGN_NAME_ITALIAN";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_JAPANESE:
                    Resultat = "CARD_FOREIGN_NAME_JAPANESE";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_KOREAN:
                    Resultat = "CARD_FOREIGN_NAME_KOREAN";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE:
                    Resultat = "CARD_FOREIGN_NAME_PORTUGUESE";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE_BRAZIL:
                    Resultat = "CARD_FOREIGN_NAME_PORTUGUESE_BRAZIL";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_RUSSIAN:
                    Resultat = "CARD_FOREIGN_NAME_RUSSIAN";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_SPANISH:
                    Resultat = "CARD_FOREIGN_NAME_SPANISH";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_MUTIVERSEID:
                    Resultat = "CARD_MUTIVERSEID";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_VARIATIONS:
                    Resultat = "CARD_VARIATIONS";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LAYOUT:
                    Resultat = "CARD_LAYOUT";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TYPE:
                    Resultat = "CARD_TYPE";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_ORIGINAL_TYPE:
                    Resultat = "CARD_ORIGINAL_TYPE";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TYPES:
                    Resultat = "CARD_TYPES";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_SUBTYPES:
                    Resultat = "CARD_SUBTYPES";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_SUPERTYPES:
                    Resultat = "CARD_SUPERTYPES";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_COLORS:
                    Resultat = "CARD_COLORS";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_CMC:
                    Resultat = "CARD_CMC";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_MANACOST:
                    Resultat = "CARD_MANACOST";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_RARITY:
                    Resultat = "CARD_RARITY";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_POWER:
                    Resultat = "CARD_POWER";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TOUGHNESS:
                    Resultat = "CARD_TOUGHNESS";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LOYALTY:
                    Resultat = "CARD_LOYALTY";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TEXT:
                    Resultat = "CARD_TEXT";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_ORIGINAL_TEXT:
                    Resultat = "CARD_ORIGINAL_TEXT";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_ARTIST:
                    Resultat = "CARD_ARTIST";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FLAVOR:
                    Resultat = "CARD_FLAVOR";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_IMAGENAME:
                    Resultat = "CARD_IMAGENAME";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_NUMBER:
                    Resultat = "CARD_NUMBER";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_WATERMARK:
                    Resultat = "CARD_WATERMARK";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_BORDER:
                    Resultat = "CARD_BORDER";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_HAND:
                    Resultat = "CARD_HAND";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LIFE:
                    Resultat = "CARD_LIFE";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_STANDARD:
                    Resultat = "CARD_LEGALITY_STANDARD";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_MODERN:
                    Resultat = "CARD_LEGALITY_MODERN";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_LEGACY:
                    Resultat = "CARD_LEGALITY_LEGACY";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_VINTAGE:
                    Resultat = "CARD_LEGALITY_VINTAGE";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_FREEFORM:
                    Resultat = "CARD_LEGALITY_FREEFORM";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_PRISMATIC:
                    Resultat = "CARD_LEGALITY_PRISMATIC";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_LEGACY:
                    Resultat = "CARD_LEGALITY_TRIBAL_WARS_LEGACY";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_STANDARD:
                    Resultat = "CARD_LEGALITY_TRIBAL_WARS_STANDARD";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_SINGLETON_100:
                    Resultat = "CARD_LEGALITY_SINGLETON_100";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_COMMANDER:
                    Resultat = "CARD_LEGALITY_COMMANDER";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_PRINTINGS:
                    Resultat = "CARD_PRINTINGS";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_RULINGS:
                    Resultat = "CARD_RULINGS";
                    break;
            }
            return Resultat;
        }

        public static string JSON_ID(DonneeCarte donneeCarte)
        {
            string Resultat = string.Empty;
            switch (donneeCarte.TypeDonnee)
            {
                case DonneeCarte.TYPE_DONNEE.CARD_NAME:
                    Resultat = "name";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_NAMES:
                    Resultat = "names";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME:
                    Resultat = "foreignNames";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_TRADITIONAL:
                    Resultat = "Chinese Traditional";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_SIMPLIFIED:
                    Resultat = "Chinese Simplified";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_FRENCH:
                    Resultat = "French";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_GERMAN:
                    Resultat = "German";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_ITALIAN:
                    Resultat = "Italian";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_JAPANESE:
                    Resultat = "Japanese";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_KOREAN:
                    Resultat = "Korean";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE:
                    Resultat = "Portuguese";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE_BRAZIL:
                    Resultat = "Portuguese (Brazil)";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_RUSSIAN:
                    Resultat = "Russian";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_SPANISH:
                    Resultat = "Spanish";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_MUTIVERSEID:
                    Resultat = "multiverseid";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_VARIATIONS:
                    Resultat = "variations";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LAYOUT:
                    Resultat = "layout";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TYPE:
                    Resultat = "type";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_ORIGINAL_TYPE:
                    Resultat = "originalType";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TYPES:
                    Resultat = "types";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_SUBTYPES:
                    Resultat = "subtypes";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_SUPERTYPES:
                    Resultat = "supertypes";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_COLORS:
                    Resultat = "colors";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_CMC:
                    Resultat = "cmc";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_MANACOST:
                    Resultat = "manaCost";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_RARITY:
                    Resultat = "rarity";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_POWER:
                    Resultat = "power";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TOUGHNESS:
                    Resultat = "toughness";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LOYALTY:
                    Resultat = "loyalty";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TEXT:
                    Resultat = "text";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_ORIGINAL_TEXT:
                    Resultat = "originalText";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_ARTIST:
                    Resultat = "artist";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FLAVOR:
                    Resultat = "flavor";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_IMAGENAME:
                    Resultat = "imageName";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_NUMBER:
                    Resultat = "number";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_WATERMARK:
                    Resultat = "watermark";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_BORDER:
                    Resultat = "border";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_HAND:
                    Resultat = "hand";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LIFE:
                    Resultat = "life";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY:
                    Resultat = "legalities";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_STANDARD:
                    Resultat = "Standard";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_MODERN:
                    Resultat = "Modern";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_LEGACY:
                    Resultat = "Legacy";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_VINTAGE:
                    Resultat = "Vintage";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_FREEFORM:
                    Resultat = "Freeform";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_PRISMATIC:
                    Resultat = "Prismatic";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_LEGACY:
                    Resultat = "Tribal Wars Legacy";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_STANDARD:
                    Resultat = "Tribal Wars Legacy Standard";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_SINGLETON_100:
                    Resultat = "Singleton 100";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_COMMANDER:
                    Resultat = "Commander";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_PRINTINGS:
                    Resultat = "printings";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_RULINGS:
                    Resultat = "rulings";
                    break;
            }
            return Resultat;
        }

        public static bool Base(DonneeCarte donneeCarte)
        {
            switch (donneeCarte.TypeDonnee)
            {
                case DonneeCarte.TYPE_DONNEE.CARD_NAME:
                case DonneeCarte.TYPE_DONNEE.CARD_MUTIVERSEID:
                case DonneeCarte.TYPE_DONNEE.CARD_TYPE:
                case DonneeCarte.TYPE_DONNEE.CARD_TYPES:
                case DonneeCarte.TYPE_DONNEE.CARD_SUBTYPES:
                case DonneeCarte.TYPE_DONNEE.CARD_SUPERTYPES:
                case DonneeCarte.TYPE_DONNEE.CARD_COLORS:
                case DonneeCarte.TYPE_DONNEE.CARD_CMC:
                case DonneeCarte.TYPE_DONNEE.CARD_MANACOST:
                case DonneeCarte.TYPE_DONNEE.CARD_RARITY:
                case DonneeCarte.TYPE_DONNEE.CARD_POWER:
                case DonneeCarte.TYPE_DONNEE.CARD_TOUGHNESS:
                case DonneeCarte.TYPE_DONNEE.CARD_LOYALTY:
                case DonneeCarte.TYPE_DONNEE.CARD_TEXT:
                case DonneeCarte.TYPE_DONNEE.CARD_IMAGENAME:
                case DonneeCarte.TYPE_DONNEE.CARD_NUMBER:
                    return true;
                default:
                    return false;
            }
        }

        public static string Libelle(DonneeCarte donneeCarte)
        {
            string Resultat = string.Empty;
            switch (donneeCarte.TypeDonnee)
            {
                case DonneeCarte.TYPE_DONNEE.CARD_NAME:
                    Resultat = "Name";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_NAMES:
                    Resultat = "Names";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_TRADITIONAL:
                    Resultat = "Foreign Name Chinese Traditional";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_SIMPLIFIED:
                    Resultat = "Foreign Name Chinese Simplified";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_FRENCH:
                    Resultat = "Foreign Name French";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_GERMAN:
                    Resultat = "Foreign Name German";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_ITALIAN:
                    Resultat = "Foreign Name Italian";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_JAPANESE:
                    Resultat = "Foreign Name Japanese";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_KOREAN:
                    Resultat = "Foreign Name Korean";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE:
                    Resultat = "Foreign Name Portuguese";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE_BRAZIL:
                    Resultat = "Foreign Name Portuguese Brazil";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_RUSSIAN:
                    Resultat = "Foreign Name Russian";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_SPANISH:
                    Resultat = "Foreign Name Spanish";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_MUTIVERSEID:
                    Resultat = "Mutiverseid";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_VARIATIONS:
                    Resultat = "Variations";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LAYOUT:
                    Resultat = "Layout";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TYPE:
                    Resultat = "Type";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_ORIGINAL_TYPE:
                    Resultat = "Original Type";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TYPES:
                    Resultat = "Types";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_SUBTYPES:
                    Resultat = "Subtypes";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_SUPERTYPES:
                    Resultat = "Supertypes";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_COLORS:
                    Resultat = "Colors";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_CMC:
                    Resultat = "Cmc";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_MANACOST:
                    Resultat = "Manacost";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_RARITY:
                    Resultat = "Rarity";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_POWER:
                    Resultat = "Power";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TOUGHNESS:
                    Resultat = "Toughness";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LOYALTY:
                    Resultat = "Loyalty";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TEXT:
                    Resultat = "Text";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_ORIGINAL_TEXT:
                    Resultat = "Original Text";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_ARTIST:
                    Resultat = "Artist";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FLAVOR:
                    Resultat = "Flavor";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_IMAGENAME:
                    Resultat = "Imagename";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_NUMBER:
                    Resultat = "Number";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_WATERMARK:
                    Resultat = "Watermark";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_BORDER:
                    Resultat = "Border";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_HAND:
                    Resultat = "Hand";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LIFE:
                    Resultat = "Life";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_STANDARD:
                    Resultat = "Legality Standard";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_MODERN:
                    Resultat = "Legality Modern";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_LEGACY:
                    Resultat = "Legality Legacy";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_VINTAGE:
                    Resultat = "Legality Vintage";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_FREEFORM:
                    Resultat = "Legality Freeform";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_PRISMATIC:
                    Resultat = "Legality Prismatic";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_LEGACY:
                    Resultat = "Legality Tribal Wars Legacy";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_STANDARD:
                    Resultat = "Legality Tribal Wars Standard";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_SINGLETON_100:
                    Resultat = "Legality Singleton 100";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_COMMANDER:
                    Resultat = "Legality Commander";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_PRINTINGS:
                    Resultat = "Printings";
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_RULINGS:
                    Resultat = "Rulings";
                    break;
            }
            return Resultat;
        }

        public static string Value(Carte Carte, EditionCartes Edition, DonneeCarte donneeCarte, bool FormatText)
        {
            string Resultat = string.Empty;
            string Names = ListToString(Carte.names);
            string Variations = ListToString(Carte.variations);
            string Types = ListToString(Carte.types);
            string Subtypes = ListToString(Carte.subtypes);
            string Supertypes = ListToString(Carte.supertypes);
            string Colors = ListToString(Carte.colors);
            switch (donneeCarte.TypeDonnee)
            {
                case DonneeCarte.TYPE_DONNEE.CARD_NAME:
                    Resultat = Carte.name;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_NAMES:
                    Resultat = Names;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_MUTIVERSEID:
                    Resultat = Carte.multiverseid;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_VARIATIONS:
                    Resultat = Variations;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LAYOUT:
                    Resultat = Carte.layout;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TYPE:
                    Resultat = Carte.type;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TYPES:
                    Resultat = Types;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_SUBTYPES:
                    Resultat = Subtypes;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_SUPERTYPES:
                    Resultat = Supertypes;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_COLORS:
                    Resultat = Colors;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_CMC:
                    Resultat = Carte.cmc;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_MANACOST:
                    Resultat = Carte.manaCost;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_RARITY:
                    Resultat = Carte.rarity;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_POWER:
                    Resultat = Carte.power;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TOUGHNESS:
                    Resultat = Carte.toughness;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LOYALTY:
                    Resultat = Carte.loyalty;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TEXT:
                    Resultat = FormatText ? Formattestring(Carte.text) : Carte.text;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_ARTIST:
                    Resultat = Carte.artist;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FLAVOR:
                    Resultat = Formattestring(Carte.flavor);
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_IMAGENAME:
                    Resultat = Carte.imageName;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_NUMBER:
                    Resultat = Carte.number;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_WATERMARK:
                    Resultat = Carte.watermark;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_BORDER:
                    Resultat = Carte.border;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_HAND:
                    Resultat = Carte.hand;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LIFE:
                    Resultat = Carte.life;
                    break;
            }
            return Resultat;
        }

        public static string Value(Carte_X Carte, EditionCartes_X Edition, DonneeCarte donneeCarte, bool FormatText)
        {
            string Resultat = string.Empty;
            string Names = ListToString(Carte.names);
            string Variations = ListToString(Carte.variations);
            string Types = ListToString(Carte.types);
            string Subtypes = ListToString(Carte.subtypes);
            string Supertypes = ListToString(Carte.supertypes);
            string Colors = ListToString(Carte.colors);
            switch (donneeCarte.TypeDonnee)
            {
                case DonneeCarte.TYPE_DONNEE.CARD_NAME:
                    Resultat = Carte.name;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_NAMES:
                    Resultat = Names;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_TRADITIONAL:
                    Resultat = ExtractForeignName(Carte.foreignNames, new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_TRADITIONAL));
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_SIMPLIFIED:
                    Resultat = ExtractForeignName(Carte.foreignNames, new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_SIMPLIFIED));
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_FRENCH:
                    Resultat = ExtractForeignName(Carte.foreignNames, new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_FRENCH));
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_GERMAN:
                    Resultat = ExtractForeignName(Carte.foreignNames, new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_GERMAN));
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_ITALIAN:
                    Resultat = ExtractForeignName(Carte.foreignNames, new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_ITALIAN));
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_JAPANESE:
                    Resultat = ExtractForeignName(Carte.foreignNames, new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_JAPANESE));
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_KOREAN:
                    Resultat = ExtractForeignName(Carte.foreignNames, new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_KOREAN));
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE:
                    Resultat = ExtractForeignName(Carte.foreignNames, new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE));
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE_BRAZIL:
                    Resultat = ExtractForeignName(Carte.foreignNames, new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE_BRAZIL));
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_RUSSIAN:
                    Resultat = ExtractForeignName(Carte.foreignNames, new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_RUSSIAN));
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_SPANISH:
                    Resultat = ExtractForeignName(Carte.foreignNames, new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_SPANISH));
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_MUTIVERSEID:
                    Resultat = Carte.multiverseid;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_VARIATIONS:
                    Resultat = Variations;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LAYOUT:
                    Resultat = Carte.layout;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TYPE:
                    Resultat = Carte.type;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_ORIGINAL_TYPE:
                    Resultat = Carte.originalType;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TYPES:
                    Resultat = Types;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_SUBTYPES:
                    Resultat = Subtypes;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_SUPERTYPES:
                    Resultat = Supertypes;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_COLORS:
                    Resultat = Colors;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_CMC:
                    Resultat = Carte.cmc;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_MANACOST:
                    Resultat = Carte.manaCost;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_RARITY:
                    Resultat = Carte.rarity;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_POWER:
                    Resultat = Carte.power;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TOUGHNESS:
                    Resultat = Carte.toughness;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LOYALTY:
                    Resultat = Carte.loyalty;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_TEXT:
                    Resultat = FormatText ? Formattestring(Carte.text) : Carte.text;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_ORIGINAL_TEXT:
                    Resultat = FormatText ? Formattestring(Carte.originalText) : Carte.originalText;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_ARTIST:
                    Resultat = Carte.artist;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_FLAVOR:
                    Resultat = Formattestring(Carte.flavor);
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_IMAGENAME:
                    Resultat = Carte.imageName;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_NUMBER:
                    Resultat = Carte.number;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_WATERMARK:
                    Resultat = Carte.watermark;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_BORDER:
                    Resultat = Carte.border;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_HAND:
                    Resultat = Carte.hand;
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_LIFE:
                    Resultat = Carte.life;
                    break;
                /*
            case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_STANDARD:
                Resultat = Carte.legalities.Standard;
                break;
            case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_MODERN:
                Resultat = Carte.legalities.Modern;
                break;
            case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_LEGACY:
                Resultat = Carte.legalities.Legacy;
                break;
            case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_VINTAGE:
                Resultat = Carte.legalities.Vintage;
                break;
            case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_FREEFORM:
                Resultat = Carte.legalities.Freeform;
                break;
            case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_PRISMATIC:
                Resultat = Carte.legalities.Prismatic;
                break;
            case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_LEGACY:
                Resultat = Carte.legalities.TribalWarsLegacy;
                break;
            case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_STANDARD:
                Resultat = Carte.legalities.TribalWarsStandard;
                break;
            case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_SINGLETON_100:
                Resultat = Carte.legalities.Singleton100;
                break;
            case DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_COMMANDER:
                Resultat = Carte.legalities.Commander;
                break;
            */
                case DonneeCarte.TYPE_DONNEE.CARD_PRINTINGS:
                    Resultat = Formattestring(ListToString(Carte.printings));
                    break;
                case DonneeCarte.TYPE_DONNEE.CARD_RULINGS:
                    Resultat = ListRulesToString(Carte.rulings);
                    break;
            }
            Char RetourLigne = '\n';
            Char RetourLigneBis = '\r';
            if (Resultat.IndexOf(RetourLigne) >= 0 || Resultat.IndexOf(RetourLigneBis) >= 0)
            {
                Resultat = Resultat.Replace(RetourLigne, '$').Replace(RetourLigneBis, '$').Replace("$", @"\n");
            }
            if (Resultat.IndexOf(@"""") >= 0)
            {
                Resultat = Resultat.Replace(@"""", "\\\"");
            }
            return Resultat;
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

        protected static string ExtractForeignName(List<NomEtranger> NomsEtrangers, DonneeCarte Langue)
        {
            string Resultat = string.Empty;
            foreach (NomEtranger NomEtranger in NomsEtrangers)
            {
                if (NomEtranger.language.Equals(JSON_ID(Langue)))
                {
                    Resultat = NomEtranger.name;
                }
            }
            return Resultat;
        }

        public static List<DonneeCarte> ListeDonneesCartes()
        {
            List<DonneeCarte> Donnes = new List<DonneeCarte>();
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_NAME));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_NAMES));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_MUTIVERSEID));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_VARIATIONS));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LAYOUT));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_TYPE));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_TYPES));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_SUBTYPES));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_SUPERTYPES));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_COLORS));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_CMC));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_MANACOST));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_RARITY));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_POWER));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_TOUGHNESS));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LOYALTY));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_TEXT));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_ARTIST));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FLAVOR));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_IMAGENAME));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_NUMBER));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_WATERMARK));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_BORDER));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_HAND));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LIFE));
            return Donnes;
        }

        public static List<DonneeCarte> ListeDonneesCartes_X()
        {
            List<DonneeCarte> Donnes = new List<DonneeCarte>();
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_NAME));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_NAMES));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_TRADITIONAL));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_CHINESE_SIMPLIFIED));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_FRENCH));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_GERMAN));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_ITALIAN));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_JAPANESE));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_KOREAN));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_PORTUGUESE_BRAZIL));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_RUSSIAN));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FOREIGN_NAME_SPANISH));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_MUTIVERSEID));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_VARIATIONS));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LAYOUT));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_TYPE));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_ORIGINAL_TYPE));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_TYPES));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_SUBTYPES));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_SUPERTYPES));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_COLORS));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_CMC));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_MANACOST));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_RARITY));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_POWER));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_TOUGHNESS));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LOYALTY));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_TEXT));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_ORIGINAL_TEXT));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_ARTIST));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_FLAVOR));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_IMAGENAME));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_NUMBER));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_WATERMARK));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_BORDER));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_HAND));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LIFE));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_STANDARD));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_MODERN));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_LEGACY));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_VINTAGE));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_FREEFORM));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_PRISMATIC));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_LEGACY));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_TRIBAL_WARS_STANDARD));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_SINGLETON_100));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_LEGALITY_COMMANDER));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_PRINTINGS));
            Donnes.Add(new DonneeCarte(DonneeCarte.TYPE_DONNEE.CARD_RULINGS));
            return Donnes;
        }

        public static List<DonneeCarte> ListDonneesCartes_Filtered()
        {
            return ListeDonneesCartes().Where(donnee => Base(donnee)).ToList();
        }

    }
}
