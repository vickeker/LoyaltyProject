using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PortableLibrary;

namespace AndroidApp
{
    [Activity(Label = "LoyaltyApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        AuthenticationManager authManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);



            EditText et_username = FindViewById<EditText>(Resource.Id.et_username);

            EditText et_password = FindViewById<EditText>(Resource.Id.et_password);

            TextView tv_errorauth = FindViewById<TextView>(Resource.Id.tv_errorauth);

            Button login = FindViewById<Button>(Resource.Id.login);
            login.Click += delegate {
                authManager = new AuthenticationManager();
                Boolean authuser = authManager.authenticateUser(et_username.Text,et_password.Text);
                if (authuser)
                {
                    var barsearch = new Intent(this, typeof(BarSearch));
                    barsearch.PutExtra("User", et_username.Text);
                    StartActivity(barsearch);
                } else
                {
                    tv_errorauth.Text="Username or password not valid";
                }
            };

        }
    }
}

