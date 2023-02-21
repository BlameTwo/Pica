using Pica.Models.ApiModels.Comics;
using Pica.Views.Details;

namespace Pica.Models.ConvertViewModel;

[INotifyPropertyChanged]
public partial class Eps_ItemViewModel : Eps_Docs
    , IChildPatamar<Eps_Nav_Mod>
{
    public Eps_Nav_Mod ChildPatamar { get; set; }


    [RelayCommand]
    async void GoRead()
    {
        Dictionary<string, Object> value = new();
        value.Add("Order", this.Order);
        value.Add("ID", ChildPatamar.ID);
        value.Add("ComicTitle", ChildPatamar.ComicTitle);
        await Shell.Current.GoToAsync(nameof(ComicDocumentDetailPage), true, value);
    }
}

public class Eps_Nav_Mod
{

    public string ID { get; set; }

    public string ComicTitle { get; set; }
}
