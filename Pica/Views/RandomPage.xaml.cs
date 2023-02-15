using CommunityToolkit.Maui.Markup;
using Pica.ViewModels;
using System.Diagnostics;

namespace Pica.Views;

public partial class RandomPage : ContentPage
{
	public RandomPage(RandomViewModel randomViewModel)
	{
		this.BindingContext= randomViewModel;
		InitializeComponent();
	}

    private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {
        if(this.BindingContext is RandomViewModel vm)
        {
            var scrollView = sender as ScrollView;
            try
            {
                var contentSize = scrollView.ContentSize.Height;
                var contentSizeCheck = ((View)scrollView.Children[0]).Height; //for fun

                var maxPos = contentSize - scrollView.Height;

                //临时解决方案
                if ((int)e.ScrollY == (int)maxPos)
                {
                    vm.AddData();
                }
            }
            catch { }
        }
        
    }
}