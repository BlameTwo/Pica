using Pica.Interfaces.Provider;
using Pica.Interfaces;
using Pica.Services.ApiProvider;
using Pica.Services;
using PicaApi.Services.ApiProvider;
using PicaApi.Services.Client;
using CommunityToolkit.Maui;
using Pica.ViewModels;
using CommunityToolkit.Maui.Markup;
using Pica.Views;
using Pica.Views.Details;
using Pica.ViewModels.DetailsViewModels;
using Pica.Services.Interfaces;

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
                .RegisterViewModel()
                .RegisterExtend();
            
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
            builder.Services.AddTransient<ISearchProvider, SearchProvider>();
            #endregion

            #region 注册请求方法
            builder.Services.AddSingleton<IGetRequestMessage, GetRequestMessage>();
            builder.Services.AddTransient<IImageDownloadProvider, ImageDownloadProvider>();
            #endregion

            #region 注册Client
            builder.Services.AddSingleton<IPica3Client, Pica3Client>();
            #endregion
            return builder;
        }

        public static MauiAppBuilder RegisterExtend(this MauiAppBuilder mauiAppBuilder)
        {
            //配置文件读取
            mauiAppBuilder.Services.AddSingleton<ILocalSetting,LocalSetting>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterView(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<AppShell>();
            mauiAppBuilder.Services.AddSingleton<SearchPage>();
            mauiAppBuilder.Services.AddTransient<LoginPage>();
            mauiAppBuilder.Services.AddTransient<UserPage>();
            mauiAppBuilder.Services.AddTransient<HotRank>();
            mauiAppBuilder.Services.AddTransient<SearchPage>();
            mauiAppBuilder.Services.AddTransient<RandomPage>();
            mauiAppBuilder.Services.AddTransient<LoginTipMessagePopup>();
            mauiAppBuilder.Services.AddTransient<ComicDetailPage>();
            mauiAppBuilder.Services.AddTransient<ComicDocumentDetailPage>();
            mauiAppBuilder.Services.AddTransient<SettingPage>();
            mauiAppBuilder.Services.AddTransient<SearchDetailPage>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModel(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<LoginViewModel>();
            mauiAppBuilder.Services.AddSingleton<SearchViewModel>();
            mauiAppBuilder.Services.AddTransient<UserViewModel>();
            mauiAppBuilder.Services.AddTransient<RandomViewModel>();
            mauiAppBuilder.Services.AddTransient<HotRankViewModel>();
            mauiAppBuilder.Services.AddTransient<HotRankViewModel>();
            mauiAppBuilder.Services.AddTransient<ComicDetailViewModel>();
            mauiAppBuilder.Services.AddTransient<SearchViewModel>();
            mauiAppBuilder.Services.AddTransient<ComicDocumentDetailViewModel>();
            mauiAppBuilder.Services.AddTransient<SettingViewModel>();
            mauiAppBuilder.Services.AddTransient<SearchDetailViewModel>();
            return mauiAppBuilder;
        }
    }
}