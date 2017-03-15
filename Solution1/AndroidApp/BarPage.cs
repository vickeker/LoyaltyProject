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

namespace AndroidApp
{
    [Activity(Label = "BarPage")]
    public class BarPage : Activity
    {
        String username;
        String bar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.barpage);

            username = Intent.GetStringExtra("User") ?? "Data not available";
            bar = Intent.GetStringExtra("Bar") ?? "Data not available";

            TextView tv_bar = FindViewById<TextView>(Resource.Id.tv_bar);
            tv_bar.Text = bar;


        }
    }
}