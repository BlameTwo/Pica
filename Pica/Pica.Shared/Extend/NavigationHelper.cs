using Microsoft.UI.Xaml;

namespace Pica.Extend;

public class NavigationHelper
{




    public static string GetNavigaTo(DependencyObject obj)
    {
        return (string)obj.GetValue(NavigaToProperty);
    }

    public static void SetNavigaTo(DependencyObject obj, string value)
    {
        obj.SetValue(NavigaToProperty, value);
    }

    public static readonly DependencyProperty NavigaToProperty =
        DependencyProperty.RegisterAttached("NavigaTo", typeof(string), typeof(NavigationHelper), new PropertyMetadata(null));




}
