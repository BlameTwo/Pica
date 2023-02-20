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
	}

}