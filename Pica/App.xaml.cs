using Pica.Views;

namespace Pica
{
    public partial class App : Application
    {
        public App(AppShell shell)
        {
            InitializeComponent();
            MainPage = shell;
        }


        public static T GetService<T>()
        {
            if((App.Current as App).Handler.MauiContext.Services.GetService(typeof(T)) is not T service)
            {
                throw new ArgumentException($"{typeof(T)} 不存在于容器中");
            }
            return service;
        }
    }
}