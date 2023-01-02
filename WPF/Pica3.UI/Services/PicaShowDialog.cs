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
                FrameworkElement element;
                AdornerDecorator decorator;
                element = WindowHelper.GetActiveWindow();
                decorator = WindowHelper.GetChild<AdornerDecorator>(element);
                AdornerLayer layer = decorator.AdornerLayer;
                var _container = new AdornerContainer(layer);
                return _container.Child == null ? true : false;
            }
        }

        

        bool IPicaShowDialog.Show<T>(T arg)
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
