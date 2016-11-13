using Android.App;
using Android.OS;
using Common.Android.DataBase.Managers;
using Common.AsyncTasks.Activities;

namespace Common.AsyncTasks.Tasks.Installation
{
    public class AsyncTaskDataBaseInstallation : BaseAsyncTask
    {

        public AsyncTaskDataBaseInstallation(Activity activity)
			:base(activity)
        {
        }

        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            var managerDataBase = new ManagerDataBaseBestiaire(Activity);
            return true;
        }

        protected override void OnPostExecute(Java.Lang.Object result)
        {
            base.OnPostExecute(result);
            ((ActivityDataBaseInstallation)Activity).OnDataBaseInstallationFinished();
        }

    }
}

