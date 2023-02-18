using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Pica.Interfaces.Provider;
using Pica.Models.ApiModels.Comics;
using Pica.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    public WatchComicPagesItemDataViewModel()
    {
        
    }

    [RelayCommand]
    async void Loaded()
    {
        if (this.ChildParamer == null) return;
        string url = this.FileSource.FileServer.Contains("static") ? this.FileSource.FileServer + this.FileSource.Path : $"{this.FileSource.FileServer}/static/{this.FileSource.Path}";
        try
        {
            StreamImageSource source = new();
            source.Stream = new Func<CancellationToken, Task<Stream>>(async (s) =>
            {
                try
                {
                    return await ChildParamer.DownloadImage(url);
                }
                catch (Java.Lang.RuntimeException ex2)
                {
                    return null;
                }
            });
            this.ImageSource = source;
        }
        catch (Java.Lang.RuntimeException ex)
        {

        }
    }

    [ObservableProperty]
    ImageSource _imageSource;
}
