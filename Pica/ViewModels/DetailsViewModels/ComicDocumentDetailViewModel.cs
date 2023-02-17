using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pica.Helper;
using Pica.Interfaces.Provider;
using Pica.Models.ApiModels;
using Pica.Models.ApiModels.Comics;
using Pica.Models.ConvertViewModel;
using System.Collections.ObjectModel;

namespace Pica.ViewModels.DetailsViewModels;

public partial class ComicDocumentDetailViewModel : ObservableObject, IQueryAttributable
{
    public ComicDocumentDetailViewModel(IComicProvider comicProvider,IImageDownloadProvider imageDownloadProvider)
    {
        ComicProvider = comicProvider;
        ImageDownloadProvider = imageDownloadProvider;
        this.Pages = new();
    }

    public IComicProvider ComicProvider { get; }
    public IImageDownloadProvider ImageDownloadProvider { get; }

    [RelayCommand]
    async void Loaded()
    {
        if(
            (await ComicProvider.GetComicPages(this.id.ToString()!, order.ToString()).ConfigureAwait(false) is ResultCode<ComicPageData> arg)
            &&arg.Data!=null)
        {
            this.Documentdata = arg.Data;
            for (int i = 0; i < arg.Data.Pages.Documents.Count; i++)
            {
                var val = arg.Data.Pages.Documents[i].ChildConvert<Comic_Page_Document, WatchComicPagesItemDataViewModel, IImageDownloadProvider>(ImageDownloadProvider);
                Pages.Add(val);
            }
        }


    }
    object order=null, id=null;
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        object title = null;
        query.TryGetValue("Order", out order);
        query.TryGetValue("ID", out id);
        query.TryGetValue("ComicTitle", out title);
        string titstr = title.ToString();
        if (!string.IsNullOrWhiteSpace(titstr))
            this.   Title = titstr;
    }


    [ObservableProperty]
    ComicPageData documentdata;

    [ObservableProperty]
    ObservableCollection<WatchComicPagesItemDataViewModel> pages;


    [ObservableProperty]
    string title;
}
