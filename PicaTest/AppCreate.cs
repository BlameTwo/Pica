using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pica.Interfaces.Provider;
using Pica.Interfaces;
using PicaApi.Services.ApiProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicaApi.Services.Client;
using Pica.Services.ApiProvider;
using Pica.Services;

namespace PicaTest
{


    internal static class AppCreate
    {
        static IHost Host
        {
            get;
        }

        static AppCreate()
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
                }).Build();
        }

        public static T GetService<T>()
        where T : class
        {
            if (Host.Services.GetService(typeof(T)) is not T service)
            {
                throw new ArgumentException($"{typeof(T)} 你他妈没注册吧，找不到，去找上一个方法去。");
            }

            return service;
        }
    }
}
