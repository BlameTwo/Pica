using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica3.Models.Events;
using Pica3.UI.Extend;
using Pica3.UI.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Pica3.ViewModels
{
    [INotifyPropertyChanged]
    public partial class LoginDialogViewModel
    {
        /// <summary>
        /// 登录VM的构造函数
        /// </summary>
        /// <param name="loginProvider">登录控制器</param>
        /// <param name="pica3Client">Pica3的Client</param>
        /// <param name="picaShowLitterMessage">消息通知服务</param>
        public LoginDialogViewModel(
            ILoginProvider loginProvider,
            IPica3Client pica3Client,
            IPicaShowLitterMessage picaShowLitterMessage)
        {
            LoginProvider = loginProvider;
            Pica3Client = pica3Client;
            PicaShowLitterMessage = picaShowLitterMessage;
            Ips = new();
            IsLoging = true;
        }

        [ObservableProperty]
        string _account;

        [ObservableProperty]
        string _passwd;

        [ObservableProperty]
        ObservableCollection<string> _Ips;

        [ObservableProperty]
        string _IpSelectItem;

        [ObservableProperty]
        IDialogHost _MyHost;

        [ObservableProperty]
        bool _IsLoging;

        public ILoginProvider LoginProvider { get; }
        public IPica3Client Pica3Client { get; }
        public IPicaShowLitterMessage PicaShowLitterMessage { get; }

        [RelayCommand]
        async Task Login()
        {
            IsLoging = false;
            string name = this.Account;
            string password = this.Passwd;
            var result = await LoginProvider.LoginAsync(name, password);
            if (result)
            {
                WeakReferenceMessenger.Default.Send(new LoginEvent( LoginEventEnum.Login,"用户登录"));
                MyHost.Close();
            }
            IsLoging = true;
        }

        [RelayCommand]
        async Task Loaded()
        {
            var list = await Pica3Client.GetIpList();
            foreach (var ip in list.Ips) 
            { 
                Ips.Add(ip);
            }
        }

        [RelayCommand]
        void IpSelection()
        {
            Pica3Client.SetIp(null, IpSelectItem);
        }
    }
}
