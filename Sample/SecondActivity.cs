using System;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;
using com.refractored;
using Java.Interop;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace Sample
{
    [Activity(Label = "Icon Tab Sample", Icon = "@drawable/icon", ParentActivity = typeof(MainActivity))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = "MainActivity")]
    public class SecondActivity : BaseActivity, IOnTabReselectedListener, ViewPager.IOnPageChangeListener
    {
        private MyIconPagerAdapter adapter;
        private int count = 1;
        private int currentColor;
        private Drawable oldBackground;
        private ViewPager pager;
        private PagerSlidingTabStrip tabs;

        protected override int LayoutResource
        {
            get { return Resource.Layout.activity_main; }
        }

        public void OnPageScrollStateChanged(int state)
        {
            Console.WriteLine("Page scroll state changed: " + state);
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            Console.WriteLine("Page Scrolled");
        }

        public void OnPageSelected(int position)
        {
            Console.WriteLine("Page selected: " + position);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            adapter = new MyIconPagerAdapter(SupportFragmentManager);
            pager = FindViewById<ViewPager>(Resource.Id.pager);
            tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.tabs);
            pager.Adapter = adapter;
            tabs.SetViewPager(pager);

            var pageMargin = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Resources.DisplayMetrics);
            pager.PageMargin = pageMargin;
            pager.CurrentItem = 1;
            tabs.OnTabReselectedListener = this;
            tabs.OnPageChangeListener = this;

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            ChangeColor(Resources.GetColor(Resource.Color.green));
        }

        private void ChangeColor(Color newColor)
        {
            tabs.SetBackgroundColor(newColor);

            // change ActionBar color just if an ActionBar is available
            Drawable colorDrawable = new ColorDrawable(newColor);
            Drawable bottomDrawable = new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent));
            var ld = new LayerDrawable(new[] {colorDrawable, bottomDrawable});
            if (oldBackground == null)
            {
                SupportActionBar.SetBackgroundDrawable(ld);
            }
            else
            {
                var td = new TransitionDrawable(new[] {oldBackground, ld});
                SupportActionBar.SetBackgroundDrawable(td);
                td.StartTransition(200);
            }

            oldBackground = ld;
            currentColor = newColor;
        }

        [Export("onColorClicked")]
        public void OnColorClicked(View v)
        {
            var color = Color.ParseColor(v.Tag.ToString());
            ChangeColor(color);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("currentColor", currentColor);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            currentColor = savedInstanceState.GetInt("currentColor");
            ChangeColor(new Color(currentColor));
        }

        #region IOnTabReselectedListener implementation

        public void OnTabReselected(int position)
        {
            Toast.MakeText(this, "Tab reselected: " + position, ToastLength.Short).Show();
        }

        #endregion
    }

    public class MyIconPagerAdapter : FragmentStatePagerAdapter, ICustomTabProvider
    {
        private readonly int[] _icons =
        {
            Resource.Drawable.ic_home_white_48dp,
            Resource.Drawable.ic_people_white_48dp, Resource.Drawable.ic_attach_money_white_48dp
        };

        public MyIconPagerAdapter(FragmentManager fm)
            : base(fm)
        {
        }

        #region implemented abstract members of PagerAdapter

        public override int Count
        {
            get { return _icons.Length; }
        }

        #endregion

        #region implemented abstract members of FragmentPagerAdapter

        public override Fragment GetItem(int position)
        {
            return SuperAwesomeCardFragment.NewInstance(position);
        }

        #endregion

        #region CustomTabProvider

        public View GetCustomTabView(ViewGroup parent, int position)
        {
            var tablayout =
                (LinearLayout)
                    LayoutInflater.From(Application.Context).Inflate(Resource.Layout.tab_layout, parent, false);

            var tabImage = tablayout.FindViewById<ImageView>(Resource.Id.tabImage);

            tabImage.SetImageResource(_icons[position]);

            return tablayout;
        }

        #endregion
    }
}