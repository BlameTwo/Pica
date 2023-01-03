using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pica3.Models.Events
{
    /// <summary>
    /// 登录枚举
    /// </summary>
    public enum LoginEventEnum
    {
        /// <summary>
        /// 登录
        /// </summary>
        Login,
        /// <summary>
        /// 退出登录
        /// </summary>
        UnLogin
    }

    /// <summary>
    /// 登录事件参数
    /// </summary>
    public class LoginEvent
    {
        /// <summary>
        /// 触发的事件enum
        /// </summary>
        public LoginEventEnum Login { get;}

        /// <summary>
        /// 初始化，只是为了私有化
        /// </summary>
        /// <param name="login"></param>
        /// <param name="message"></param>
        public LoginEvent(LoginEventEnum login, string message)
        {
            Login = login;
            Message = message;
        }

        /// <summary>
        /// 显示的消息
        /// </summary>
        public string Message { get; }
    }
}
