using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WhatsSay.Core.ApiClients.Abstract;

namespace WhatsSay.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IApiContext _apiContext;

        private string _userName = string.Empty;
        private string _password = string.Empty;

        public LoginViewModel(IApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public ICommand LoginCommand => new RelayCommand(LoginAsync);

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                Set(() => UserName, ref _userName, value);
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                Set(() => Password, ref _password, value);
            }
        }

        private async void LoginAsync()
        {
            var result = await _apiContext.Login(_userName, _password);

            //TODO save token
        }
    }
}