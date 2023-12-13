using CommunityToolkit.Maui.Alerts;
using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica.Models.Event;
using Pica.Services.Interfaces;

namespace Pica.ViewModels;


public partial class LoginViewModel:ObservableObject
{
	public LoginViewModel(IPicaClient pica3Client,ILoginProvider loginProvider,ILocalSetting localSetting)
	{
        PicaClient = pica3Client;
        LoginProvider = loginProvider;
        LocalSetting = localSetting;
        PicaClient.InitClient();
    }

    [RelayCommand]
    async void Loaded()
    {
        this.Iplist = (await PicaClient.GetIpList()).Ips;

        User = (string)await LocalSetting.ReadConfig("User");
        Passwd = (string)await LocalSetting.ReadConfig("Passwd");
    }

    [RelayCommand]
    async void EnterLogin()
    {
        var result = await LoginProvider.LoginAsync(this.User, this.Passwd);
        if(result == true)
        {
            WeakReferenceMessenger.Default.Send<LoginEventModel>(new LoginEventModel()
            {
                Message = "登录成功"
                , IsLogin= true
            });
            //这里登录后退回上一级
            await Toast.Make("登录成功", CommunityToolkit.Maui.Core.ToastDuration.Short, 16).Show();
            await LocalSetting.SaveConfig<string>("User",User);
            await LocalSetting.SaveConfig<string>("Passwd",Passwd);
            await Shell.Current.GoToAsync("..", true);
        }
    }



    [RelayCommand]
    void SelectIp()
    {
        PicaClient.SetIp(null, this.IpSelect);
    }


    [ObservableProperty]
    string _passwd;

    [ObservableProperty]
    string _user;             

    [ObservableProperty]
    List<string> _iplist;

    [ObservableProperty]
    string _ipSelect;


    public IPicaClient PicaClient { get; }
    public ILoginProvider LoginProvider { get; }
    public ILocalSetting LocalSetting { get; }
}
