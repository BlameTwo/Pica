using Microsoft.UI.Xaml.Controls;
using Pica.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Pica.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginViewModel ViewModel { get; }
        public LoginPage()
        {
            this.ViewModel =AppCreate.GetService<LoginViewModel>();
            this.InitializeComponent();
        }
    }
}
