using Pica.Interfaces.Provider;
using Pica.Models.ApiModels.Search;

namespace Pica.ViewModels.DetailsViewModels;

public partial class SearchDetailViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    string _title;


    public SearchDetailViewModel(ISearchProvider searchProvider)
    {
        SearchProvider = searchProvider;
    }

    public ISearchProvider SearchProvider { get; }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        object? type = null, key = null;
        if (query == null) return;
        query.TryGetValue("type", out type);
        query.TryGetValue("key", out key);
        if(type.ToString() == "catkeys")
        {

        }else if(type.ToString() == "keyword")
        {
            var result =  await SearchProvider.Search(key.ToString(),1, Models.ApiModels.SortType.ua,null);
            this.Data = result.Data.Comics;
        }
        this.Title = key.ToString();


    }


    [ObservableProperty]
    SearchResultData _Data;

}
