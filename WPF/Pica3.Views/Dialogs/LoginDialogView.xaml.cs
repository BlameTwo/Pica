using Pica3.UI.Controls;
using System.Windows.Controls;

namespace Pica3.Views.Dialogs
{
    /// <summary>
    /// LoginDialogView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginDialogView : DialogHost
    {
        public LoginDialogView()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
