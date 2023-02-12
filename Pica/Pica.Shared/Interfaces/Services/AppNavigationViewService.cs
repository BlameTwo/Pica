using Microsoft.UI.Xaml.Controls;
using Pica.Extend;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pica.Interfaces.Services
{
    public class AppNavigationViewService : IAppNavigationViewService
    {


        public AppNavigationViewService(IAppNavigationService appNavigationService,IPageType pageType)
        {
            AppNavigationService = appNavigationService;
            PageType = pageType;
        }

        public IAppNavigationService AppNavigationService { get; }
        public IPageType PageType { get; }

        public NavigationViewItem GetSelectItem()
        {
            return new();
        }
        NavigationView _appnavigation;

        public void Initialize(NavigationView navigationView)
        {
            _appnavigation = navigationView;
            _appnavigation.ItemInvoked += NavigationView_ItemInvoked;
            _appnavigation.BackRequested += NavigationView_BackRequested;
        }

        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            AppNavigationService.GoBack();
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {//设置页面

            }
            else
            {
                var selectitem = args.InvokedItemContainer as NavigationViewItem;
                if (selectitem?.GetValue(NavigationHelper.NavigaToProperty) is string pagekey)
                {
                    AppNavigationService.NavigationTo(pagekey,null);
                }
            }
        }

        public void UnreigisterEvent()
        {
            _appnavigation.ItemInvoked -= NavigationView_ItemInvoked;
            _appnavigation.BackRequested -= NavigationView_BackRequested;
        }
    }
}
