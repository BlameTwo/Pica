using Pica3.UI.Extend;
using Pica3.UI.Services;

namespace Pica3.Extend
{
    public class PicaShowDialog : IPicaShowDialog
    {
        public void Show<T>(T arg) where T : IDialogHost
        {
            //显示出对话框
            arg.Show();
        }
    }
}
