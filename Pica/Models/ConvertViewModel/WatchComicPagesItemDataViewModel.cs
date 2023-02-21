using Pica.Interfaces.Provider;
using Pica.Models.ApiModels.Comics;

namespace Pica.Models.ConvertViewModel;

[INotifyPropertyChanged]
public partial class WatchComicPagesItemDataViewModel :
    Comic_Page_Document,
    IChildPatamar<IImageDownloadProvider>
{
    public IImageDownloadProvider ChildPatamar { get; set; }

    StreamImageSource source = null;
    [RelayCommand]
    void Loaded()
    {
        this.IsRuning = true;
        if (this.ChildPatamar == null)
        {
            IsRuning = false;
            return;
        }
        string url = this.FileSource.FileServer.Contains("static") ? this.FileSource.FileServer + this.FileSource.Path : $"{this.FileSource.FileServer}/static/{this.FileSource.Path}";
        source = new();
        source.Stream = new Func<CancellationToken, Task<Stream>>(async (s) =>
        {
            return await ChildPatamar.DownloadImage(url);
        });
        this.ImageSource = source;
        this.IsRuning = false;
    }

    [ObservableProperty]
    bool _IsRuning;

    [ObservableProperty]
    ImageSource _imageSource;
}
