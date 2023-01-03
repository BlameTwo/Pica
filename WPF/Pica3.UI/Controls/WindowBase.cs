using Pica3.UI.Tools;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;

namespace Pica3.UI.Controls
{
    public class WindowBase : Window
    {
        static WindowBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowBase), new FrameworkPropertyMetadata(typeof(WindowBase)));
        }

        public WindowBase()
        {
            this.StateChanged += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.BorderThickness = new Thickness(10);
                    MaxContent = "\uE923";
                }

                else if (this.WindowState == WindowState.Normal)
                {
                    this.BorderThickness = new Thickness(0);
                    MaxContent = "\uE922";
                }

            };


            MinWin = new UICommand((obj) =>
            {
                return true;
            }, (obj) =>
            {
                this.WindowState = WindowState.Minimized;
            });

            MaxWin = new UICommand((obj) =>
            {
                //判断是否能够最大化
                if (this.ResizeMode == ResizeMode.NoResize)
                    return false;
                return true;

            }, (obj) =>
            {
                if (this.WindowState == WindowState.Normal)
                    this.WindowState = WindowState.Maximized;
                else
                    this.WindowState = WindowState.Normal;
            });

            ExitWin = new UICommand((obj) =>
            {
                return true;
                return false;
            }, (obj) =>
            {
                this.Close();
            });
        }



        public ICommand MinWin
        {
            get { return (ICommand)GetValue(MinWinProperty); }
            set { SetValue(MinWinProperty, value); }
        }

        public static readonly DependencyProperty MinWinProperty =
            DependencyProperty.Register("MinWin", typeof(ICommand), typeof(WindowBase), new PropertyMetadata(default(ICommand)));



        public ICommand MaxWin
        {
            get { return (ICommand)GetValue(MaxWinProperty); }
            set { SetValue(MaxWinProperty, value); }
        }

        public static readonly DependencyProperty MaxWinProperty =
            DependencyProperty.Register("MaxWin", typeof(ICommand), typeof(WindowBase), new PropertyMetadata(default(ICommand)));

        public string MaxContent
        {
            get { return (string)GetValue(MaxContentProperty); }
            set { SetValue(MaxContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxContentProperty =
            DependencyProperty.Register("MaxContent", typeof(string), typeof(WindowBase), new PropertyMetadata("\uE922"));


        public ICommand ExitWin
        {
            get { return (ICommand)GetValue(ExitWinProperty); }
            set { SetValue(ExitWinProperty, value); }
        }

        public static readonly DependencyProperty ExitWinProperty =
            DependencyProperty.Register("ExitWin", typeof(ICommand), typeof(WindowBase), new PropertyMetadata(default(ICommand)));


        public object HeaderContent
        {
            get { return (object)GetValue(HeaderContentProperty); }
            set { SetValue(HeaderContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderContentProperty =
            DependencyProperty.Register("HeaderContent", typeof(object), typeof(WindowBase), new PropertyMetadata(default(object)));

    }
}
