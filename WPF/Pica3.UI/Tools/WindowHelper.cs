using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Pica3.UI.Tools
{
    public static class WindowHelper
    {
        public static Window GetActiveWindow()
        {
            return Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive)!;
        }

        public static T GetChild<T>(DependencyObject d) where T : DependencyObject
        {
            if (d == null) return default;
            if (d is T t) return t;

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(d); i++)
            {
                var child = VisualTreeHelper.GetChild(d, i);

                var result = GetChild<T>(child);
                if (result != null) return result;
            }

            return default;
        }

        public static T GetElment<T>(DependencyObject d, string name) where T : DependencyObject
        {
            if (d == null) return default;
            if (d is T t) return t;

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(d); i++)
            {
                var child = VisualTreeHelper.GetChild(d, i);

                var result = GetChild<T>(child);
                if (result != null)
                {
                    if (result is ContentControl content)
                    {
                        if (content.Name == name)
                            return result;
                    }
                }

            }

            return default;
        }
    }
}
