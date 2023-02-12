
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace Pica.ViewModels;

public partial class MainViewModel:ObservableObject
{
	public MainViewModel()
	{
		InitMenu();
    }

    private void InitMenu()
    {
        this.MenuItemSource = new ObservableCollection<NavigationViewItem>()
        {
            new NavigationViewItem(){Content = "首页",Icon = new FontIcon
            { 
                Glyph = "\uE10F" },
            },
            new NavigationViewItem(){Content = "搜索",Icon = new FontIcon
            {
                 Glyph = "\uE721" },
            },

            new NavigationViewItem(){Content = "排行",Icon = new FontIcon
            {
                 Glyph = "\uE74c" },
            },
             new NavigationViewItem(){Content = "个人",Icon = new FontIcon
            {
                Glyph = "\uE776" },
            }

        };
    }

    private ObservableCollection<NavigationViewItem> _List;

	public ObservableCollection<NavigationViewItem> MenuItemSource
	{
		get { return _List; }
		set =>SetProperty(ref _List, value);
	}


}
