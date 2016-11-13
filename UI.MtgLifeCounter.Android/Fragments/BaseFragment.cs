
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace UI.MtgLifeCounter.Android.Fragments
{
	public class BaseFragment : Fragment
	{

		protected View MyView;
		protected Activity MyActivity;

		public override void OnStart() {
			base.OnStart();
		}

	}
}

