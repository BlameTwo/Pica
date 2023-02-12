using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
        IpList = await Pica3Client.GetIpList();
        
    }


    [RelayCommand]
    async void IpSelected(string ip)
    {
        Pica3Client.SetIp(null,_SelectIp);
    }

    [RelayCommand]
    async void Login()
    {
       var result = await LoginProvider.LoginAsync(this.User, this.Passwd);
    }

    private string _selectip;

    public string _SelectIp
    {
        get { return _selectip; }
        set=>SetProperty(ref _selectip, value);
    }


    private InitData _iplist;

    public InitData IpList
    {
        get { return _iplist; }
        set =>SetProperty(ref _iplist, value);
    }

    private string _user;

    public string User
    {
        get { return _user; }
        set => SetProperty(ref _user, value);
    }

    private string _passwd;

    public string Passwd
    {
        get { return _passwd; }
        set=>SetProperty(ref _passwd, value);
    }


    public IPica3Client Pica3Client { get; }
    public ILoginProvider LoginProvider { get; }
}
