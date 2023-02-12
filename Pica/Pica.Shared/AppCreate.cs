using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pica.Interfaces.Provider;
using Pica.Interfaces;
using PicaApi.Services.ApiProvider;
using System;
using PicaApi.Services.Client;
using Pica.Services.ApiProvider;
using Pica.Services;
using Pica.ViewModels;
using Pica.Views;
using Pica.Interfaces.Services;

namespace Pica;

public partial class App
{
    public static AppCreate AppCreate { get; set; } = new();
}

public partial class AppCreate
{
    public IHost Host
    {
        get;
    }

    public AppCreate()
    {
        Host = Microsoft.Extensions.Hosting.Host.
                CreateDefaultBuilder().
            UseContentRoot(AppContext.BaseDirectory).ConfigureServices
            ((context, services) =>
            {
                #region 注册控制器

                //API内容控制器为单服务
                services.AddSingleton<IApisProvider, ApisProvider>();

                services.AddTransient<IInitProvider, InitProvider>();
                services.AddTransient<ILoginProvider, LoginProvider>();
                services.AddTransient<IUserProvider, UserProvider>();
                services.AddTransient<IComicProvider, ComicProvider>();
                #endregion

                #region 注册请求方法
                services.AddSingleton<IGetRequestMessage,GetRequestMessage>();
                #endregion

                #region 注册Client
                services.AddSingleton<IPica3Client, Pica3Client>();
                #endregion

                #region 注册View
                services.AddSingleton<MainPage>();
                services.AddSingleton<MainViewModel>();

                services.AddSingleton<LoginPage>();
                services.AddSingleton<LoginViewModel>();

                services.AddSingleton<ShellPage>();
                services.AddSingleton<ShellViewModel>();
                #endregion

                #region 导航空间
                services.AddSingleton<IAppNavigationService, AppNavigationService>();
                services.AddTransient<IAppNavigationViewService, AppNavigationViewService>();
                services.AddSingleton<IPageType, PageType>();
                #endregion
            }).Build();
    }

    public static T GetService<T>()
        where T : class
    {
        if (App.AppCreate.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} 你他妈没注册吧，找不到，去找上一个方法去。");
        }

        return service;
    }
}
