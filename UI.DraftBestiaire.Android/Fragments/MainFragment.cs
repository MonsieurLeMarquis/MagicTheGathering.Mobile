using System;
using Android.App;
using Android.Views;
using UI.DraftBestiaire.Android.Activities;
using UI.DraftBestiaire.Android.Adaptaters;
using Android.OS;
using Android.Widget;
using Business.Ressources.Managers;

namespace UI.DraftBestiaire.Android.Fragments
{
	public class MainFragment : BaseFragment
	{

		private Spinner SpinnerDrafts;
		private Spinner SpinnerEditions1;
		private Spinner SpinnerEditions2;
		private Spinner SpinnerEditions3;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) 
		{
			MyView = inflater.Inflate(Resource.Layout.Fragment_Main, container, false);
			MyActivity = base.Activity;
			InitializeComponents ();
			return MyView;
		}

		public void InitializeComponents()
		{
			// Chargement des composants
			SpinnerDrafts = (Spinner) MyView.FindViewById(Resource.Id.spinnerDrafts);
			SpinnerEditions1 = (Spinner) MyView.FindViewById(Resource.Id.spinnerEditions1);
			SpinnerEditions2 = (Spinner) MyView.FindViewById(Resource.Id.spinnerEditions2);
			SpinnerEditions3 = (Spinner) MyView.FindViewById(Resource.Id.spinnerEditions3);

			// Chargement de la liste des drafts et de la liste des éditions
			var drafts = ManagerBestiaire.GetAllDrafts (MyActivity, Business.Ressources.Enumerations.Enums.TYPE_LOAD.DATABASE_ONLY);
			var editions = ManagerBestiaire.GetAllEditions (MyActivity, Business.Ressources.Enumerations.Enums.TYPE_LOAD.DATABASE_ONLY);

			// Remplissage des listes
			var adapterDrafts = new SpinnerDraftsAdaptater(MyActivity, Android.Resource.Layout.Spinner_Drafts, drafts.Drafts);
			var adapterEditions = new SpinnerEditionsAdaptater(MyActivity, Android.Resource.Layout.Spinner_Editions, editions.Editions);
			SpinnerDrafts.Adapter = adapterDrafts;
			SpinnerEditions1.Adapter = adapterEditions;
			SpinnerEditions2.Adapter = adapterEditions;
			SpinnerEditions3.Adapter = adapterEditions;
		}

		private void SpinnerDrafts_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			/*
			Spinner spinner = (Spinner)sender;
			string toast = string.Format ("The planet is {0}", spinner.GetItemAtPosition (e.Position));
			Toast.MakeText (this, toast, ToastLength.Long).Show ();
			*/
		}

		private void SpinnerEditions_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			/*
			Spinner spinner = (Spinner)sender;
			string toast = string.Format ("The planet is {0}", spinner.GetItemAtPosition (e.Position));
			Toast.MakeText (this, toast, ToastLength.Long).Show ();
			*/
		}

	}
}

