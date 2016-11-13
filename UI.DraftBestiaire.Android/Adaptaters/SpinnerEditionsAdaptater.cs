using System;
using Android.Widget;
using Objects.Bestiaire.DataBase.Cards;
using Android.App;
using System.Collections.Generic;
using Android.Views;

namespace UI.DraftBestiaire.Android.Adaptaters
{
	public class SpinnerEditionsAdaptater : ArrayAdapter<Edition>
	{
		
		private Activity Activity;
		List<Edition> Data = null;

		public SpinnerEditionsAdaptater(Activity context, int resource, List<Edition> data)
			: base(context, resource, data)
		{
			Activity = context;
			Data = data;
		}

		public override View GetView(int position, View convertView, ViewGroup parent) 
		{  
			View view = convertView ?? Activity.LayoutInflater.Inflate(Resource.Layout.Spinner_Drafts_Selection, parent, false);
            Edition edition = Data[position];
			if (edition != null)
			{   
				TextView id = (TextView) view.FindViewById(Resource.Id.editionID);
				TextView name = (TextView) view.FindViewById(Resource.Id.editionName);
				if (id != null)
				{
					id.Text = edition.ID;
				}
				if (name != null)
				{
					name.Text = edition.Name;
				}
			}
			return view;
		}

		public override View GetDropDownView(int position, View convertView, ViewGroup parent)
		{   
			View view = convertView ?? Activity.LayoutInflater.Inflate(Resource.Layout.Spinner_Drafts_Selection, parent, false);
			Edition edition = Data[position];
			if (edition != null)
			{   
				TextView id = (TextView) view.FindViewById(Resource.Id.editionID);
				TextView name = (TextView) view.FindViewById(Resource.Id.editionName);
				if (id != null)
				{
					id.Text = edition.ID;
				}
				if (name != null)
				{
					name.Text = edition.Name;
				}
			}
			return view;
		}

	}
}