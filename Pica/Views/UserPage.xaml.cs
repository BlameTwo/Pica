using CommunityToolkit.Maui.Views;
using Pica.ViewModels;

namespace Pica.Views;

public partial class UserPage : ContentPage
{
	public UserPage(UserViewModel userViewModel)
    {
        this.BindingContext= userViewModel;
        InitializeComponent();
    }

    public LoginPage LoginPage { get; }

    private void Button_Clicked(object sender, EventArgs e)
    {
        this.ShowPopup(this.Handler.MauiContext.Services.GetService<LoginPage>());
    }
}