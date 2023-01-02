using System.Windows;

namespace Pica3.UI.Controls
{

    public class TextBox : System.Windows.Controls.TextBox
    {
        static TextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBox), new FrameworkPropertyMetadata(typeof(TextBox)));

        }

        public TextBox()
        {

        }



        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(TextBox), new PropertyMetadata(new CornerRadius(0)));







        public Visibility ClearVisibily
        {
            get { return (Visibility)GetValue(ClearVisibilyProperty); }
            set { SetValue(ClearVisibilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ClearVisibily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClearVisibilyProperty =
            DependencyProperty.Register("ClearVisibily", typeof(Visibility), typeof(TextBox), new PropertyMetadata(Visibility.Visible));




        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Placeholder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(TextBox), new PropertyMetadata(""));




    }
}
