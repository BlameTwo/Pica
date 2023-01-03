using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica.Services;
using Pica.Services.ApiProvider;
using Pica3.Extend;
using Pica3.UI.Extend;
using Pica3.UI.Services;
using Pica3.ViewModels;
using Pica3.Views;
using Pica3.Views.Dialogs;
using PicaApi.Services.ApiProvider;
using PicaApi.Services.Client;

namespace Pica3Progress;
public static class Pica3LifeManager
{
    /// <summary>
    /// 注册API
    /// </summary>
    /// <param name="hostBuilder"></param>
    /// <returns></returns>
    public static IHostBuilder RegisterApi(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices((context, services) =>
        {
            #region 注册控制器

            //API内容控制器为单服务
            services.AddSingleton<IApisProvider, ApisProvider>();
            services.AddTransient<IInitProvider, InitProvider>();
            services.AddTransient<ILoginProvider, LoginProvider>();
            services.AddTransient<IUserProvider, UserProvider>();
            #endregion

            #region 注册请求方法
            services.AddSingleton<IGetRequestMessage, GetRequestMessage>();
            #endregion

            #region 注册Client
            services.AddSingleton<IPica3Client, Pica3Client>();
            #endregion
        });
        return hostBuilder;
    }

    /// <summary>
    /// 注册视图
    /// </summary>
    /// <param name="hostBuilder"></param>
    /// <returns></returns>
    public static IHostBuilder RegisterViews(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices((context, services) =>
        {
            services.AddTransient<LoginDialogView>();
            services.AddSingleton<MainWindow>();
        });
        return hostBuilder;
    }

    /// <summary>
    /// 注册ViewModels
    /// </summary>
    /// <param name="hostBuilder"></param>
    /// <returns></returns>
    public static IHostBuilder RegisterViewsModels(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices((context, services) =>
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<LoginDialogViewModel>();

        });
        return hostBuilder;
    }

    /// <summary>
    /// 注册扩展
    /// </summary>
    /// <param name="hostBuilder"></param>
    /// <returns></returns>
    public static IHostBuilder RegisterExtention(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices((context, services) =>
        {
            //对话框服务
            services.AddSingleton<IPicaShowDialog,PicaShowDialog>();
            //弹窗消息服务
            services.AddSingleton<IPicaShowLitterMessage, PicaShowLitterMessage>();
            //Window窗体位置及其大小控制
            services.AddSingleton<IWindowManager, WindowManager>();

            services.AddSingleton<Pica3.Views.Interface.IMainService, MainService>();
        });
        return hostBuilder;
    }
}
