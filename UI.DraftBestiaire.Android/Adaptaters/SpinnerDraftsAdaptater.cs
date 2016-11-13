using System;
using Android.Widget;
using Objects.Bestiaire.DataBase.Cards;
using Android.App;
using System.Collections.Generic;
using Android.Views;

namespace UI.DraftBestiaire.Android.Adaptaters
{
	public class SpinnerDraftsAdaptater : ArrayAdapter<Draft>
	{
		
		private Activity Activity;
		List<Draft> Data = null;

		public SpinnerDraftsAdaptater(Activity context, int resource, List<Draft> data)
			: base(context, resource, data)
		{
			Activity = context;
			Data = data;
		}

		public override View GetView(int position, View convertView, ViewGroup parent) 
		{  
			View view = convertView ?? Activity.LayoutInflater.Inflate(Resource.Layout.Spinner_Drafts_Selection, parent, false);
			Draft draft = Data[position];
			if (draft != null)
			{   
				TextView name = (TextView) view.FindViewById(Resource.Id.draftName);
				TextView edition1 = (TextView) view.FindViewById(Resource.Id.draftEditionCode1);
				TextView edition2 = (TextView) view.FindViewById(Resource.Id.draftEditionCode2);
				TextView edition3 = (TextView) view.FindViewById(Resource.Id.draftEditionCode3);
				if (name != null)
				{
					name.Text = draft.Name;
				}
				if (edition1 != null)
				{
					edition1.Text = draft.EditionsOrderID[1];
				}
				if (edition2 != null)
				{
					edition2.Text = draft.EditionsOrderID[2];
				}
				if (edition3 != null)
				{
					edition3.Text = draft.EditionsOrderID[3];
				}
			}
			return view;
		}

		public override View GetDropDownView(int position, View convertView, ViewGroup parent)
		{   
			View view = convertView ?? Activity.LayoutInflater.Inflate(Resource.Layout.Spinner_Drafts, parent, false);
			Draft draft = Data[position];
			if (draft != null)
			{   
				TextView name = (TextView) view.FindViewById(Resource.Id.draftName);
				TextView edition1 = (TextView) view.FindViewById(Resource.Id.draftEditionCode1);
				TextView edition2 = (TextView) view.FindViewById(Resource.Id.draftEditionCode2);
				TextView edition3 = (TextView) view.FindViewById(Resource.Id.draftEditionCode3);
				if (name != null)
				{
					name.Text = draft.Name;
				}
				if (edition1 != null)
				{
					edition1.Text = draft.EditionsOrderID[1];
				}
				if (edition2 != null)
				{
					edition2.Text = draft.EditionsOrderID[2];
				}
				if (edition3 != null)
				{
					edition3.Text = draft.EditionsOrderID[3];
				}
			}
			return view;
		}

	}
}