using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pica3.UI.Services
{
    public class WindowManager : IWindowManager
    {
        private Window _window;
        public Window MainWindow
        {
            get { return _window; }
            set { _window = value; }
        }

        public void SetMaxHeight(double value)
        {
            _window.MaxHeight = value;
        }

        public void SetMaxWidth(double value)
        {
            _window.MaxWidth = value;
        }

        public void SetMinHeight(double value)
        {
            _window.MinHeight = value;
        }

        public void SetMinWidth(double value)
        {
            _window.MinWidth = value;
        }
    }
}
