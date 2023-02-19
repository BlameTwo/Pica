using Pica.Interfaces.Provider;
using Pica.Models.ApiModels.Users;
using Pica.Views.Details;

namespace Pica.Models.ConvertViewModel;

[INotifyPropertyChanged]
public partial class RandomItemDataViewModel : 
    Comics_Docs, 
    IChildPatamar<IImageDownloadProvider>
{
    public IImageDownloadProvider ChildPatamar { get; set; }


    [RelayCommand]
    async void Loaded()
    {
        Picload = true;
        if (ChildPatamar == null) return;
        var stream = await ChildPatamar.DownloadImage($"{this.Thumb.FileServer}/static/{this.Thumb.Path}");
        if(stream!=null)this.Imagepic = ImageSource.FromStream(()=>stream);
        Picload = false;
    }


    [RelayCommand]
    async void GoOpen() =>
        await Shell.Current.GoToAsync($"{nameof(ComicDetailPage)}?Id={this.ID}");

    [RelayCommand]
    void GoImageOpen()
    {

    }

    [ObservableProperty]
    private bool _picload;

    [ObservableProperty]
    private ImageSource _imagepic;


}
