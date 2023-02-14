using Pica.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;
namespace Pica;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		BindingContext = loginViewModel;
		InitializeComponent();
	}
}