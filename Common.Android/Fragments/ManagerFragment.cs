using System;
using Android.App;

namespace Common.Android.Fragments
{
	public class ManagerFragment
	{

		public static void Launch(FragmentManager fragmentManager, Fragment fragment, int idContainer)
		{						
			if (fragment != null) {
				fragmentManager.BeginTransaction().Replace(idContainer, fragment).Commit();
			}
		}
		
	}
}

