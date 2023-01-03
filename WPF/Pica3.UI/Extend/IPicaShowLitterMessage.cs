using System;
using System.Windows.Controls;

namespace Pica3.UI.Extend
{

    /// <summary>
    /// 对消息框扩展的服务
    /// </summary>
    public interface IPicaShowLitterMessage
    {
        /// <summary>
        /// 他的Parent元素
        /// </summary>
        public Panel ShowOwner { get; set; }

        /// <summary>
        /// 显示时间
        /// </summary>

        public TimeSpan ShowTime { get; set; }

        /// <summary>
        /// 显示方法
        /// </summary>
        /// <param name="message"></param>
        public void Show(string message);
    }
}
