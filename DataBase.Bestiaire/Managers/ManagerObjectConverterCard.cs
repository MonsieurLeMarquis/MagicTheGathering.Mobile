using DataBase.Bestiaire.Enumerations;
using DataBase.Managers;
using Objects.Bestiaire.DataBase.Cards;
using System.Linq;
using Gatherer = Objects.MtgJson.Enumerations;

namespace DataBase.Bestiaire.Managers
{
    public class ManagerObjectConverterCard : BaseManagerObjectConverter
    {

        public override object UpdateObjectProperty(object objet, int column, object value)
        {
            if (objet is Card)
            {
				var card = (Card)objet;
				var valueString = GetValueString(value);
				var valueInteger = GetValueInteger(value);
				var valueDouble = GetValueDouble(value);
                switch ((Enums.COLUMNS_CARDS)column)
                {
                    case Enums.COLUMNS_CARDS.DATABASE_ID:
                        card.DataBaseID = valueInteger;
                        break;
                    case Enums.COLUMNS_CARDS.ID:
                        card.ID = valueInteger;
                        break;
                    case Enums.COLUMNS_CARDS.EDITION_ID:
                        card.EditionID = valueString;
                        break;
                    case Enums.COLUMNS_CARDS.NAME:
                        card.Name = valueString;
                        break;
                    case Enums.COLUMNS_CARDS.COLOR:
                        card.Color = valueString;
                        break;
                    case Enums.COLUMNS_CARDS.RARITY:
                        card.Rarity = valueString;
                        break;
                    case Enums.COLUMNS_CARDS.CMC:
                        card.CMC = valueDouble;
                        break;
                    case Enums.COLUMNS_CARDS.ACTIF:
                        card.Actif = IntToBool(valueInteger);
                        break;
                    case Enums.COLUMNS_CARDS.TRANSFORM:
                        card.Transform = valueString;
                        break;
                    case Enums.COLUMNS_CARDS.TYPE:
                        card.Type = valueString;
                        break;
                    case Enums.COLUMNS_CARDS.NOTES:
                        card.Notes = StringToListDouble(valueString);
                        break;
                    case Enums.COLUMNS_CARDS.PICKS:
                        card.Picks = StringToListInt(valueString);
                        break;
					/*
                    case Enums.COLUMNS_CARDS.GATHERER_NAME:
                        card.GATHERER_Name = valueString;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_MULTIVERSE_ID:
                        card.GATHERER_MultiverseID = valueInteger;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_TYPE:
                        card.GATHERER_Type = valueString;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_TYPES:
                        card.GATHERER_Types = StringToListInt(valueString)
                            .Select(type => (Gatherer.Enums.GATHERER_TYPE)type)
                            .ToList();
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_SUBTYPES:
                        card.GATHERER_SubTypes = StringToListInt(valueString)
                            .Select(subtype => (Gatherer.Enums.GATHERER_SUBTYPE)subtype)
                            .ToList();
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_SUPERTYPES:
                        card.GATHERER_SuperTypes = StringToListInt(valueString)
                            .Select(supertype => (Gatherer.Enums.GATHERER_SUPERTYPE)supertype)
                            .ToList();
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_COLORS:
                        card.GATHERER_Colors = StringToListInt(valueString)
                            .Select(color => (Gatherer.Enums.GATHERER_COLOR)color)
                            .ToList();
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_CMC:
                        card.GATHERER_CMC = valueDouble;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_MANA_COST:
                        card.GATHERER_ManaCost = valueString;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_RARITY:
                        card.GATHERER_Rarity = StringToListInt(valueString)
                            .Select(rarity => (Gatherer.Enums.GATHERER_RARITY)rarity)
                            .ToList();
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_POWER:
                        card.GATHERER_Power = valueString;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_TOUGHNESS:
                        card.GATHERER_Toughness = valueString;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_LOYALTY:
                        card.GATHERER_Loyalty = valueInteger;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_TEXT:
                        card.GATHERER_Text = valueString;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_IMAGE_NAME:
                        card.GATHERER_ImageName = valueString;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_NUMBER:
                        card.GATHERER_Number = valueString;
                        break;
                    */
                }
                objet = card;
            }
            return objet;
        }

        public override string GetObjectPropertyString(object objet, int column)
        {
            var value = "";
            if (objet is Card)
            {
                var card = (Card)objet;
                switch ((Enums.COLUMNS_CARDS)column)
                {
                    case Enums.COLUMNS_CARDS.EDITION_ID:
                        value = card.EditionID;
                        break;
                    case Enums.COLUMNS_CARDS.NAME:
                        value = card.Name;
                        break;
                    case Enums.COLUMNS_CARDS.COLOR:
                        value = card.Color;
                        break;
                    case Enums.COLUMNS_CARDS.RARITY:
                        value = card.Rarity;
                        break;
                    case Enums.COLUMNS_CARDS.TRANSFORM:
                        value = card.Transform;
                        break;
                    case Enums.COLUMNS_CARDS.TYPE:
                        value = card.Type;
                        break;
                    case Enums.COLUMNS_CARDS.NOTES:
                        value = ListDoubleToString(card.Notes);
                        break;
                    case Enums.COLUMNS_CARDS.PICKS:
                        value = ListIntToString(card.Picks);
                        break;
                    /*
					case Enums.COLUMNS_CARDS.GATHERER_NAME:
                        value = card.GATHERER_Name;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_TYPE:
                        value = card.GATHERER_Type;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_TYPES:
                        value = ListIntToString(card.GATHERER_Types.Select(enumeration => (int)enumeration).ToList());
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_SUBTYPES:
                        value = ListIntToString(card.GATHERER_SubTypes.Select(enumeration => (int)enumeration).ToList());
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_SUPERTYPES:
                        value = ListIntToString(card.GATHERER_SuperTypes.Select(enumeration => (int)enumeration).ToList());
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_COLORS:
                        value = ListIntToString(card.GATHERER_Colors.Select(enumeration => (int)enumeration).ToList());
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_MANA_COST:
                        value = card.GATHERER_ManaCost;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_RARITY:
                        value = ListIntToString(card.GATHERER_Rarity.Select(enumeration => (int)enumeration).ToList());
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_POWER:
                        value = card.GATHERER_Power;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_TOUGHNESS:
                        value = card.GATHERER_Toughness;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_TEXT:
                        value = card.GATHERER_Text;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_IMAGE_NAME:
                        value = card.GATHERER_ImageName;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_NUMBER:
                        value = card.GATHERER_Number;
                        break;
					*/
                }
            }
            return value ?? "";
        }

        public override int GetObjectPropertyInteger(object objet, int column)
        {
            var value = 0;
            if (objet is Card)
            {
                var card = (Card)objet;
                switch ((Enums.COLUMNS_CARDS)column)
                {
                    case Enums.COLUMNS_CARDS.DATABASE_ID:
                        value = card.DataBaseID;
                        break;
                    case Enums.COLUMNS_CARDS.ID:
                        value = card.ID;
                        break;
					/*
                    case Enums.COLUMNS_CARDS.GATHERER_LOYALTY:
                        value = card.GATHERER_Loyalty;
                        break;
                    case Enums.COLUMNS_CARDS.GATHERER_MULTIVERSE_ID:
                        value = card.GATHERER_MultiverseID;
                        break;
                    case Enums.COLUMNS_CARDS.ACTIF:
                        value = BoolToInt(card.Actif);
                        break;
                    */
                }
            }
            return value;
        }

		public override double GetObjectPropertyDouble(object objet, int column)
        {
            var value = 0d;
            if (objet is Card)
            {
                var card = (Card)objet;
                switch ((Enums.COLUMNS_CARDS)column)
                {
                    case Enums.COLUMNS_CARDS.CMC:
                        value = card.CMC;
                        break;
					/*
                    case Enums.COLUMNS_CARDS.GATHERER_CMC:
                        value = card.GATHERER_CMC;
                        break;
                    */
                }
            }
            return value;
        }

        public override bool GetObjectPropertyBoolean(object objet, int column)
        {
            var value = false;
            if (objet is Card)
            {
                var card = (Card)objet;
                switch ((Enums.COLUMNS_CARDS)column)
                {
                    case Enums.COLUMNS_CARDS.ACTIF:
                        value = card.Actif;
                        break;
                }
            }
            return value;
        }

    }
}