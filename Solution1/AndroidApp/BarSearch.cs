using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PortableLibrary;

namespace AndroidApp
{
    [Activity(Label = "BarSearch")]
    public class BarSearch : Activity
    {

        string username;
        BarManager barmanager;
        public String[] bars;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.barsearch);

            username = Intent.GetStringExtra("User") ?? "Data not available";
            barmanager = new BarManager();

            TextView tv_errorbar = FindViewById<TextView>(Resource.Id.tv_errorbar);
            TextView tvusername= FindViewById<TextView>(Resource.Id.tvusername);
            tvusername.Text = username;
            bars = barmanager.getBarList();
     //       String[] bars = new String[] {
     //    "Belgium", "France", "Italy", "Germany", "Spain"
     //};


            ArrayAdapter autoCompleteAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, bars);


            var autocompleteTextView = FindViewById<AutoCompleteTextView>(Resource.Id.autocomp_barname);
            autocompleteTextView.Adapter = autoCompleteAdapter;

            Button search = FindViewById<Button>(Resource.Id.search);
            search.Click += delegate
            {

                if (bars.Contains(autocompleteTextView.Text))
                {
                    var barpage = new Intent(this, typeof(BarPage));
                   barpage.PutExtra("User", username);
                    barpage.PutExtra("Bar", autocompleteTextView.Text);
                    StartActivity(barpage);
                }
                else
                {
                    tv_errorbar.Text = "This bar doesnt exist";
                }

            };

            ListView barresult = FindViewById<ListView>(Resource.Id.barresult);
           // ArrayAdapter ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, bars);
            barresult.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1,bars);
            barresult.ItemClick += OnListItemClick;
        }
        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = bars[e.Position];
            Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();
        }
    }
}