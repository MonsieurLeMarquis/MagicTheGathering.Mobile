using System;
using Android.App;
using Android.Views;
using UI.DraftBestiaire.Android.Activities;
using Android.OS;

namespace UI.DraftBestiaire.Android.Fragments
{
	public class PlaneswalkerPointsFragment : BaseFragment
	{

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) 
		{
			MyView = inflater.Inflate(Resource.Layout.Fragment_PlaneswalkerPoints, container, false);
			MyActivity = base.Activity;
			return MyView;
		}

	}
}

