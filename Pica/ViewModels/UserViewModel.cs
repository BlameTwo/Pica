using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica.Models.Event;

namespace Pica.ViewModels;

public partial class UserViewModel:ObservableRecipient, IRecipient<LoginEventModel>
{
    public IPica3Client Pica3Client { get; }
    public IUserProvider UserProvider { get; }

    public UserViewModel(IPica3Client pica3Client, IUserProvider userProvider)
	{
        Pica3Client = pica3Client;
        UserProvider = userProvider;
        IsActive = true;
    }

    [RelayCommand]
    void Loaded()
    {
        this.Loginbuttonvis = Pica3Client.IsLogin() == true ? false : true;
        if(Pica3Client.IsLogin())Refershuser();
    }



    public void Receive(LoginEventModel message)
    {
        switch (message.IsLogin)
        {
            case true:
                Loginbuttonvis = false;
                IsActive = true;
                Refershuser();
                break;
            case false:
                Loginbuttonvis = true;
                break;
        }
    }

    async void Refershuser()
    {
        var result = await UserProvider.GetUserProfile();
        if (result.Code == 401) return;
        UserName = result.Data.Data.Name;
    }

    [ObservableProperty]
    string _UserName;
    

    [ObservableProperty]
    bool _loginbuttonvis;

    
}
