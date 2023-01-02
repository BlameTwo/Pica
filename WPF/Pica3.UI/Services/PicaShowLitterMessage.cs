using Pica3.UI.Controls;
using Pica3.UI.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pica3.UI.Services
{
    public class PicaShowLitterMessage : IPicaShowLitterMessage
    {
        public Panel ShowOwner { get; set; }
        public TimeSpan ShowTime { get; set; }

        public void Show(string message)
        {
            IToastService control = new ToastControl();
            control.OwnerPanel = ShowOwner;
            control.Message = message;
            control.Show(ShowTime);
        }
    }
}
