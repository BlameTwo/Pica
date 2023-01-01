using Pica3.UI.Services;

namespace Pica3.UI.Extend
{
    public interface IPicaShowDialog
    {
        /// <summary>
        /// 扩展，用来显示对话框
        /// </summary>
        /// <typeparam name="T">继承于IDialogHost的一个类</typeparam>
        void Show<T>(T arg)
            where T : IDialogHost;
    }
}
