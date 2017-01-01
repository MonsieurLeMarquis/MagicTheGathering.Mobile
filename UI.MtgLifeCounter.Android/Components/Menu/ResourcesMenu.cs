using System;
using System.Collections.Generic;
using UI.MtgLifeCounter.Android.Components.Menu;
using Android.App;
using UI.MtgLifeCounter.Android.Fragments;

namespace UI.MtgLifeCounter.Android.Components.Menu
{
	public class ResourcesMenu
	{

		public static List<MenuItem> ListMenuItems(Activity activity)
		{
			return new List<MenuItem> () {
                new MenuItem () {
                    Label = activity.GetString (Resource.String.menu_main),
                    Icon = Resource.Drawable.menu_history,
                    Action = new MenuItemAction {
                        TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
                        Screen = typeof(HistoryFragment)
                    }
                },
                new MenuItem () { 
					Label = activity.GetString (Resource.String.menu_dice), 
					Icon = Resource.Drawable.menu_dice,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
						Screen = typeof(DiceFragment)
					}
				},
				new MenuItem () { 
					Label = activity.GetString (Resource.String.menu_help), 
					Icon = Resource.Drawable.menu_help,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
						Screen = typeof(HelpFragment)
					}
				},
				new MenuItem () { 
					Label = activity.GetString (Resource.String.menu_reload), 
					Icon = Resource.Drawable.menu_reload,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
						Screen = typeof(ReloadFragment)
					}
				},
				new MenuItem () { 
					Label = activity.GetString (Resource.String.menu_rules), 
					Icon = Resource.Drawable.menu_rules,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
						Screen = typeof(RulesFragment)
					}
				},
				new MenuItem () { 
					Label = activity.GetString (Resource.String.menu_search), 
					Icon = Resource.Drawable.menu_search,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
						Screen = typeof(SearchFragment)
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
					Label = activity.GetString (Resource.String.menu_rate), 
					Icon = Resource.Drawable.menu_rate,
					Action = new MenuItemAction {
						TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
						Screen = typeof(RateFragment)
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

