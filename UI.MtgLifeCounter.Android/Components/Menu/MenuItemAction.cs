using System;

namespace UI.MtgLifeCounter.Android.Components.Menu
{
	public class MenuItemAction
	{

		public enum TYPE_ACTION { LOAD_FRAGMENT, LOAD_ACTIVITY, CLOSE_APPLICATION };

		public TYPE_ACTION TypeAction { get; set; }
		public Type Screen { get; set; }

		public Object GetScreenInstance()
		{
			return Activator.CreateInstance(Screen);
		}

	}
}

