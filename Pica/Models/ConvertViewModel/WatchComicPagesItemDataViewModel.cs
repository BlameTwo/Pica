using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pica.Interfaces.Provider;
using Pica.Models.ApiModels.Comics;
using Pica.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pica.Models.ConvertViewModel;

[INotifyPropertyChanged]
public partial class WatchComicPagesItemDataViewModel :
    Comic_Page_Document,
    IChildParamer<IImageDownloadProvider>
{
    public IImageDownloadProvider ChildParamer { get; set; }
    

    [RelayCommand]
    async void Loaded()
    {
        if (this.ChildParamer == null) return;
        string url = this.FileSource.FileServer.Contains("static") ? this.FileSource.FileServer + this.FileSource.Path : $"{this.FileSource.FileServer}/static/{this.FileSource.Path}";
        Stream stream = await ChildParamer.DownloadImage(url);
        if (stream == null) return;
        bool b = stream.CanRead;
        this.ImageSource = ImageSource.FromStream(() => stream);

    }

    [ObservableProperty]
    ImageSource _imageSource;
}
