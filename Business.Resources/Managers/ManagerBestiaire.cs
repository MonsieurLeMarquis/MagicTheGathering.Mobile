using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Ressources.Enumerations;
using Business.Ressources.Constants;
using Common.Android.Debug;
using Common.Android.IO;
using Common.Android.DataBase.Objects.Bestiaire;
using Objects.Bestiaire.DataBase.Cards;
using Android.App;

namespace Business.Ressources.Managers
{
    public class ManagerBestiaire
	{

		public static AllEditions GetAllEditions(Activity activity, Enums.TYPE_LOAD typeLoad)
		{
			var editions = new AllEditions();
			try
			{

				switch(typeLoad)
				{
				case Enums.TYPE_LOAD.FILE_ASSETS:
					// Chargement fichier ASSETS
					var json = File.ReadFileFromAsset(activity, ConstantsFiles.FileJsonBestiaireListEditions);
					editions.Editions = GetEditionsFromJson(json);
					var test = new EditionBDD(activity);
					test.BulkInsertEditions(editions.Editions);
					break;
				case Enums.TYPE_LOAD.DATABASE_ONLY:
					// Chargement en BD
					var editionsBDD = new EditionBDD(activity);
					editions.Editions = editionsBDD.GetEditions();
					break;
				case Enums.TYPE_LOAD.NETWORK_ONLY:
					// Chargement sur le réseau
					break;
				case Enums.TYPE_LOAD.CACHE_ONLY:
					// Chargement en cache
					editions = CacheObjects.BestiaireEditions ?? new AllEditions();
					break;
				case Enums.TYPE_LOAD.DISCONNECTED:
					// Cache d'abord, sinon BD
					break;
				case Enums.TYPE_LOAD.CONNECTED:
					// Cache d'abord, sinon BD
					break;
				}
			}
			catch(Exception ex)
			{
				ManagerTraces.AddTrace (new Error { Exception = ex });
			}
			return editions;
		}

		public static AllDrafts GetAllDrafts(Activity activity, Enums.TYPE_LOAD typeLoad)
		{
			var drafts = new AllDrafts();
			try
			{

				switch(typeLoad)
				{
				case Enums.TYPE_LOAD.FILE_ASSETS:
					// Chargement fichier ASSETS
					var json = File.ReadFileFromAsset(activity, ConstantsFiles.FileJsonBestiaireListDrafts);
					drafts.Drafts = GetDraftsFromJson(json);
					var test = new DraftBDD(activity);
					test.BulkInsertDrafts(drafts.Drafts);
					break;
				case Enums.TYPE_LOAD.DATABASE_ONLY:
					// Chargement en BD
					var draftsBDD = new DraftBDD(activity);
					drafts.Drafts = draftsBDD.GetDrafts();
					break;
				case Enums.TYPE_LOAD.NETWORK_ONLY:
					// Chargement sur le réseau
					break;
				case Enums.TYPE_LOAD.CACHE_ONLY:
					// Chargement en cache
					drafts = CacheObjects.BestiaireDrafts ?? new AllDrafts();
					break;
				case Enums.TYPE_LOAD.DISCONNECTED:
					// Cache d'abord, sinon BD
					break;
				case Enums.TYPE_LOAD.CONNECTED:
					// Cache d'abord, sinon BD
					break;
				}
			}
			catch(Exception ex)
			{
				ManagerTraces.AddTrace (new Error { Exception = ex });
			}
			return drafts;
		}

		protected static List<Edition> GetEditionsFromJson(string json)
		{
			var editions = new List<Edition> ();
			try
			{
				if (!string.IsNullOrEmpty(json))
				{
					var data = JsonConvert.DeserializeObject<List<Objects.Bestiaire.WebServices.Edition>>(json);
					if (data != null) 
					{
						editions = data.Select (edition => new Edition (edition)).ToList ();
					}
				}
			}
			catch(Exception ex)
			{
				ManagerTraces.AddTrace (new Error { Exception = ex });
			}
			return editions;
		}

		protected static List<Draft> GetDraftsFromJson(string json)
		{
			var drafts = new List<Draft> ();
			try
			{
				if (!string.IsNullOrEmpty(json))
				{
					var data = JsonConvert.DeserializeObject<Dictionary<int, Objects.Bestiaire.WebServices.Draft>>(json);
					if (data != null) 
					{
						data.Keys.ToList().ForEach(key => data[key].ID = key);
						data.Keys.ToList().ForEach(key => drafts.Add(new Draft(data[key])));
						drafts.Reverse();
					}
				}
			}
			catch(Exception ex)
			{
				ManagerTraces.AddTrace (new Error { Exception = ex });
			}
            return drafts;
        }

    }
}