using CommunityToolkit.Maui.Markup;
using Pica.ViewModels;
using System.Diagnostics;

namespace Pica.Views;

public partial class RandomPage : ContentPage
{
	public RandomPage(RandomViewModel randomViewModel)
	{
		this.BindingContext= randomViewModel;
		InitializeComponent();
		views.RemainingItemsThresholdReached += views_RemainingItemsThresholdReached;

    }


    private async void views_RemainingItemsThresholdReached(object sender, EventArgs e)
    {
		views.RemainingItemsThresholdReached -= views_RemainingItemsThresholdReached;
		if(this.BindingContext is RandomViewModel vm)
		{
			await vm.AddData();
		}
		views.RemainingItemsThresholdReached += views_RemainingItemsThresholdReached;
    }
}