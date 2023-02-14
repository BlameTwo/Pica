using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica.Models.Event;

namespace Pica.ViewModels;


public partial class LoginViewModel:ObservableObject
{
	public LoginViewModel(IPica3Client pica3Client,ILoginProvider loginProvider)
	{
        Pica3Client = pica3Client;
        LoginProvider = loginProvider;
        Pica3Client.InitClient();
    }

    [RelayCommand]
    async void Loaded()
    {
        this.Iplist = (await Pica3Client.GetIpList()).Ips;
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
            await Shell.Current.GoToAsync("..", true);
        }
    }



    [RelayCommand]
    async void SelectIp()
    {
        Pica3Client.SetIp(null, this.IpSelect);
    }


    [ObservableProperty]
    string _passwd;

    [ObservableProperty]
    string _user;             

    [ObservableProperty]
    List<string> _iplist;

    [ObservableProperty]
    string _ipSelect;


    public IPica3Client Pica3Client { get; }
    public ILoginProvider LoginProvider { get; }
}
