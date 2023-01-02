using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pica3.UI.Services
{
    public interface IToastService
    {
        /// <summary>
        /// 弹出在哪里弹出
        /// </summary>
        public Panel OwnerPanel { get; set; }

        /// <summary>
        /// 弹出时间
        /// </summary>
        /// <param name="time"></param>
        public void Show(TimeSpan time);

        public string Message { get; set; }
    }
}
