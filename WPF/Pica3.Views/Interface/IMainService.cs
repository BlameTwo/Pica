using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pica3.Views.Interface
{
    /// <summary>
    /// View中的依赖Host
    /// </summary>
    public interface IMainService
    {
        /// <summary>
        /// 已经注册好的管理器
        /// </summary>
        IHost Host { get; set; }


        /// <summary>
        /// 去已经注册好的管理器中，拿一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetService<T>() where T : class;
    }
}
