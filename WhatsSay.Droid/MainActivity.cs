using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using WhatsSay.Core;
using WhatsSay.Core.ViewModels;

namespace WhatsSay.Droid
{
    [Activity(Label = "WhatsSay", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Binding<string, string> _passwordBinding;
        private Binding<string, string> _userNameBinding;

        public LoginViewModel ViewModel => SimpleIoc.Default.GetInstance<LoginViewModel>();

        public EditText UserNameEditText { get; set; }

        public EditText PasswordEditText { get; set; }

        public Button LoginButton { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            AppStart.Initialize();

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            FindIds();
            BindViewModel();
        }

        private void FindIds()
        {
            UserNameEditText = FindViewById<EditText>(Resource.Id.UserNameEditText);
            PasswordEditText = FindViewById<EditText>(Resource.Id.PasswordEditText);
            LoginButton = FindViewById<Button>(Resource.Id.LoginButton);
        }

        private void BindViewModel()
        {
            _userNameBinding = this.SetBinding(() => UserNameEditText.Text, ViewModel, () => ViewModel.UserName, BindingMode.TwoWay);
            _passwordBinding = this.SetBinding(() => PasswordEditText.Text, ViewModel, () => ViewModel.Password, BindingMode.TwoWay);
            LoginButton.SetCommand(ViewModel.LoginCommand);
        }
    }
}

