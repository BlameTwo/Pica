using Pica3.UI.Controls;
using Pica3.ViewModels;
using System.Windows.Controls;

namespace Pica3.Views.Dialogs
{
    /// <summary>
    /// LoginDialogView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginDialogView : DialogHost
    {
        public LoginDialogViewModel LoginDialogViewModel { get; }

        /// <summary>
        /// 登录对话框的VM
        /// </summary>
        /// <param name="loginDialogViewModel"></param>
        public LoginDialogView(LoginDialogViewModel loginDialogViewModel)
        {
            this.DataContext= loginDialogViewModel;
            InitializeComponent();
            LoginDialogViewModel = loginDialogViewModel;
            this.Loaded += LoginDialogView_Loaded;
        }

        private void LoginDialogView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //这里需要对VM中的关闭操作进行赋值
            LoginDialogViewModel.MyHost = this;
        }

        /// <summary>
        /// 直接关闭的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
