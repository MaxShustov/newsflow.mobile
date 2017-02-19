using GalaSoft.MvvmLight.Ioc;
using Plugin.Settings;
using WhatsSay.Core.ApiClients.Abstract;
using WhatsSay.Core.ApiClients.Implementation;
using WhatsSay.Core.ViewModels;

namespace WhatsSay.Core
{
    public class AppStart
    {
        public static void Initialize()
        {
            SimpleIoc.Default.Register(() => CrossSettings.Current);
            SimpleIoc.Default.Register<IApiContext, ApiContext>();
            SimpleIoc.Default.Register<LoginViewModel>();
        }
    }
}