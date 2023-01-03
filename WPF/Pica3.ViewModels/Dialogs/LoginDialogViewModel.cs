using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pica.Interfaces.Provider;
using Pica3.UI.Extend;
using System.Threading.Tasks;

namespace Pica3.ViewModels
{
    [INotifyPropertyChanged]
    public partial class LoginDialogViewModel
    {
        public LoginDialogViewModel(
            ILoginProvider loginProvider,
            IPicaShowLitterMessage picaShowLitterMessage)
        {
            LoginProvider = loginProvider;
            PicaShowLitterMessage = picaShowLitterMessage;
        }

        [ObservableProperty]
        string _account;

        [ObservableProperty]
        string _passwd;

        partial void OnAccountChanged(string value)
        {

        }

        public ILoginProvider LoginProvider { get; }
        public IPicaShowLitterMessage PicaShowLitterMessage { get; }

        [RelayCommand]
        async Task Login()
        {
            string name = this.Account;
            string password = this.Passwd;
            var result = await LoginProvider.LoginAsync(name, password);
        }
    }
}
