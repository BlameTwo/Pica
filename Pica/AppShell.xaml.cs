using CommunityToolkit.Maui.Views;
using Pica.Interfaces;
using Pica.Views;
using Pica.Views.Details;

namespace Pica;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("login", typeof(LoginPage));
        Routing.RegisterRoute("shell/search", typeof(SearchPage));
        Routing.RegisterRoute("shell/user", typeof(UserPage));
        Routing.RegisterRoute("shell/rank", typeof(HotRank));
        Routing.RegisterRoute("shell/random", typeof(RandomPage));
        Routing.RegisterRoute(nameof(ComicDetailPage), typeof(ComicDetailPage));
        Routing.RegisterRoute(nameof(ComicDocumentDetailPage), typeof(ComicDocumentDetailPage));
        this.Navigated += AppShell_Navigated;
    }

    private async void AppShell_Navigated(object sender, ShellNavigatedEventArgs e)
    {
        //判断登录数据
        if (this.CurrentPage.GetType() == typeof(LoginPage))
            return;
        var client = this.Handler.MauiContext.Services.GetService<IPica3Client>();
        if (!client.IsLogin())
            await this.ShowPopupAsync(App.GetService<LoginTipMessagePopup>());
    }

}