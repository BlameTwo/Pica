using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pica.Helper;
using Pica.Interfaces.Provider;
using Pica.Models.ApiModels.Users;
using Pica.Models.ConvertViewModel;
using System.Collections.ObjectModel;

namespace Pica.ViewModels;

public partial class RandomViewModel:ObservableObject
{
	public RandomViewModel(IComicProvider comicProvider,IImageDownloadProvider imageDownloadProvider)
	{
        ComicProvider = comicProvider;
        ImageDownloadProvider = imageDownloadProvider;
        ComicList = new() ;

    }

    [RelayCommand]
    void Loaded() 
    {
        Isrefersh = true;
    }

    [RelayCommand]
    void ScrollRefersh() => refershrandom();
    public async void refershrandom()
    {
        var list = (await ComicProvider.GetRandomComic().ConfigureAwait(false)).Data.ComicList.ToObservable();
        this.ComicList.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            var val = list[i].ChildConvert<Comics_Docs, RandomItemDataViewModel,IImageDownloadProvider>(ImageDownloadProvider);
            ComicList.Add(val);
        }

        Isrefersh = false;
    }

    public async void AddData()
    {
        Isadd = true;
        var result = (await ComicProvider.GetRandomComic().ConfigureAwait(false)).Data.ComicList.ToObservableCollection();
        foreach (var item in result)
        {
            var val = item.ChildConvert<Comics_Docs, RandomItemDataViewModel,IImageDownloadProvider>(ImageDownloadProvider);
            this.ComicList.Add(val);
        }
        Isadd = false;
    }

    [ObservableProperty]
    ObservableCollection<RandomItemDataViewModel> _comicList;

    [ObservableProperty]
    bool isrefersh;

    [ObservableProperty]
    bool isadd;
    public IComicProvider ComicProvider { get; }
    public IImageDownloadProvider ImageDownloadProvider { get; }
}
