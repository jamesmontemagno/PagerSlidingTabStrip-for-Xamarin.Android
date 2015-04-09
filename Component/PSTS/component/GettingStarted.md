# Getting Started with Pager Sliding Tab Strip

**This library requires AppCompat v21+**

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

  4. If your adapter implements the interface `CustomTabProvider` you can past you custom tab view/s.
     In case the the view returned contains the id `Resource.Id.psts_tab_title`, this view should be a `TextView`  and will be used to placed the title. If you don't want the library to manage your TextView title for the tab, use a different id than `Resource.Id.psts_tab_title` in your tab layout.

     If your adapter doesn't impelement the interface `CustomTabProvider` the default tab will be used (That's a TextView with id `Resource.Id.psts_tab_title`).

  5. *(Optional)* If you use implement `IOnPageChangeListener` with your view pager
     you should set it in the widget rather than on the pager directly.

         // continued from above
         tabs.SetOnPageChangeListener(pageChangeListener);

# Customization

From theme:

* `android:textColorPrimary` value (from your theme) will be applied automatically to tab's text color (Selected tab with 255 alpha and non selected tabs with 150 alpha), underlineColor, dividerColor, and indicatorColor, if the values are not defined on the xml layout.

Notes about some of the native attr:

* `android:textSize` Tab text size
* `android:textColor` Non selected tabs text color. If you DO define `textColor` It will be apply to **NON selected** tabs and **NO ALPHA** will be applied to them, **the colour you define is the one you will see**. If you want to define a half transparent color in `textColor`, you can pass #80FFFFFF (That's an example for half transparent white)
* `android:paddingLeft` or `android:paddingRight` layout padding. If you apply both, they should be balanded. 

Custom attr:

* `pstsIndicatorColor` Color of the sliding indicator. `textPrimaryColor` will be it's default color value.
* `pstsUnderlineColor` Color of the full-width line on the bottom of the view. `textPrimaryColor` will be it's default color value.
* `pstsUnderlineHeight` Height of the full-width line on the bottom of the view.
* `pstsTextAlpha` Set the text alpha transparency for non selected tabs. Range 0..255. 150 is it's default value. It **WON'T** be use if `textColor` is defined in the layout. If `textColor` is **NOT** defined, It will be apply to the non selected tabs.
* `pstsTextColorSelected` Set selected tab text color. `textPrimaryColor` will be it's default color value.
* `pstsTextStyle` Set the text style, default bold.
* `pstsTextSelectedStyle` Set the text style of the selected tab, default bold.
* `pstsTextAllCaps` If true, all tab titles will be upper case, default true.
* `pstsDividerColor` Color of the dividers between tabs. `textPrimaryColor` will be it's default color value.
* `pstsDividerPadding` Top and bottom padding of the dividers.
* `pstsDividerWidth` Stroke width of divider line, defaults to 0.
* `pstsIndicatorHeight`Height of the sliding indicator.
* `pstsTabPaddingLeftRight` Left and right padding of each tab.
* `pstsScrollOffset` Scroll offset of the selected tab.
* `pstsTabBackground` Background drawable of each tab, should be a StateListDrawable.
* `pstsShouldExpand` If set to true, each tab is given the same weight, default false.
* `pstsPaddingMiddle` If true, the tabs start at the middle of the view (Like Newsstand google app).

*Almost all attributes have their respective getters and setters to change them at runtime* , open an issue if you miss any.