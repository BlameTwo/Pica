using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pica.Helper;
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
        Epsdocs = new();
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
        foreach (var item in pageslist.Data.ComicEp_Eps.Eps_Docs)
        {
            var val = item.ChildConvert<Eps_Docs, Eps_ItemViewModel, Eps_Nav_Mod>(new Eps_Nav_Mod()
            {
                 ComicTitle = Comicdata.Title,
                  ID = this.Id
            });
            Epsdocs.Add(val);
        }
    }


    public IComicProvider ComicProvider { get; }
    public IImageDownloadProvider Imagedown { get; }

    [ObservableProperty]
    ComicDetail comicdata;

    [ObservableProperty]
    Eps_Docs _selectpage;

    [ObservableProperty]
    ImageSource imagepic;

    [ObservableProperty]
    List<Eps_ItemViewModel> _epsdocs;


}
