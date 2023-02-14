using CommunityToolkit.Maui.Views;

namespace Pica.Views;

public partial class LoginTipMessagePopup : Popup
{
	public LoginTipMessagePopup()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("shell/login", true);
		this.Close();
    }
}