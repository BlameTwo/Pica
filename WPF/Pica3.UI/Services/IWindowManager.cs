using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pica3.UI.Services
{
    public interface IWindowManager
    {
        /// <summary>
        /// 设置主窗口对象
        /// </summary>
        public Window MainWindow { get; set; }

        /// <summary>
        /// 最大高度
        /// </summary>
        /// <param name="value"></param>
        public void SetMaxHeight(double value);

        /// <summary>
        /// 最小高度
        /// </summary>
        /// <param name="value"></param>
        public void SetMinHeight(double value);

        /// <summary>
        /// 最小宽度
        /// </summary>
        /// <param name="value"></param>
        public void SetMinWidth(double value);

        /// <summary>
        /// 最大宽度
        /// </summary>
        /// <param name="value"></param>

        public void SetMaxWidth(double value);
    }
}
