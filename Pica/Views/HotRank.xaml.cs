using Pica.ViewModels;

namespace Pica.Views;

public partial class HotRank : ContentPage
{
	public HotRank(HotRankViewModel hotRankViewModel)
	{
        this.BindingContext= hotRankViewModel;
		InitializeComponent();
	}

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
    }
}