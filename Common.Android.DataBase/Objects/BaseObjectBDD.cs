using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Common.Android.DataBase.Managers;
using DataBase.Enumerations;
using DataBase.Managers;
using DataBase.Objects;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Common.Android.DataBase.Objects
{
    public class BaseObjectBDD
    {

        protected SQLiteDatabase BDD;
        protected BaseManagerDataBase ManagerDataBase;
        protected BaseManagerObjectConverter ManagerObjectConverter;
        protected BaseTable Table;

        public virtual object CreateObject()
        {
            return new object();
        }

        public virtual List<object> CreateListObjects()
        {
            return new List<object>();
        }

        public void Open()
        {
            BDD = ManagerDataBase.WritableDatabase;
        }

        public void Close()
        {
            BDD.Close();
        }

        public void BulkInsert(List<object> objects)
        {
            SQLiteStatement statement = BDD.CompileStatement(ManagerScripts.GenerateBulkInsert(Table));
            BDD.BeginTransaction();
            foreach (object data in objects)
            {
				statement.ClearBindings();
				int index = 1;
				foreach (KeyValuePair<int, Column> column in GetColumnsWithoutDataBaseID())
				{
					switch (column.Value.Type)
					{
					case Enums.DATABASE_TYPE.INTEGER:
						statement.BindLong(index, ManagerObjectConverter.GetObjectPropertyInteger(data, column.Key));
						break;
					case Enums.DATABASE_TYPE.DOUBLE:
						statement.BindDouble(index, ManagerObjectConverter.GetObjectPropertyDouble(data, column.Key));
						break;
					case Enums.DATABASE_TYPE.TEXT:
						statement.BindString(index, ManagerObjectConverter.GetObjectPropertyString(data, column.Key));
						break;
					}
					index++;
				}	
                statement.Execute();
            }
            BDD.SetTransactionSuccessful();
            BDD.EndTransaction();
        }
        
        public long Insert(object data)
        {
            return BDD.Insert(Table.Name, null, GenerateContentValues(data));
        }

        public int Update(object data)
        {
            var columnID = GetColumnDataBaseID();
            return BDD.Update(Table.Name, GenerateContentValues(data), columnID.Value.Name + " = " + ManagerObjectConverter.GetObjectPropertyInteger(data, columnID.Key).ToString(), null);
        }

        public int RemoveEdition(object data)
        {
            var columnID = GetColumnDataBaseID();
            return BDD.Delete(Table.Name, columnID.Value.Name + " = " + ManagerObjectConverter.GetObjectPropertyInteger(data, columnID.Key).ToString(), null);
        }

        protected List<object> SelectAll()
        {
            var columns = GetAllColumns().Select(column => column.Value.Name).ToArray();
			ICursor Cursor = BDD.Query(Table.Name, columns, null, null, null, null, null);
            return CursorToList(Cursor);
        }

		protected List<object> CursorToList(ICursor Cursor)
        {
            List<object> objects = CreateListObjects();
            if (Cursor != null && Cursor.Count > 0)
            {
                var first = true;
                while (Cursor.MoveToNext())
                {
                    if (first)
                    {
                        Cursor.MoveToFirst();
                        first = false;
                    }
                    object currentObject = CreateObject();
                    var index = 0;
                    foreach(KeyValuePair<int, Column> column in GetAllColumns())
                    {
                        object value = null;
                        switch (column.Value.Type)
                        {
                            case Enums.DATABASE_TYPE.INTEGER:
                                value = Cursor.GetInt(index);
                                break;
                            case Enums.DATABASE_TYPE.DOUBLE:
                                value = Cursor.GetDouble(index);
                                break;
                            case Enums.DATABASE_TYPE.TEXT:
                                value = Cursor.GetString(index);
                                break;
                        }
                        currentObject = ManagerObjectConverter.UpdateObjectProperty(currentObject, column.Key, value);
                        index++;
                    }
                    objects.Add(currentObject);
                }
                Cursor.Close();
            }
            return objects;
        }

        protected ContentValues GenerateContentValues(object data)
        {
            ContentValues values = new ContentValues();
            foreach (KeyValuePair<int, Column> column in GetColumnsWithoutDataBaseID())
            {
                switch (column.Value.Type)
                {
                    case Enums.DATABASE_TYPE.INTEGER:
                        values.Put(column.Value.Name, ManagerObjectConverter.GetObjectPropertyInteger(data, column.Key));
                        break;
					case Enums.DATABASE_TYPE.DOUBLE:
                        values.Put(column.Value.Name, ManagerObjectConverter.GetObjectPropertyDouble(data, column.Key));
                        break;
                    case Enums.DATABASE_TYPE.TEXT:
                        values.Put(column.Value.Name, ManagerObjectConverter.GetObjectPropertyString(data, column.Key));
                        break;
                }
            }
            return values;
        }

        protected List<KeyValuePair<int, Column>> GetAllColumns()
        {
            return Table.Columns.ToList();
        }

        protected List<KeyValuePair<int, Column>> GetColumnsWithoutDataBaseID()
        {
            return Table.Columns
                .Where(column => !column.Value.PrimaryKey)
                .ToList();
        }

        protected KeyValuePair<int, Column> GetColumnDataBaseID()
        {
            return Table.Columns
                .First(column => column.Value.PrimaryKey);
        }

    }
}