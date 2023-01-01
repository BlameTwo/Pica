using Pica3.UI.Extend;
using Pica3.ViewModels;
using Pica3.Views.Dialogs;
using System.Windows;

namespace Pica3.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewmodel, IPicaShowDialog picaShowDialog, LoginDialogView loginDialogView)
        {
            InitializeComponent();
            Viewmodel = viewmodel;
            PicaShowDialog = picaShowDialog;
            LoginDialogView = loginDialogView;
            this.DataContext = viewmodel;
        }

        public MainWindowViewModel Viewmodel { get; }
        public IPicaShowDialog PicaShowDialog { get; }
        public LoginDialogView LoginDialogView { get; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PicaShowDialog.Show(LoginDialogView);
        }
    }
}
