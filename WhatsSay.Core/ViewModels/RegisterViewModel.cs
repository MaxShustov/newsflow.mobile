using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WhatsSay.Core.ApiClients.Abstract;
using WhatsSay.Core.Models;

namespace WhatsSay.Core.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private const string RegisterUrl = "api/auth/register";

        private readonly IApiContext _apiContext;
        private readonly RegisterModel _registerModel;

        public RegisterViewModel(IApiContext apiContext)
        {
            _apiContext = apiContext;
            _registerModel = new RegisterModel();
        }

        public ICommand RegisterCommand => new RelayCommand(Register);

        public string UserName
        {
            get
            {
                return _registerModel.UserName;
            }
            set
            {
                _registerModel.UserName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        public string Email
        {
            get
            {
                return _registerModel.Email;
            }
            set
            {
                _registerModel.Email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        public string Password
        {
            get
            {
                return _registerModel.Password;
            }
            set
            {
                _registerModel.Password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public string ConfirmedPassword
        {
            get
            {
                return _registerModel.ConfirmedPassword;
            }
            set
            {
                _registerModel.ConfirmedPassword = value;
                RaisePropertyChanged(() => ConfirmedPassword);
            }
        }

        private async void Register()
        {
            await _apiContext.Post(RegisterUrl, _registerModel);
        }
    }
}