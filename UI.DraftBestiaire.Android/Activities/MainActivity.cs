using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using UI.DraftBestiaire.Android.Components.Menu;
using System;
using Android.Graphics;
using Android.Views.Animations;
using System.Collections.Generic;
using UI.DraftBestiaire.Android.Fragments;
using Common.Android.Activities;
using Android.Content.PM;

namespace UI.DraftBestiaire.Android.Activities
{
	
	[Activity (Label = "DraftBestiaire", MainLauncher = false, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : BaseActivityMenu
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            ManagerActivity.SetFullScreen(this);
            SetContentView (Resource.Layout.Activity_Main);
			InitializeMenu (ResourcesMenu.ListMenuItems(this));
		}

	}
}


