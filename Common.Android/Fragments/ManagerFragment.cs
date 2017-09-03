using System;
using Android.App;
using System.Collections.Generic;

namespace Common.Android.Fragments
{
	public class ManagerFragment
    {

        private static Dictionary<Type, Fragment> fragments = new Dictionary<Type, Fragment>();

        public static void RegisterFragment(Fragment fragment)
        {
            var type = typeof(Fragment);
            if (fragments.ContainsKey(type))
            {
                fragments[type] = fragment;
            }
            else
            {
                fragments.Add(type, fragment);
            }
        }

        public static Fragment GetFragment(Type type)
        {
            return fragments.ContainsKey(type) ? fragments[type] : null;
        }

        public static void Launch(FragmentManager fragmentManager, Fragment fragment, int idContainer)
		{						
			if (fragment != null) {
                RegisterFragment(fragment);
				fragmentManager.BeginTransaction().Replace(idContainer, fragment).Commit();
			}
		}
		
	}
}

