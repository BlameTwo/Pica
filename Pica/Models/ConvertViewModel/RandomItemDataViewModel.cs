﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pica.Interfaces.Provider;
using Pica.Models.ApiModels.Users;
using Pica.Services.Interfaces;
using Pica.Views.Details;

namespace Pica.Models.ConvertViewModel;

[INotifyPropertyChanged]
public partial class RandomItemDataViewModel : 
    Comics_Docs, 
    IChildParamer<IImageDownloadProvider>
{
    public IImageDownloadProvider ChildParamer { get; set; }

    public RandomItemDataViewModel()
    {
        
    }



    [RelayCommand]
    async void Loaded()
    {
        Picload = true;
        if (ChildParamer == null) return;
        var stream = await ChildParamer.DownloadImage($"{this.Thumb.FileServer}/static/{this.Thumb.Path}");
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
