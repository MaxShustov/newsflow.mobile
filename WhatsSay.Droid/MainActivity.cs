using System;
using Android.App;
using Android.OS;
using Android.Widget;
using WhatsSay.Core.ApiClients.Implementation;

namespace WhatsSay.Droid
{
    [Activity(Label = "WhatsSay.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private EditText _userNameEditText;
        private EditText _passwordEditText;
        private Button _loginButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            FindIds();

            _loginButton.Click += LoginButtonOnClick;
        }

        private async void LoginButtonOnClick(object sender, EventArgs eventArgs)
        {
            var apiContext = new ApiContext();

            var token = await apiContext.Login(_userNameEditText.Text, _passwordEditText.Text);
        }

        private void FindIds()
        {
            _userNameEditText = FindViewById<EditText>(Resource.Id.UserNameEditText);
            _passwordEditText = FindViewById<EditText>(Resource.Id.PasswordEditText);
            _loginButton = FindViewById<Button>(Resource.Id.LoginButton);
        }
    }
}

