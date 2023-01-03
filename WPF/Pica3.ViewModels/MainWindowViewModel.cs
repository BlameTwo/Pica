using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Pica3.Models.Events;
using Pica3.UI.Extend;
namespace Pica3.ViewModels
{
    public partial class MainWindowViewModel: ObservableRecipient, IRecipient<LoginEvent>
    {
        /// <summary>
        /// MainWindow的ViewModel
        /// </summary>
        /// <param name="picaShowLitterMessage">消息通知服务</param>
        public MainWindowViewModel(IPicaShowLitterMessage picaShowLitterMessage)
        {
            IsActive= true;
            PicaShowLitterMessage = picaShowLitterMessage;
        }

        public IPicaShowLitterMessage PicaShowLitterMessage { get; }

        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="message"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Receive(LoginEvent message)
        {
            switch (message.Login)
            {
                case LoginEventEnum.Login:
                    PicaShowLitterMessage.Show("登录成功！");
                    break;
                case LoginEventEnum.UnLogin:
                    break;
            }
        }
    }
}
