using System;
using Android.App;
using Android.Views;
using UI.MtgLifeCounter.Android.Activities;
using Android.OS;

namespace UI.MtgLifeCounter.Android.Fragments
{
	public class SearchFragment : BaseFragment
	{

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) 
		{
			MyView = inflater.Inflate(Resource.Layout.Fragment_Search, container, false);
			MyActivity = base.Activity;
			return MyView;
		}

	}
}

