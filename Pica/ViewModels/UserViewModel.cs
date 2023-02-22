using CommunityToolkit.Maui.Views;
using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica.Models.ApiModels.Users;
using Pica.Models.Event;
using Pica.Views;
using Pica.Views.Popups;

namespace Pica.ViewModels;

public partial class UserViewModel:ObservableRecipient, IRecipient<LoginEventModel>
{
    public IPica3Client Pica3Client { get; }
    public IUserProvider UserProvider { get; }
    public IImageDownloadProvider ImageDownloadProvider { get; }

    public UserViewModel(IPica3Client pica3Client, IUserProvider userProvider,IImageDownloadProvider imageDownloadProvider)
	{
        Pica3Client = pica3Client;
        UserProvider = userProvider;
        ImageDownloadProvider = imageDownloadProvider;
        IsActive = true;
    }

    [RelayCommand]
    void Loaded()
    {
        if(Pica3Client.IsLogin())Refershuser();
    }

    [RelayCommand]
    void GoSetting()
    {
        Shell.Current.GoToAsync(nameof(SettingPage), true);
    }

    [RelayCommand]
    async void PashPica()
    {
        var result = await UserProvider.UserPauch().ConfigureAwait(false);
        if (result.Data == null) return;
        if (result.Data.Resource.Status == "fail")
        {
            Shell.Current.ShowPopup(new MessageDialog("已打卡",new(10)));
        }
        Shell.Current.ShowPopup(new MessageDialog("打卡成功", new(10)));
    }

    [RelayCommand]
    void RefershProfile()
    {
        Refershuser();
    }

    public void Receive(LoginEventModel message)
    {
        switch (message.IsLogin)
        {
            case true:
                Refershuser();
                break;
            case false:
                break;
        }
    }

    async void Refershuser()
    {
        Isrefersh = true;
        var result = await UserProvider.GetUserProfile().ConfigureAwait(false);
        if (result.Code == 401) return;
        if(result.Data.Data.Avatar != null)
        {
            //得替换一下字符串
            string url = result.Data.Data.Avatar.FileServer+"/"+"static"+"/" + result.Data.Data.Avatar.UriPath;
            var stream = await ImageDownloadProvider.DownloadImage(url).ConfigureAwait(false);
            this.Userpic = ImageSource.FromStream(()=>stream);
        }
        Userprofile = result.Data;
        Isrefersh = false;
    }

    [ObservableProperty]
    bool _isrefersh;

    [ObservableProperty]
    ImageSource _userpic;

    [ObservableProperty]
    UserProfileData _userprofile;

    
}
