using Microsoft.Extensions.Hosting;
using Pica3.Views;
using Pica3Progress;
using System;
using System.Windows;

namespace Pica3
{
    /// <summary>
    /// Interaction logic for App.xaml
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

        public static T GetService<T>()
            where T : class
        {
            if((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
            {
                throw new Exception($"{typeof(T)}：你的有一些服务没有注册，请检查一下。");
            }
            return service;
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            Pica3.Views.MainWindow main = App.GetService<MainWindow>();
            this.MainWindow = main;
            main.Show();
            base.OnStartup(e);
        }
    }
}
