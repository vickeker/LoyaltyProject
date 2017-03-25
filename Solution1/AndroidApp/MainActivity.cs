using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PortableLibrary;
using Facebook;
using System.Collections.Generic;
using Android.Graphics;

namespace AndroidApp
{
    [Activity(Label = "LoyaltyApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        AuthenticationManager authManager;
        private string AppId = "1836506863280843";// (Resource.String.facebook_app_id).ToString();
        private const string ExtendedPermissions = "user_about_me,user_friends,user_photos,user_likes,user_posts,user_events,user_location,user_tagged_places,publish_actions,rsvp_event,email";

        FacebookClient fb;
        string accessToken;
        bool isLoggedIn;
        string lastMessageId;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var btnLogin = FindViewById<Button>(Resource.Id.login);

            btnLogin.Click += (sender, e) => {
                var webAuth = new Intent(this, typeof(FBWebViewAuthActivity));
                webAuth.PutExtra("AppId", AppId);
                webAuth.PutExtra("ExtendedPermissions", ExtendedPermissions);
                StartActivityForResult(webAuth, 0);
            };



            void HandleGraphApiSample(object sender, EventArgs e)
            {
                if (isLoggedIn)
                {

                    fb.GetTaskAsync("me").ContinueWith(t => {
                        if (!t.IsFaulted)
                        {

                            var result = (IDictionary<string, object>)t.Result;

                            string data = "Name: " + (string)result["name"] + "\n" +
                                "First Name: " + (string)result["first_name"] + "\n" +
                                    "Last Name: " + (string)result["last_name"] + "\n" +
                                    "Profile Url: " + (string)result["link"];
                            RunOnUiThread(() => {
                                Alert("Your Info", data, false, (res) => { });
                            });
                        }
                    });
                }
                else
                {
                    Alert("Not Logged In", "Please Log In First", false, (res) => { });
                }
            }

            EditText et_username = FindViewById<EditText>(Resource.Id.et_username);

            EditText et_password = FindViewById<EditText>(Resource.Id.et_password);

            TextView tv_errorauth = FindViewById<TextView>(Resource.Id.tv_errorauth);


        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            switch (resultCode)
            {
                case Result.Ok:

                    accessToken = data.GetStringExtra("AccessToken");
                    string userId = data.GetStringExtra("UserId");
                    string error = data.GetStringExtra("Exception");

                    fb = new FacebookClient(accessToken);

                    ImageView imgUser = FindViewById<ImageView>(Resource.Id.imgUser);
                    TextView txtvUserName = FindViewById<TextView>(Resource.Id.TVUserName);

                    fb.GetTaskAsync("me").ContinueWith(t => {
                        if (!t.IsFaulted)
                        {

                            var result = (IDictionary<string, object>)t.Result;

                            // available picture types: square (50x50), small (50xvariable height), large (about 200x variable height) (all size in pixels)
                            // for more info visit http://developers.facebook.com/docs/reference/api
                            string profilePictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", userId, "square", accessToken);
                            var bm = BitmapFactory.DecodeStream(new Java.Net.URL(profilePictureUrl).OpenStream());
                            string profileName = (string)result["name"];

                            RunOnUiThread(() => {
                                imgUser.SetImageBitmap(bm);
                                txtvUserName.Text = profileName;
                            });

                            isLoggedIn = true;
                        }
                        else
                        {
                            Alert("Failed to Log In", "Reason: " + error, false, (res) => { });
                        }
                    });

                    break;
                case Result.Canceled:
                    Alert("Failed to Log In", "User Cancelled", false, (res) => { });
                    break;
                default:
                    break;
            }
        }

        public void Alert(string title, string message, bool CancelButton, Action<Result> callback)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle(title);
            builder.SetIcon(Resource.Drawable.Icon);
            builder.SetMessage(message);

            builder.SetPositiveButton("Ok", (sender, e) => {
                callback(Result.Ok);
            });

            if (CancelButton)
            {
                builder.SetNegativeButton("Cancel", (sender, e) => {
                    callback(Result.Canceled);
                });
            }

            builder.Show();
        }


    }
}

