using System;
using Android.App;
using Android.Views;
using UI.DraftBestiaire.Android.Activities;
using Android.OS;

namespace UI.DraftBestiaire.Android.Fragments
{
	public class AboutFragment : BaseFragment
	{

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) 
		{
			MyView = inflater.Inflate(Resource.Layout.Fragment_About, container, false);
			MyActivity = base.Activity;
			return MyView;
		}

	}
}

