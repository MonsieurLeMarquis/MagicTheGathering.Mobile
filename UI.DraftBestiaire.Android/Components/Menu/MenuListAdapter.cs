using System;
using Android.Widget;
using Android.App;
using System.Linq;
using Android.Views;
using Android;

namespace UI.DraftBestiaire.Android.Components.Menu
{

	public class MenuListAdapter : BaseAdapter<string> {
		
		Activity _context;
		string[] _mnuText;
		int[] _mnuUrl;
		internal event Action<string> actionMenuSelected;

		public MenuListAdapter(Activity context,string[] strMnu,int[] intImage)
		{
			_context = context;
			_mnuText = strMnu;
			_mnuUrl = intImage;
		}

		public override string this[int position]
		{
			get { return this._mnuText[position]; }
		}

		public override int Count
		{
			get { return this._mnuText.Count(); }
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{ 
			MenuListViewHolderClass objMenuListViewHolderClass;
			View view;
			view = convertView;
			if ( view == null )
			{
				view= _context.LayoutInflater.Inflate ( Resource.Layout.Fragment_Menu_Item , parent , false );
				objMenuListViewHolderClass = new MenuListViewHolderClass ();

				objMenuListViewHolderClass.txtMnuText = view.FindViewById<TextView> ( Resource.Id.txtMnuText );
				objMenuListViewHolderClass.ivMenuImg=view.FindViewById<ImageView> ( Resource.Id.ivMenuImg );

				objMenuListViewHolderClass.initialize ( view );
				view.Tag = objMenuListViewHolderClass;
			}
			else
			{
				objMenuListViewHolderClass = ( MenuListViewHolderClass ) view.Tag;
			}
			objMenuListViewHolderClass.viewClicked = () =>
			{
				if ( actionMenuSelected != null )
				{
					actionMenuSelected ( _mnuText[position] );
				}
			};
			objMenuListViewHolderClass.txtMnuText.Text = _mnuText [position];
			objMenuListViewHolderClass.ivMenuImg.SetImageResource ( _mnuUrl [position] );
			return view;
		}
	}

	internal class MenuListViewHolderClass:Java.Lang.Object
	{
		internal Action viewClicked{ get; set;}
		internal TextView txtMnuText;
		internal ImageView ivMenuImg;
		public void initialize(View view)
		{
			view.Click += delegate
			{
				viewClicked();
			};
		}

	}

}

