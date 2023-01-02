using System;
using System.Windows.Controls;

namespace Pica3.UI.Extend
{
    public interface IPicaShowLitterMessage
    {
        public Panel ShowOwner { get; set; }

        public TimeSpan ShowTime { get; set; }

        public void Show(string message);
    }
}
