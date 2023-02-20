using CommunityToolkit.Maui.Alerts;

namespace Pica.Views.Controls;

public partial class LoadingUI : ContentView
{
	public LoadingUI()
	{
		InitializeComponent();
    }


    public static readonly BindableProperty IsRingProperty = 
		BindableProperty.Create(nameof(IsRing), typeof(bool), typeof(LoadingUI), false,propertyChanged:RingChanged);

    private static void RingChanged(BindableObject bindable, object oldValue, object newValue)
    {
		
    }



    public bool IsRing
	{
		get => (bool)this.GetValue(IsRingProperty);
		set => this.SetValue(IsRingProperty, value);
	}


}