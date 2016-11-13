using System;
using Android.OS;
using Android.App;

namespace Common.AsyncTasks.Tasks
{
	public class BaseAsyncTask : AsyncTask
	{

		protected Activity Activity { get; set; }

		public BaseAsyncTask(Activity activity)
		{
			Activity = activity;
		}

		protected override void OnPreExecute()
		{
		}

		protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
		{
			return true;
		}

		protected override void OnPostExecute(Java.Lang.Object result)
		{
		}
			
	}
}

