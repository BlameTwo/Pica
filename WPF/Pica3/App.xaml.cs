using Microsoft.Extensions.Hosting;
using Pica.Interfaces;
using Pica3.UI.Services;
using Pica3.Views;
using Pica3Progress;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Pica3
{
    /// <summary>
    /// 使用原生的的App进行启动
    /// </summary>
    public partial class App : Application
    {
        IHost Host { get; }

        public App()
        {
            InitializeComponent();

            #region 初始化Ioc容器
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                   .RegisterApi()
                   .RegisterViews()
                   .RegisterViewsModels()
                   .RegisterExtention()
                   .Build();
            #endregion
        }

        /// <summary>
        /// 获得一个对象
        /// </summary>
        /// <typeparam name="T">你想要的对象，而且是注册过的,接口或类</typeparam>
        /// <returns></returns>
        /// <exception cref="Exception">错误信息</exception>
        public static T GetService<T>()
            where T : class
        {
            if((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
            {
                throw new Exception($"{typeof(T)}：你的有一些服务没有注册，请检查一下。");
            }
            return service;
        }


        /// <summary>
        /// 进行启动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //初始化操作
            Pica3.Views.MainWindow main = App.GetService<MainWindow>();
            var Pica3Client = App.GetService<IPica3Client>();
            var windowmanager = App.GetService<IWindowManager>();
            Pica3Client.InitClient();
            this.MainWindow = main;
            windowmanager.MainWindow = main;
            main.Icon = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory()+@"\Logo\logo_round.ico"));
            main.Show();
            base.OnStartup(e);
        }
    }
}
