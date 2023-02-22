using Pica.ViewModels;

namespace Pica.Views;

public partial class SettingPage : ContentPage
{
    public SettingPage(SettingViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}