using GalaSoft.MvvmLight.Ioc;
using WhatsSay.Core.ViewModels;

namespace WhatsSay.Uwp
{
    public class ViewModelLocator
    {
        public LoginViewModel LoginViewModel => SimpleIoc.Default.GetInstance<LoginViewModel>();

        public RegisterViewModel RegisterViewModel => SimpleIoc.Default.GetInstance<RegisterViewModel>();
    }
}