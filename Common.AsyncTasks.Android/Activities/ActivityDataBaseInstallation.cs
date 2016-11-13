using Android.App;
using Android.Widget;
using UI.MtgLifeCounter.Android.Activities;

namespace Common.AsyncTasks.Activities
{
    public abstract class ActivityDataBaseInstallation : BaseActivity
    {

        protected TextView tvDebug { get; set; }

        public virtual void OnDataBaseInstallationFinished() { }

    }
}