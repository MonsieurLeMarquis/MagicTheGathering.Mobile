using Android.App;
using Android.OS;
using Common.Android.Activities;

namespace UI.DraftBestiaire.Android.Activities
{

    public class BaseActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ManagerActivity.SetFullScreen(this);
        }

        protected override void OnResume()
        {
            base.OnResume();
            ManagerActivity.ActivateKeepScreenOn(this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            ManagerActivity.DisactivateKeepScreenOn(this);
        }

    }

}