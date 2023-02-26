using Pica.ViewModels;

namespace Pica.Views;

public partial class SearchPage : ContentPage
{
	public SearchPage(SearchViewModel search)
	{
		this.BindingContext = search;
		InitializeComponent();
    }


    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if(this.BindingContext is SearchViewModel vm)
        {
            vm.SelectKeysCommand.Execute(e.Item);
        }
    }

    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {

    }
}