using DataBase.Bestiaire.Enumerations;
using DataBase.Managers;
using Objects.Bestiaire.DataBase.Cards;

namespace DataBase.Bestiaire.Managers
{
    public class ManagerObjectConverterDraft : BaseManagerObjectConverter
    {

        public override object UpdateObjectProperty(object objet, int column, object value)
        {
            if (objet is Draft)
            {
				var draft = (Draft)objet;
				var valueString = GetValueString(value);
				var valueInteger = GetValueInteger(value);
				var valueDouble = GetValueDouble(value);
                switch ((Enums.COLUMNS_DRAFTS)column)
                {
                    case Enums.COLUMNS_DRAFTS.DATABASE_ID:
                        draft.DataBaseID = valueInteger;
                        break;
                    case Enums.COLUMNS_DRAFTS.ID:
                        draft.ID = valueInteger;
                        break;
                    case Enums.COLUMNS_DRAFTS.NAME:
                        draft.Name = valueString;
                        break;
                    case Enums.COLUMNS_DRAFTS.EDITION_1:
                        draft.EditionsOrderID[1] = valueString;
                        break;
                    case Enums.COLUMNS_DRAFTS.EDITION_2:
                        draft.EditionsOrderID[2] = valueString;
                        break;
                    case Enums.COLUMNS_DRAFTS.EDITION_3:
                        draft.EditionsOrderID[3] = valueString;
                        break;
                    case Enums.COLUMNS_DRAFTS.HIGHLANDER:
                        draft.Highlander = IntToBool(valueInteger);
                        break;
                }
                objet = draft;
            }
            return objet;
        }

        public override string GetObjectPropertyString(object objet, int column)
        {
            var value = "";
            if (objet is Draft)
            {
                var draft = (Draft)objet;
                switch ((Enums.COLUMNS_DRAFTS)column)
                {
                    case Enums.COLUMNS_DRAFTS.NAME:
                        value = draft.Name;
                        break;
                    case Enums.COLUMNS_DRAFTS.EDITION_1:
                        value = draft.EditionsOrderID[1];
                        break;
                    case Enums.COLUMNS_DRAFTS.EDITION_2:
                        value = draft.EditionsOrderID[2];
                        break;
                    case Enums.COLUMNS_DRAFTS.EDITION_3:
                        value = draft.EditionsOrderID[3];
                        break;
                }
            }
            return value ?? "";
        }

        public override int GetObjectPropertyInteger(object objet, int column)
        {
            var value = 0;
            if (objet is Draft)
            {
                var draft = (Draft)objet;
                switch ((Enums.COLUMNS_DRAFTS)column)
                {
                    case Enums.COLUMNS_DRAFTS.DATABASE_ID:
                        value = draft.DataBaseID;
                        break;
                    case Enums.COLUMNS_DRAFTS.ID:
                        value = draft.ID;
                        break;
                    case Enums.COLUMNS_DRAFTS.HIGHLANDER:
                        value = BoolToInt(draft.Highlander);
                        break;
                }
            }
            return value;
        }

        public override double GetObjectPropertyDouble(object objet, int column)
        {
            return 0d;
        }

        public override bool GetObjectPropertyBoolean(object objet, int column)
        {
            var value = false;
            if (objet is Draft)
            {
                var draft = (Draft)objet; switch ((Enums.COLUMNS_DRAFTS)column)
                {
                    case Enums.COLUMNS_DRAFTS.HIGHLANDER:
                        value = draft.Highlander;
                        break;
                }
            }
            return value;
        }

    }
}