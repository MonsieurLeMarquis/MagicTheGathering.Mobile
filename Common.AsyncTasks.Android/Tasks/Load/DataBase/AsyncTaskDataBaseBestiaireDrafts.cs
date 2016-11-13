using Android.App;
using Android.OS;
using Common.AsyncTasks.Tasks;

namespace Common.AsyncTasks.Load.DataBase
{
	public class AsyncTaskDataBaseBestiaireDrafts : BaseAsyncTask
	{
		
		public AsyncTaskDataBaseBestiaireDrafts (Activity activity)
			:base(activity)
		{
		}

		protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
		{
			return true;
		}

		protected override void OnPostExecute(Java.Lang.Object result)
		{
			base.OnPostExecute(result);
		}

	}
}

