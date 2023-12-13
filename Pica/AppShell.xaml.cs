using CommunityToolkit.Maui.Views;
using Pica.Interfaces;
using Pica.Services.Interfaces;
using Pica.Views;
using Pica.Views.Details;

namespace Pica;

public partial class AppShell : Shell
{
    public ILocalSetting LocalSetting { get; }

    public AppShell(ILocalSetting localSetting)
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));
        Routing.RegisterRoute(nameof(UserPage), typeof(UserPage));
        Routing.RegisterRoute(nameof(HotRank), typeof(HotRank));
        Routing.RegisterRoute(nameof(RandomPage), typeof(RandomPage));
        Routing.RegisterRoute(nameof(ComicDetailPage), typeof(ComicDetailPage));
        Routing.RegisterRoute(nameof(ComicDocumentDetailPage), typeof(ComicDocumentDetailPage));
        Routing.RegisterRoute(nameof(SettingPage), typeof(SettingPage));
        Routing.RegisterRoute(nameof(SearchDetailPage), typeof(SearchDetailPage));
        this.Navigated += AppShell_Navigated;
        LocalSetting = localSetting;
        InitLoad();
    }

    private void InitLoad()
    {
        //初始化设置文件
        LocalSetting.InitSetting();
    }

    private async void AppShell_Navigated(object sender, ShellNavigatedEventArgs e)
    {
        //判断登录数据
        if (this.CurrentPage.GetType() == typeof(LoginPage))
            return;
        var client = this.Handler.MauiContext.Services.GetService<IPicaClient>();
        if (!client.IsLogin())
            await this.ShowPopupAsync(App.GetService<LoginTipMessagePopup>());
    }

}