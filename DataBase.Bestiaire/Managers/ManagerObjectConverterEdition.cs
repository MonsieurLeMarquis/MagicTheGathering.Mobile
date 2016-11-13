using DataBase.Bestiaire.Enumerations;
using DataBase.Managers;
using Objects.Bestiaire.DataBase.Cards;

namespace DataBase.Bestiaire.Managers
{
    public class ManagerObjectConverterEdition : BaseManagerObjectConverter
    {

        public override object UpdateObjectProperty(object objet, int column, object value)
        {
            if (objet is Edition)
            {
                var edition = (Edition)objet;
				var valueString = GetValueString(value);
				var valueInteger = GetValueInteger(value);
				var valueDouble = GetValueDouble(value);
                switch ((Enums.COLUMNS_EDITIONS)column)
                {
                    case Enums.COLUMNS_EDITIONS.DATABASE_ID:
                        edition.DataBaseID = valueInteger;
                        break;
                    case Enums.COLUMNS_EDITIONS.ID:
                        edition.ID = valueString;
                        break;
                    case Enums.COLUMNS_EDITIONS.NAME:
                        edition.Name = valueString;
                        break;
					case Enums.COLUMNS_EDITIONS.PREMIUMS:
						edition.Premiums = IntToBool(valueInteger);
                        break;
					case Enums.COLUMNS_EDITIONS.TRICOLORS:
						edition.Tricolors = IntToBool(valueInteger);
                        break;
					case Enums.COLUMNS_EDITIONS.MYTHICS:
						edition.Mythics = IntToBool(valueInteger);
                        break;
                    case Enums.COLUMNS_EDITIONS.LANDS:
						edition.Lands = IntToBool(valueInteger);
                        break;
                    case Enums.COLUMNS_EDITIONS.TRANSFORMS:
						edition.Transforms = IntToBool(valueInteger);
                        break;
					case Enums.COLUMNS_EDITIONS.NB_MYTHICS:
						edition.NbMythics = valueDouble;
						break;
					case Enums.COLUMNS_EDITIONS.NB_RARES:
						edition.NbRares = valueDouble;
						break;
					case Enums.COLUMNS_EDITIONS.NB_UNCOS:
						edition.NbUncos = valueDouble;
						break;
					case Enums.COLUMNS_EDITIONS.NB_COMMUNES:
						edition.NbCommunes = valueDouble;
						break;
					case Enums.COLUMNS_EDITIONS.NB_RARES_SPECIALES:
						edition.NbRaresSpeciales = valueDouble;
						break;
					case Enums.COLUMNS_EDITIONS.NB_UNCOS_SPECIALES:
						edition.NbUncosSpeciales = valueDouble;
						break;
					case Enums.COLUMNS_EDITIONS.NB_COMMUNES_SPECIALES:
						edition.NbCommunesSpeciales = valueDouble;
						break;
                    case Enums.COLUMNS_EDITIONS.DATA_GATHERER_LOADED:
                        edition.DataGathererLoaded = IntToBool(valueInteger);
                        break;
                    case Enums.COLUMNS_EDITIONS.DATA_BESTIAIRE_LOADED:
                        edition.DataBestiaireLoaded = IntToBool(valueInteger);
                        break;
                    case Enums.COLUMNS_EDITIONS.DATA_IMAGES_LOADED:
                        edition.DataImagesLoaded = IntToBool(valueInteger);
                        break;
                }
                objet = edition;
            }
            return objet;
        }

        public override string GetObjectPropertyString(object objet, int column)
        {
            var value = "";
            if (objet is Edition)
            {
                var edition = (Edition)objet;
                switch ((Enums.COLUMNS_EDITIONS)column)
                {
                    case Enums.COLUMNS_EDITIONS.ID:
                        value = edition.ID;
                        break;
                    case Enums.COLUMNS_EDITIONS.NAME:
                        value = edition.Name;
                        break;
                }
            }
            return value ?? "";
        }

        public override int GetObjectPropertyInteger(object objet, int column)
        {
            var value = 0;
            if (objet is Edition)
            {
                var edition = (Edition)objet;
                switch ((Enums.COLUMNS_EDITIONS)column)
                {
                    case Enums.COLUMNS_EDITIONS.DATABASE_ID:
                        value = edition.DataBaseID;
						break;
					case Enums.COLUMNS_EDITIONS.PREMIUMS:
						value = BoolToInt(edition.Premiums);
						break;
					case Enums.COLUMNS_EDITIONS.TRICOLORS:
						value = BoolToInt(edition.Tricolors);
						break;
					case Enums.COLUMNS_EDITIONS.MYTHICS:
						value = BoolToInt(edition.Mythics);
						break;
					case Enums.COLUMNS_EDITIONS.LANDS:
						value = BoolToInt(edition.Lands);
						break;
					case Enums.COLUMNS_EDITIONS.TRANSFORMS:
						value = BoolToInt(edition.Transforms);
						break;
					case Enums.COLUMNS_EDITIONS.DATA_GATHERER_LOADED:
						value = BoolToInt(edition.DataGathererLoaded);
						break;
					case Enums.COLUMNS_EDITIONS.DATA_BESTIAIRE_LOADED:
						value = BoolToInt(edition.DataBestiaireLoaded);
						break;
					case Enums.COLUMNS_EDITIONS.DATA_IMAGES_LOADED:
						value = BoolToInt(edition.DataImagesLoaded);
						break;
                }
            }
            return value;
        }

        public override double GetObjectPropertyDouble(object objet, int column)
        {
			var value = 0d;
			if (objet is Edition) 
			{
				var edition = (Edition)objet;
				switch ((Enums.COLUMNS_EDITIONS)column) 
				{
					case Enums.COLUMNS_EDITIONS.NB_MYTHICS:
						value = edition.NbMythics;
						break;
					case Enums.COLUMNS_EDITIONS.NB_RARES:
						value = edition.NbRares;
						break;
					case Enums.COLUMNS_EDITIONS.NB_UNCOS:
						value = edition.NbUncos;
						break;
					case Enums.COLUMNS_EDITIONS.NB_COMMUNES:
						value = edition.NbCommunes;
						break;
					case Enums.COLUMNS_EDITIONS.NB_RARES_SPECIALES:
						value = edition.NbRaresSpeciales;
						break;
					case Enums.COLUMNS_EDITIONS.NB_UNCOS_SPECIALES:
						value = edition.NbUncosSpeciales;
						break;
					case Enums.COLUMNS_EDITIONS.NB_COMMUNES_SPECIALES:
						value = edition.NbCommunesSpeciales;
						break;
				}
			}
			return value;
        }

        public override bool GetObjectPropertyBoolean(object objet, int column)
        {
            var value = false;
            if (objet is Edition)
            {
                var edition = (Edition)objet; 
				switch ((Enums.COLUMNS_EDITIONS)column)
				{
					case Enums.COLUMNS_EDITIONS.PREMIUMS:
						value = edition.Premiums;
						break;
					case Enums.COLUMNS_EDITIONS.TRICOLORS:
						value = edition.Tricolors;
						break;
					case Enums.COLUMNS_EDITIONS.MYTHICS:
						value = edition.Mythics;
						break;
					case Enums.COLUMNS_EDITIONS.LANDS:
						value = edition.Lands;
						break;
					case Enums.COLUMNS_EDITIONS.TRANSFORMS:
						value = edition.Transforms;
						break;
                    case Enums.COLUMNS_EDITIONS.DATA_GATHERER_LOADED:
                        value = edition.DataGathererLoaded;
                        break;
                    case Enums.COLUMNS_EDITIONS.DATA_BESTIAIRE_LOADED:
                        value = edition.DataBestiaireLoaded;
                        break;
                    case Enums.COLUMNS_EDITIONS.DATA_IMAGES_LOADED:
                        value = edition.DataImagesLoaded;
                        break;
                }
            }
            return value;
        }

    }
}