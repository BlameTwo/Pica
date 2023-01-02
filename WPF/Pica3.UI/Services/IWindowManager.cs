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
        public Window MainWindow { get; set; }
        public void SetMaxHeight(double value);
        public void SetMinHeight(double value);
        public void SetMinWidth(double value);

        public void SetMaxWidth(double value);
    }
}
