using Pica3.UI.Extend;
using Pica3.UI.Services;
using Pica3.UI.Tools;
using System.Windows.Documents;
using System.Windows;
using Microsoft.Xaml.Behaviors.Layout;

namespace Pica3.Extend
{
    public class PicaShowDialog : IPicaShowDialog
    {
        public bool IsShow
        {
            get
            {
                //这里去判断一下是否有弹窗正在运行
                FrameworkElement element;
                AdornerDecorator decorator;
                element = WindowHelper.GetActiveWindow();
                decorator = WindowHelper.GetChild<AdornerDecorator>(element);
                AdornerLayer layer = decorator.AdornerLayer;
                var _container = new AdornerContainer(layer);
                return _container.Child == null ? true : false;
            }
        }

        public bool Show<T>(T arg) where T : IDialogHost
        {
            if (IsShow)
            {
                //显示出对话框
                arg.Show();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
