using DataBase.Objects;
using DB = DataBase.Bestiaire.Enumerations;
using System.Collections.Generic;
using DataBase.Enumerations;

namespace DataBase.Bestiaire.Constants
{
    public class ConstantsColumns
    {
        public static Dictionary<int, Column> COLUMNS_EDITIONS =
            new Dictionary<int, Column>
            {
                    { (int)DB.Enums.COLUMNS_EDITIONS.DATABASE_ID, new Column ("ID", Enums.DATABASE_TYPE.INTEGER, true) },
                    { (int)DB.Enums.COLUMNS_EDITIONS.ID, new Column ("EDITION_ID", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_EDITIONS.NAME, new Column ("NAME", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_EDITIONS.PREMIUMS, new Column ("PREMIUMS", Enums.DATABASE_TYPE.INTEGER, false) },
                    { (int)DB.Enums.COLUMNS_EDITIONS.TRICOLORS, new Column ("TRICOLORS", Enums.DATABASE_TYPE.INTEGER, false) },
                    { (int)DB.Enums.COLUMNS_EDITIONS.MYTHICS, new Column ("MYTHICS", Enums.DATABASE_TYPE.INTEGER, false) },
					{ (int)DB.Enums.COLUMNS_EDITIONS.LANDS, new Column ("LANDS", Enums.DATABASE_TYPE.INTEGER, false) },
					{ (int)DB.Enums.COLUMNS_EDITIONS.TRANSFORMS, new Column ("TRANSFORMS", Enums.DATABASE_TYPE.INTEGER, false) },
					{ (int)DB.Enums.COLUMNS_EDITIONS.NB_MYTHICS, new Column ("NB_MYTHICS", Enums.DATABASE_TYPE.DOUBLE, false) },
					{ (int)DB.Enums.COLUMNS_EDITIONS.NB_RARES, new Column ("NB_RARES", Enums.DATABASE_TYPE.DOUBLE, false) },
					{ (int)DB.Enums.COLUMNS_EDITIONS.NB_UNCOS, new Column ("NB_UNCOS", Enums.DATABASE_TYPE.DOUBLE, false) },
					{ (int)DB.Enums.COLUMNS_EDITIONS.NB_COMMUNES, new Column ("NB_COMMUNES", Enums.DATABASE_TYPE.DOUBLE, false) },
					{ (int)DB.Enums.COLUMNS_EDITIONS.NB_RARES_SPECIALES, new Column ("NB_RARES_SPECIALES", Enums.DATABASE_TYPE.DOUBLE, false) },
					{ (int)DB.Enums.COLUMNS_EDITIONS.NB_UNCOS_SPECIALES, new Column ("NB_UNCOS_SPECIALES", Enums.DATABASE_TYPE.DOUBLE, false) },
					{ (int)DB.Enums.COLUMNS_EDITIONS.NB_COMMUNES_SPECIALES, new Column ("NB_COMMUNES_SPECIALES", Enums.DATABASE_TYPE.DOUBLE, false) },
                    { (int)DB.Enums.COLUMNS_EDITIONS.DATA_GATHERER_LOADED, new Column ("DATA_GATHERER_LOADED", Enums.DATABASE_TYPE.INTEGER, false) },
                    { (int)DB.Enums.COLUMNS_EDITIONS.DATA_BESTIAIRE_LOADED, new Column ("DATA_BESTIAIRE_LOADED", Enums.DATABASE_TYPE.INTEGER, false) },
                    { (int)DB.Enums.COLUMNS_EDITIONS.DATA_IMAGES_LOADED, new Column ("DATA_IMAGES_LOADED", Enums.DATABASE_TYPE.INTEGER, false) }
            };
        public static Dictionary<int, Column> COLUMNS_DRAFTS =
            new Dictionary<int, Column>
            {
                    { (int)DB.Enums.COLUMNS_DRAFTS.DATABASE_ID, new Column ("ID", Enums.DATABASE_TYPE.INTEGER, true) },
                    { (int)DB.Enums.COLUMNS_DRAFTS.ID, new Column ("DRAFT_ID", Enums.DATABASE_TYPE.INTEGER, false) },
                    { (int)DB.Enums.COLUMNS_DRAFTS.NAME, new Column ("NAME", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_DRAFTS.EDITION_1, new Column ("EDITION_1", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_DRAFTS.EDITION_2, new Column ("EDITION_2", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_DRAFTS.EDITION_3, new Column ("EDITION_3", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_DRAFTS.HIGHLANDER, new Column ("HIGHLANDER", Enums.DATABASE_TYPE.INTEGER, false) }
            };
        public static Dictionary<int, Column> COLUMNS_CARDS =
            new Dictionary<int, Column>
            {
                    { (int)DB.Enums.COLUMNS_CARDS.DATABASE_ID, new Column ("ID", Enums.DATABASE_TYPE.INTEGER, true) },
                    { (int)DB.Enums.COLUMNS_CARDS.ID, new Column ("CARD_ID", Enums.DATABASE_TYPE.INTEGER, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.EDITION_ID, new Column ("EDITION_ID", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.NAME, new Column ("NAME", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.COLOR, new Column ("COLOR", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.RARITY, new Column ("RARITY", Enums.DATABASE_TYPE.TEXT, false) },
					{ (int)DB.Enums.COLUMNS_CARDS.CMC, new Column ("CMC", Enums.DATABASE_TYPE.DOUBLE, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.ACTIF, new Column ("ACTIF", Enums.DATABASE_TYPE.INTEGER, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.TRANSFORM, new Column ("TRANSFORM", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.TYPE, new Column ("TYPE", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.NOTES, new Column ("NOTES", Enums.DATABASE_TYPE.DOUBLE, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.PICKS, new Column ("PICKS", Enums.DATABASE_TYPE.INTEGER, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_NAME, new Column ("GATHERER_NAME", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_MULTIVERSE_ID, new Column ("GATHERER_MULTIVERSE_ID", Enums.DATABASE_TYPE.INTEGER, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_TYPE, new Column ("GATHERER_TYPE", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_TYPES, new Column ("GATHERER_TYPES", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_SUBTYPES, new Column ("GATHERER_SUBTYPES", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_SUPERTYPES, new Column ("GATHERER_SUPERTYPES", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_COLORS, new Column ("GATHERER_COLORS", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_CMC, new Column ("GATHERER_CMC", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_MANA_COST, new Column ("GATHERER_MANA_COST", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_RARITY, new Column ("GATHERER_RARITY", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_POWER, new Column ("GATHERER_POWER", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_TOUGHNESS, new Column ("GATHERER_TOUGHNESS", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_LOYALTY, new Column ("GATHERER_LOYALTY", Enums.DATABASE_TYPE.INTEGER, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_TEXT, new Column ("GATHERER_TEXT", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_IMAGE_NAME, new Column ("GATHERER_IMAGE_NAME", Enums.DATABASE_TYPE.TEXT, false) },
                    { (int)DB.Enums.COLUMNS_CARDS.GATHERER_NUMBER, new Column ("GATHERER_NUMBER", Enums.DATABASE_TYPE.TEXT, false) }
            };
    }
}