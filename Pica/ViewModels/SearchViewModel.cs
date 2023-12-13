using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica.Views.Details;

namespace Pica.ViewModels;

public partial class SearchViewModel:ObservableObject
{
    public SearchViewModel(ISearchProvider searchProvider
        ,IPicaClient pica3Client)
    {
        SearchProvider = searchProvider;
        PicaClient = pica3Client;
    }

    [RelayCommand]
    void Loaded()
    {
        refreshkey();    
    }

    async void refreshkey()
    {
        if (PicaClient.IsLogin())
            this.Keys = (await SearchProvider.SearchKeys()).Data.KeyWords;
    }

    [RelayCommand]
    void RefreshKeys() => refreshkey();

    [RelayCommand]
    void SelectKeys(object key)
    {
        GoPage("catkeys", key.ToString());
    }

    [RelayCommand]
    void SearchKey()
    {
        GoPage("keyword", this.Searchkey);
    }

    async void GoPage(string type,string key)
    {
        Dictionary<string, object> keys = new();
        keys.Add("type", type);
        keys.Add("key", key.ToString());
        await Shell.Current.GoToAsync(nameof(SearchDetailPage), true, keys);
    }

    public ISearchProvider SearchProvider { get; }
    public IPicaClient PicaClient { get; }

    [ObservableProperty]
    List<string> _Keys;

    [ObservableProperty]
    string _Searchkey;
}
