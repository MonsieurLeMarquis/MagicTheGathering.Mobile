using System;
using Android.App;
using Android.Views;
using UI.DraftBestiaire.Android.Activities;
using Android.OS;

namespace UI.DraftBestiaire.Android.Fragments
{
	public class RankingFragment : BaseFragment
	{

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) 
		{
			MyView = inflater.Inflate(Resource.Layout.Fragment_Ranking, container, false);
			MyActivity = base.Activity;
			return MyView;
		}

	}
}

