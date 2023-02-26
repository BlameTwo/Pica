using Pica.ViewModels.DetailsViewModels;

namespace Pica.Views.Details;

public partial class SearchDetailPage : ContentPage
{
	public SearchDetailPage(SearchDetailViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

}