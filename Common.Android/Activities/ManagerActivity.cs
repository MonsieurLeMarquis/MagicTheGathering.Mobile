using System;
using Android.Content;
using Android.App;
using Android.Views;

namespace Common.Android.Activities
{

    public class ManagerActivity
    {

        public static void Launch(Activity activity, Type classActivity)
        {
            Intent nextScreen = new Intent(activity.ApplicationContext, classActivity);
            activity.StartActivity(nextScreen);
        }

        public static void SetFullScreen(Activity activity)
        {
            // Barre de statut (heure, icône 3G / niveau batterie / ...
            HideStatusBar(activity);
            // Barre de titre de l'application + Three Dots Menu
            HideActionBar(activity);
            // Barre avec les boutons de navigation en bas de l'écran
            HideNavigationBar(activity);
        }

        public static void HideStatusBar(Activity activity)
        {
            activity.Window.AddFlags(WindowManagerFlags.Fullscreen);
        }

        public static void HideActionBar(Activity activity)
        {
            activity.ActionBar.Hide();
        }

        public static void HideNavigationBar(Activity activity)
        {
            View decorView = activity.Window.DecorView;
            var uiOptions = (int)decorView.SystemUiVisibility;
            var newUiOptions = (int)uiOptions;

            //newUiOptions |= (int)SystemUiFlags.LowProfile;
            //newUiOptions |= (int)SystemUiFlags.Fullscreen;
            newUiOptions |= (int)SystemUiFlags.HideNavigation;
            //newUiOptions |= (int)SystemUiFlags.Immersive;

            decorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;
        }




        public static void ActivateKeepScreenOn(Activity activity)
        {
            activity.Window.AddFlags(WindowManagerFlags.KeepScreenOn);
        }

        public static void DisactivateKeepScreenOn(Activity activity)
        {
            activity.Window.ClearFlags(WindowManagerFlags.KeepScreenOn);
        }

    }

}