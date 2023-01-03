using Pica3.UI.Controls;
using Pica3.UI.Extend;
using Pica3.ViewModels;
using Pica3.Views.Dialogs;
using Pica3.Views.Interface;
using System;
using System.Windows;

namespace Pica3.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(
            IPicaShowDialog picaShowDialog, 
            IPicaShowLitterMessage picaShowLitterMessage,
            IMainService mainService)
        {
            InitializeComponent();
            PicaShowDialog = picaShowDialog;
            PicaShowLitterMessage = picaShowLitterMessage;
            MainService = mainService;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PicaShowLitterMessage.ShowTime = TimeSpan.FromSeconds(2);
            PicaShowLitterMessage.ShowOwner = grid;
        }

        public MainWindowViewModel Viewmodel { get; }
        public IPicaShowDialog PicaShowDialog { get; }
        public IPicaShowLitterMessage PicaShowLitterMessage { get; }
        public IMainService MainService { get; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //这里初始化使用的是Views中的服务管理
            var LoginDialogView = MainService.GetService<LoginDialogView>();
            var vm = MainService.GetService<LoginDialogViewModel>();
            PicaShowDialog.Show(LoginDialogView,vm);
        }
    }
}
