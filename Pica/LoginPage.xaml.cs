using Pica.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;
namespace Pica;

public partial class LoginPage : CommunityToolkit.Maui.Views.Popup
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		loginViewModel.Popup = this;
		BindingContext = loginViewModel;
		InitializeComponent();
	}
}