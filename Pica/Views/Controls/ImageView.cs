namespace Pica.Views.Controls
{
    public class ImageView:Image
    {
        public static readonly Microsoft.Maui.Controls.BindableProperty ImageSourceProperty=
            BindableProperty.Create(
                nameof(ImageSource),
                typeof(ImageSource),
                typeof(ImageView),
                null,propertyChanged:OnImageSourceChanged);

        private static void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }

        public ImageSource ImageSource
        {
            get=> (ImageSource)GetValue(ImageSourceProperty);
            set=> SetValue(XProperty, value);
        }
    }
}
