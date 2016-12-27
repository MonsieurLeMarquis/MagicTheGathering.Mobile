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
            //  FLAG optimal = 7942
            //  -------------------
            //  2       Hide Navigation
            //  4       Fullscreen
            //  256     Layout Stable
            //  512     Layout Hide Navigation
            //  1024    Layout Fullscreen
            //  2048    Immersive
            //  4096    Immersive Sticky
            int flag = (int)SystemUiFlags.HideNavigation;
            flag += (int)SystemUiFlags.Fullscreen;
            flag += (int)SystemUiFlags.LayoutStable;
            flag += (int)SystemUiFlags.LayoutHideNavigation;
            flag += (int)SystemUiFlags.LayoutFullscreen;
            flag += (int)SystemUiFlags.Immersive;
            flag += (int)SystemUiFlags.ImmersiveSticky;
            activity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)flag;
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