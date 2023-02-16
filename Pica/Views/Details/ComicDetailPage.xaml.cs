using Pica.Models.ConvertViewModel;
using Pica.ViewModels.DetailsViewModels;

namespace Pica.Views.Details;


[QueryProperty(nameof(RandomItemDataViewModel), "ComicData")]
public partial class ComicDetailPage : ContentPage
{
	public ComicDetailPage(ComicDetailViewModel comicDetailViewModel)
	{
		InitializeComponent();
        this.BindingContext = comicDetailViewModel;
    }
}