using Pica.ViewModels.DetailsViewModels;

namespace Pica.Views.Details;

public partial class ComicDocumentDetailPage : ContentPage
{
	public ComicDocumentDetailPage(ComicDocumentDetailViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}