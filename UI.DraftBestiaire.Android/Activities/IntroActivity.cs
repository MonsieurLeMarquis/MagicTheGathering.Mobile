using Android.App;
using Android.Widget;
using Android.OS;
using Common.Android.Activities;
using Common.AsyncTasks.Tasks.Installation;
using Common.AsyncTasks.Activities;
using Android.Content.PM;

namespace UI.DraftBestiaire.Android.Activities
{
	[Activity (Label = "DraftBestiaire", MainLauncher = true, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait)]
	public class IntroActivity : ActivityDataBaseInstallation
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            ManagerActivity.SetFullScreen(this);
            SetContentView (Resource.Layout.Activity_Intro);
			InitWidgets ();
			CreatEvents ();
			InstallDataBase ();
		}

		protected void InitWidgets ()
		{
			tvDebug = (TextView)FindViewById (Resource.Id.tvDebug);
		}

		protected void CreatEvents ()
		{
			Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				ManagerActivity.Launch (this, typeof(MainActivity));
			};
		}

		protected void InstallDataBase ()
		{
			Business.Ressources.Managers.ManagerBestiaire.GetAllDrafts (this, Business.Ressources.Enumerations.Enums.TYPE_LOAD.DATABASE_ONLY);
			Business.Ressources.Managers.ManagerBestiaire.GetAllEditions (this, Business.Ressources.Enumerations.Enums.TYPE_LOAD.DATABASE_ONLY);
			Business.Ressources.Managers.ManagerBestiaire.GetAllDrafts (this, Business.Ressources.Enumerations.Enums.TYPE_LOAD.FILE_ASSETS);
			Business.Ressources.Managers.ManagerBestiaire.GetAllEditions (this, Business.Ressources.Enumerations.Enums.TYPE_LOAD.FILE_ASSETS);
			new AsyncTaskDataBaseInstallation (this).Execute ();
		}

		public override void OnDataBaseInstallationFinished ()
		{
			ManagerActivity.Launch (this, typeof(MainActivity));
		}
	}
}
