# Getting Started with Pager Sliding Tab Strip

*For a working implementation of this project see the `Sample/` folder.*

  1. Download Component

  2. Include the PagerSlidingTabStrip widget in your layout. This should usually be placed
     above the `ViewPager` it represents.

        <com.refractored.PagerSlidingTabStrip
            android:id="@+id/tabs"
            android:layout_width="match_parent"
            android:layout_height="?attr/actionBarSize"
            android:background="?attr/colorPrimary" />

  3. In your `OnCreate` method (or `OnCreateView` for a fragment), bind the
     widget to the `ViewPager`.

         // Initialize the ViewPager and set an adapter
         var pager =  FindViewById<ViewPager>(Resource.Id.pager);
         pager.Adapter = new TestAdapter(SupportFragmentManager);

         // Bind the tabs to the ViewPager
         var tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.tabs);
         tabs.SetViewPager(pager);

  5. If your adapter implements the interface `CustomTabProvider` you can past you custom tab view/s.
     In case the the view returned contains the id `Resource.Id.tab_title`, this view should be a `TextView`  and
     will be used to placed the title.

     Otherwise the default tab will be use (That's a TextView with id `R.id.tab_title`)

  4. *(Optional)* If you use implement `IOnPageChangeListener` with your view pager
     you should set it in the widget rather than on the pager directly.

         // continued from above
         tabs.SetOnPageChangeListener(pageChangeListener);

# Customization

From theme:

* `android:textColorPrimary` value (from your theme) will be applied automatically  to tab's text color , underlineColor, dividerColor and indicatorColor, if any of these values are define in the xml layout.

Notes about some of the native attr:

* `android:textSize` Tab text size
* `android:textColor` Tab text color
* `android:paddingLeft` or `android:paddingRight` Layout padding. Only the biggest of both will be applied to each side.


Custom attr:

 * `pstsIndicatorColor` Color of the sliding indicator
 * `pstsUnderlineColor` Color of the full-width line on the bottom of the view
 * `pstsUnderlineHeight` Height of the full-width line on the bottom of the view
 * `pstsDividerColor` Color of the dividers between tabs
 * `pstsDividerPadding` Top and bottom padding of the dividers
 * `pstsDividerWidth` Stroke width of divider line, defaults to 0
 * `pstsIndicatorHeight`Height of the sliding indicator
 * `pstsTabPaddingLeftRight` Left and right padding of each tab
 * `pstsScrollOffset` Scroll offset of the selected tab
 * `pstsTabBackground` Background drawable of each tab, should be a StateListDrawable
 * `pstsShouldExpand` If set to true, each tab is given the same weight, default false
 * `pstsTextAllCaps` If true, all tab titles will be upper case, default true
 * `pstsPaddingMiddle` If true, the tabs start at the middle of the view (Like Newsstand google app)
 * `pstsTextStyle` Set the text style, default bold
 * `pstsTextSelectedStyle` Set the text style of the selected tab, default bold
 * `pstsTextAlpha` Set the text alpha transparency, default 0.5
 * `pstsTextSelectedAlpha` Set the text alpha transparency of the selected tab, default 1

*Almost all attributes have their respective getters and setters to change them at runtime* , open an issue if you miss any.
