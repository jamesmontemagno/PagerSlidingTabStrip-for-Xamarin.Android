using Android.Support.V4.App;
using Android.OS;
using Android.Support.V4.View;


using Android.Widget;

namespace Sample
{
	public class SuperAwesomeCardFragment : Fragment
	{
		private int position;
		public static SuperAwesomeCardFragment NewInstance(int position)
		{
			var f = new SuperAwesomeCardFragment ();
			var b = new Bundle ();
			b.PutInt("position", position);
			f.Arguments = b;
			return f;
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			position = Arguments.GetInt ("position");
		}


		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
		{
			var root = inflater.Inflate(Resource.Layout.fragment_card, container, false);
			var text = root.FindViewById<TextView> (Resource.Id.textView);
			text.Text = "Card: " + position;
			ViewCompat.SetElevation(root, 50);
			return root;
		}
	}
}

