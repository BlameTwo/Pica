using Pica.Interfaces.Provider;
using Pica.Models.ApiModels.Users;
using Pica.Views.Details;
using System.Diagnostics;

namespace Pica.Models.ConvertViewModel;

[INotifyPropertyChanged]
public partial class RandomItemDataViewModel : 
    Comics_Docs, 
    IChildPatamar<IImageDownloadProvider>
{
    public IImageDownloadProvider ChildPatamar { get; set; }


    StreamImageSource source = null;

    [RelayCommand]
    void Loaded()
    {
        Picload = true;
        if (ChildPatamar == null) return;
        string url = $"{this.Thumb.FileServer}/static/{this.Thumb.Path}";
        if (source == null)
        {
            source = new StreamImageSource();
            source.Stream = new Func<CancellationToken, Task<Stream>>(async (s) =>
            {
                try
                {
                    return await ChildPatamar.DownloadImage(url);
                }
                catch (Java.Lang.RuntimeException ex2)
                {
                    return null;
                }
            });

            Debug.WriteLine("加载新图像");
        }
        else
        {
            this.Imagepic = source;
            Debug.WriteLine("加载旧图像");
        }
        
        Imagepic = source;
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
