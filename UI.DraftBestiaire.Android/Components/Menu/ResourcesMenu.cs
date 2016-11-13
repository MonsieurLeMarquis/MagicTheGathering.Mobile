using System;
using System.Collections.Generic;
using Android.App;
using UI.DraftBestiaire.Android.Fragments;
using UI.DraftBestiaire.Android.Components.Menu;

namespace UI.DraftBestiaire.Android.Components.Menu
{
	public class ResourcesMenu
	{

		public static List<MenuItem> ListMenuItems(Activity activity)
		{
			return new List<MenuItem> () {
				new MenuItem () { 
					Label = activity.GetString (Resource.String.menu_play_draft), 
					Icon = Resource.Drawable.menu_home,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
						Screen = typeof(MainFragment)
					}
				},
				new MenuItem () { 
					Label = activity.GetString (Resource.String.menu_display_edition), 
					Icon = Resource.Drawable.menu_search,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
						Screen = typeof(DisplayEditionFragment)
					}
				},
				new MenuItem () { 
					Label = activity.GetString (Resource.String.menu_ranking), 
					Icon = Resource.Drawable.menu_ranking,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
						Screen = typeof(RankingFragment)
					}
				},
				new MenuItem () { 
					Label = activity.GetString (Resource.String.menu_planeswalker_points), 
					Icon = Resource.Drawable.menu_dci,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
						Screen = typeof(PlaneswalkerPointsFragment)
					}
				},
				new MenuItem () { 
					Label = activity.GetString (Resource.String.menu_settings), 
					Icon = Resource.Drawable.menu_settings,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
						Screen = typeof(SettingsFragment)
					} 
				},
				new MenuItem () { 
					Label = activity.GetString (Resource.String.menu_about), 
					Icon = Resource.Drawable.menu_about,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
						Screen = typeof(AboutFragment)
					} 
				},
				new MenuItem () { 
					Label = activity.GetString (Resource.String.menu_debug), 
					Icon = Resource.Drawable.menu_debug,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
						Screen = typeof(DebugFragment)
					} 
				},
				new MenuItem () { 
					Label = activity.GetString (Resource.String.menu_close), 
					Icon = Resource.Drawable.menu_close,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.CLOSE_APPLICATION
					} 
				}
			};
		}
			
	}
}

