using CommunityToolkit.Maui.Views;
using Pica.ViewModels;

namespace Pica.Views;

public partial class SearchPage : ContentPage
{
	public SearchPage(SearchViewModel search)
	{
		this.BindingContext = search;
		InitializeComponent();

	}
}