using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pica.Interfaces.Provider;
using Pica.Models.ApiModels.Comics;
using Pica.Models.ConvertViewModel;
using Pica.Views.Details;
using System.Collections.ObjectModel;

namespace Pica.ViewModels.DetailsViewModels;

[QueryProperty("Id", "Id")]
public partial class ComicDetailViewModel : ObservableObject, IQueryAttributable
{
    public ComicDetailViewModel(IComicProvider comicProvider,IImageDownloadProvider imagedown)
    {
        ComicProvider = comicProvider;
        Imagedown = imagedown;
    }

    /// <summary>
    /// 类型传递
    /// </summary>
    /// <param name="query"></param>
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {//类型传递
    }

    [ObservableProperty]
    string id;


    [RelayCommand]
    async void Loaded()
    {
        var result = await ComicProvider.GetComicDetail(Id);
        if (result.Data != null) Comicdata = result.Data.ComicDetail;
        Stream  stream = await Imagedown.DownloadImage($"{Comicdata.Thumb.FileServer}/static/{Comicdata.Thumb.Path}");
        Imagepic = ImageSource.FromStream(()=>stream);
        var pageslist = await ComicProvider.GetComicEpisode(Id);
        this.EpsList = pageslist.Data.ComicEp_Eps;
    }

    [RelayCommand]
    async void SelectPage()
    {
        Dictionary<string, Object> value = new();
        value.Add("Order", this.Selectpage.Order.ToString());
        value.Add("ID", this.Id);
        value.Add("ComicTitle", this.Comicdata.Title);
        await Shell.Current.GoToAsync(nameof(ComicDocumentDetailPage),true,value);
        
    }

    [ObservableProperty]
    string _title;
    public IComicProvider ComicProvider { get; }
    public IImageDownloadProvider Imagedown { get; }

    [ObservableProperty]
    ComicDetail comicdata;

    [ObservableProperty]
    Eps_Docs _selectpage;

    [ObservableProperty]
    ImageSource imagepic;

    [ObservableProperty]
    ComicEp_Eps _epsList;


}
