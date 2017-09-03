using Android.App;
using Android.Widget;
using Android.Views;
using System;
using Android.Graphics;
using Android.Views.Animations;
using System.Collections.Generic;
using System.Linq;
using Common.Android.Fragments;
using UI.MtgLifeCounter.Android.Activities;
using Common.Android.Gesture;
using UI.MtgLifeCounter.Android.Fragments;
using Business.MtgLifeCounter.Managers;
using Business.MtgLifeCounter.Context;
using static Business.MtgLifeCounter.Enumerations.Enum;

namespace UI.MtgLifeCounter.Android.Components.Menu
{

	[Activity (Label = "DraftBestiaire", MainLauncher = false, Icon = "@mipmap/icon")]
	public class BaseActivityMenu : BaseActivity
	{

        //private GestureDetector gestureDetector;
		//public GestureListener gestureListener;
        private ListView menuListView;
        private MenuListAdapter objAdapterMenu;
        private ImageView menuIconImageView;
        private int intDisplayWidth;
        private bool isSingleTapFired = false;
        private TextView txtActionBarText;
        private TextView txtDescription;
        private ImageView btnDescExpander;
		private List<MenuItem> MenuItems = new List<MenuItem>();

        public Type CurrentFragment { get; set; }

        public MainFragment MainFragment { get; set; }

        protected void InitializeMenu(List<MenuItem> menuItems)
		{
			MenuItems = menuItems;
			FnInitialization (); 
			TapEvent ();  
			FnBindMenu ();
            CurrentFragment = typeof(MainFragment);
		}

		protected void TapEvent()
		{
			//title bar menu icon
			menuIconImageView.Click += delegate(object sender , EventArgs e )
			{
				if ( !isSingleTapFired )
				{
					FnToggleMenu ();  //find definition in below steps
					isSingleTapFired = false;
				}
			};
			//bottom expandable description window
			btnDescExpander.Click += delegate(object sender , EventArgs e )
			{
				FnDescriptionWindowToggle(); 
			};
		}

		protected void FnInitialization()
		{
			menuListView = FindViewById<ListView> ( Resource.Id.menuListView );
			menuIconImageView = FindViewById<ImageView> ( Resource.Id.menuIconImgView );
			txtActionBarText = FindViewById<TextView> ( Resource.Id.txtActionBarText );
			txtDescription=FindViewById<TextView> ( Resource.Id.txtDescription );
			btnDescExpander =FindViewById<ImageView> ( Resource.Id.btnImgExpander );

			//changed sliding menu width to 3/4 of screen width 
			Display display = this.WindowManager.DefaultDisplay; 
			var point = new Point ();
			display.GetSize (point);
			intDisplayWidth = point.X;
			intDisplayWidth=intDisplayWidth - (intDisplayWidth/3);
			using ( var layoutParams = ( RelativeLayout.LayoutParams ) menuListView.LayoutParameters  )
			{
				layoutParams.Width = intDisplayWidth;
				layoutParams.Height = ViewGroup.LayoutParams.MatchParent;
				menuListView.LayoutParameters = layoutParams;
			}  
		}

		protected void FnBindMenu()
		{   
			var strMnuText = MenuItems.Select (item => item.Label).ToArray();
			var strMnuUrl = MenuItems.Select (item => item.Icon).ToArray();
			if ( objAdapterMenu != null )
			{
				objAdapterMenu.actionMenuSelected -= FnMenuSelected;
				objAdapterMenu = null;
			}
			objAdapterMenu = new MenuListAdapter (this,strMnuText,strMnuUrl); 
			objAdapterMenu.actionMenuSelected += FnMenuSelected;
			menuListView.Adapter = objAdapterMenu;   
		}

		protected void FnMenuSelected(string strMenuText)
		{
			var menuItem = MenuItems.FirstOrDefault (item => item.Label == strMenuText);
			if (menuItem != null) {
				var action = menuItem.Action;
				switch (action.TypeAction) {
					case MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT:
						if ((Fragment)action.GetScreenInstance () is Fragment) {
                            // Affichage ou non du fragment principal et du fragment secondaire
                            var frameMain = FindViewById<FrameLayout>(Resource.Id.frame_main);
                            var frameContainer = FindViewById<FrameLayout>(Resource.Id.frame_container);
                            if (strMenuText == Resources.GetString(Resource.String.menu_main) && frameMain != null && frameContainer != null)
                            {
                                frameMain.Visibility = ViewStates.Visible;
                                frameContainer.Visibility = ViewStates.Gone;
                                btnDescExpander.Visibility = ViewStates.Visible;
                                txtDescription.Visibility = ViewStates.Visible;
                            }
                            else
                            {
                                frameMain.Visibility = ViewStates.Gone;
                                frameContainer.Visibility = ViewStates.Visible;
                                btnDescExpander.Visibility = ViewStates.Gone;
                                txtDescription.Visibility = ViewStates.Gone;
                            }
                            // Lancement du fragment
                            CurrentFragment = action.Screen;
                            ManagerFragment.Launch (base.FragmentManager, (Fragment)action.GetScreenInstance (), Resource.Id.frame_container);	
						}
						break;
					case MenuItemAction.TYPE_ACTION.LOAD_ACTIVITY:
						break;
					case MenuItemAction.TYPE_ACTION.CLOSE_APPLICATION:
						break;
				}
			}
		}

        protected void GestureMenuGestureLeft()
        {
            if (menuListView.IsShown)
                FnToggleMenu();
            isSingleTapFired = false;
        }

        protected void GestureMenuGestureRight()
        {
            if (!menuListView.IsShown)
                FnToggleMenu();
            isSingleTapFired = false;
        }

        protected void GestureMenuSingleTap()
        {
            if (menuListView.IsShown)
            {
                FnToggleMenu();
                isSingleTapFired = true;
            }
            else
            {
                isSingleTapFired = false;
            }
        }

        //toggling the left menu
        protected void FnToggleMenu()
		{
			Console.WriteLine ( menuListView.IsShown );
			if(menuListView.IsShown)
			{ 
				menuListView.Animation = new  TranslateAnimation ( 0f , -menuListView.MeasuredWidth , 0f , 0f );
				menuListView.Animation.Duration = 300;
				menuListView.Visibility = ViewStates.Gone;  
			}
			else
			{  
				menuListView.Visibility =   ViewStates.Visible; 
				menuListView.RequestFocus (); 
				menuListView.Animation = new  TranslateAnimation ( -menuListView.MeasuredWidth, 0f , 0f , 0f );//starting edge of layout 
				menuListView.Animation.Duration = 300;  
			}
		} 

		//bottom desription window sliding 
		protected void FnDescriptionWindowToggle()
		{
			if (txtDescription.IsShown) {  
				txtDescription.Visibility = ViewStates.Gone; 
				txtDescription.Animation = new  TranslateAnimation (0f, 0f, 0f, txtDescription.MeasuredHeight);
				txtDescription.Animation.Duration = 300;
				btnDescExpander.SetImageResource (Resource.Drawable.up_arrow); 
			} else {
                txtDescription.Text = "DEV"/*ManagerHistory.GetString(HistoryReference)*/;
				txtDescription.Visibility = ViewStates.Visible;
				txtDescription.RequestFocus (); 
				txtDescription.Animation = new  TranslateAnimation (0f, 0f, txtDescription.MeasuredHeight, 0f);
				txtDescription.Animation.Duration = 300;   
				btnDescExpander.SetImageResource (Resource.Drawable.down_arrow);
			}
		}
	}
}


