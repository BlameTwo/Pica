using Pica3.UI.Controls;
using Pica3.UI.Extend;
using Pica3.ViewModels;
using Pica3.Views.Dialogs;
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
            MainWindowViewModel viewmodel, 
            IPicaShowDialog picaShowDialog, 
            LoginDialogView loginDialogView,
            IPicaShowLitterMessage picaShowLitterMessage)
        {
            InitializeComponent();
            Viewmodel = viewmodel;
            PicaShowDialog = picaShowDialog;
            LoginDialogView = loginDialogView;
            PicaShowLitterMessage = picaShowLitterMessage;
            this.DataContext = viewmodel;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PicaShowLitterMessage.ShowTime = TimeSpan.FromSeconds(2);
            PicaShowLitterMessage.ShowOwner = grid;
        }

        public MainWindowViewModel Viewmodel { get; }
        public IPicaShowDialog PicaShowDialog { get; }
        public LoginDialogView LoginDialogView { get; }
        public IPicaShowLitterMessage PicaShowLitterMessage { get; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PicaShowLitterMessage.Show("测试弹窗");
        }
    }
}
