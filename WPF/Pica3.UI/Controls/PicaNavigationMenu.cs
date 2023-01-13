using Pica3.UI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Pica3.UI.Controls
{
    public class PicaNavigationMenu:ContentControl
    {
        public PicaNavigationMenu()
        {

        }

        static PicaNavigationMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PicaNavigationMenu), new FrameworkPropertyMetadata(typeof(PicaNavigationMenu)));
        }

        
        public string NavigationHeader
        {
            get { return (string)GetValue(NavigationHeaderProperty); }
            set { SetValue(NavigationHeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NavigationHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigationHeaderProperty =
            DependencyProperty.Register("NavigationHeader", typeof(string), typeof(PicaNavigationMenu), new PropertyMetadata("Test"));




        public double OpenLength
        {
            get { return (double)GetValue(OpenLengthProperty); }
            set { SetValue(OpenLengthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenLengthProperty =
            DependencyProperty.Register("OpenLength", typeof(double), typeof(PicaNavigationMenu), new PropertyMetadata(0.0));




        public event SelectionChangedEventHandler SelectionChanged;


    }
}
