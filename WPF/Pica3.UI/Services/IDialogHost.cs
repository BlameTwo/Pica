using System;

namespace Pica3.UI.Services
{
    public interface IDialogHost
    {
        /// <summary>
        /// 显示方法
        /// </summary>
        public void Show(object VM);

        public delegate void Showing();
        public delegate void Showed();
        public delegate void Closed();
        public delegate void Closeing();

        /// <summary>
        /// 弹出前事件
        /// </summary>
        public event Showing ShowingEvent;

        /// <summary>
        /// 弹出后事件
        /// </summary>
        public event Showed ShowedEvent;

        /// <summary>
        /// 关闭后事件
        /// </summary>
        public event Closed CloseEvent;

        /// <summary>
        /// 关闭后事件
        /// </summary>
        public event Closeing CloseingEvent;
        
        /// <summary>
        /// 关闭方法
        /// </summary>
        public void Close();
    }
}
