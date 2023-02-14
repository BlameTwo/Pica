using Pica.Interfaces.Provider;
using Pica.Interfaces;
using Pica.Services.ApiProvider;
using Pica.Services;
using PicaApi.Services.ApiProvider;
using PicaApi.Services.Client;
using CommunityToolkit.Maui;
using System.Runtime.CompilerServices;
using Pica.ViewModels;
using CommunityToolkit.Maui.Markup;
using Pica.Views;

namespace Pica
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMarkup()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
           

            builder
                .RegisterApi()
                .RegisterView()
                .RegisterViewModel();

            return builder.Build();
        }

        public static MauiAppBuilder RegisterApi(this MauiAppBuilder builder)
        {
            #region 注册控制器

            //API内容控制器为单服务
            builder.Services.AddSingleton<IApisProvider, ApisProvider>();
            builder.Services.AddTransient<IInitProvider, InitProvider>();
            builder.Services.AddTransient<ILoginProvider, LoginProvider>();
            builder.Services.AddTransient<IUserProvider, UserProvider>();
            builder.Services.AddTransient<IComicProvider, ComicProvider>();
            #endregion

            #region 注册请求方法
            builder.Services.AddSingleton<IGetRequestMessage, GetRequestMessage>();
            builder.Services.AddSingleton<IImageDownloadProvider, ImageDownloadProvider>();
            #endregion

            #region 注册Client
            builder.Services.AddSingleton<IPica3Client, Pica3Client>();
            #endregion
            return builder;
        }

        public static MauiAppBuilder RegisterView(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<AppShell>();
            mauiAppBuilder.Services.AddSingleton<SearchPage>();
            mauiAppBuilder.Services.AddTransient<LoginPage>();
            mauiAppBuilder.Services.AddTransient<UserPage>();
            mauiAppBuilder.Services.AddTransient<HotRank>();
            mauiAppBuilder.Services.AddTransient<LoginTipMessagePopup>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModel(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<LoginViewModel>();
            mauiAppBuilder.Services.AddSingleton<SearchViewModel>();
            mauiAppBuilder.Services.AddTransient<UserViewModel>();
            mauiAppBuilder.Services.AddTransient<HotRankViewModel>();
            return mauiAppBuilder;
        }
    }
}