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
        /// <summary>
        /// MainWindow构造函数
        /// </summary>
        /// <param name="picaShowDialog">对话框服务</param>
        /// <param name="loginDialogView">登录对话框的一个服务</param>
        /// <param name="mainWindowViewModel">Main窗口的VM</param>
        public MainWindow(
            IPicaShowDialog picaShowDialog,
            LoginDialogView loginDialogView,
            MainWindowViewModel mainWindowViewModel)
        {
            this.DataContext = mainWindowViewModel;
            Viewmodel= mainWindowViewModel;
            InitializeComponent();
            PicaShowDialog = picaShowDialog;
            LoginDialogView = loginDialogView;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Viewmodel.PicaShowLitterMessage.ShowTime = TimeSpan.FromSeconds(2);
            Viewmodel.PicaShowLitterMessage.ShowOwner = grid;
        }

        public MainWindowViewModel Viewmodel { get; }
        public IPicaShowDialog PicaShowDialog { get; }
        public LoginDialogView LoginDialogView { get; }
        public IMainService MainService { get; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ////这里初始化使用的是Views中的服务管理(弃用
            //var LoginDialogView = MainService.GetService<LoginDialogView>();
            PicaShowDialog.Show(LoginDialogView);
        }
    }
}
