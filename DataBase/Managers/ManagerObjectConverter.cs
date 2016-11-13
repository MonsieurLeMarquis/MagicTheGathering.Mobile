using System.Collections.Generic;
using System.Linq;

namespace DataBase.Managers
{
    public abstract class BaseManagerObjectConverter
    {

        protected const char LIST_SEPARATOR = ';';

		protected string GetValueString(object value)
		{
			return value != null ? value.ToString() : "";
		}

		protected int GetValueInteger(object value)
		{
			return value != null && value is int ? (int)value : 0;
		}

		protected double GetValueDouble(object value)
		{
			return value != null && value is double ? (double)value : 0f;
		}

        public virtual object UpdateObjectProperty(object objet, int column, object value)
        {
            return objet;
        }

        public virtual string GetObjectPropertyString(object objet, int column)
        {
            return "";
        }

        public virtual int GetObjectPropertyInteger(object objet, int column)
        {
            return 0;
        }

		public virtual double GetObjectPropertyDouble(object objet, int column)
        {
            return 0d;
        }

        public virtual bool GetObjectPropertyBoolean(object objet, int column)
        {
            return false;
        }

        protected bool IntToBool(int value)
        {
            return value == 1;
        }

        protected int BoolToInt(bool value)
        {
            return value ? 1 : 0;
        }

        protected List<int> StringToListInt(string value)
        {
            return value.Split(LIST_SEPARATOR).Select(int.Parse).ToList();
        }

		protected List<double> StringToListDouble(string value)
        {
			return value.Split(LIST_SEPARATOR).Select(double.Parse).ToList();
        }

        protected string ListIntToString(List<int> value)
        {
            return string.Join(LIST_SEPARATOR.ToString(), value);
        }

		protected string ListDoubleToString(List<double> value)
        {
            return string.Join(LIST_SEPARATOR.ToString(), value);
        }

    }
}