using Pica3.UI.Services;

namespace Pica3.UI.Extend
{
    public interface IPicaShowDialog
    {
        /// <summary>
        /// 扩展，用来显示对话框,如果返回false则当前已经有一个对话框了
        /// </summary>
        /// <typeparam name="T">继承于IDialogHost的一个类</typeparam>
        bool Show<T>(T arg)
            where T : IDialogHost;

        /// <summary>
        /// 此时是否可弹出对话框
        /// </summary>
        bool IsShow { get;}
    }
}
