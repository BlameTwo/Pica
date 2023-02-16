using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pica.Interfaces.Provider;

namespace Pica.ViewModels.DetailsViewModels;

public partial class ComicDocumentDetailViewModel : ObservableObject, IQueryAttributable
{
    public ComicDocumentDetailViewModel(IComicProvider comicProvider)
    {
        ComicProvider = comicProvider;
    }

    public IComicProvider ComicProvider { get; }

    [RelayCommand]
    async void Loaded()
    {
        var result =  await ComicProvider.GetComicPages(this.id.ToString()!,order.ToString());
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
    string title;
}
