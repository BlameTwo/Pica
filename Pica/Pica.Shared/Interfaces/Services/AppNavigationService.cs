using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Pica.Extend;
using System;

namespace Pica.Interfaces.Services;

public class AppNavigationService : IAppNavigationService
{
    Frame _appframe = null;
    public Frame AppFrame
    {
        get
        {
            if(_appframe == null)
            {
                RegisterEvent(_appframe);
            }
            return _appframe;
        }
        set
        {
            UnRetisterEvent(value);
            _appframe= value;
            RegisterEvent(_appframe);
        }
    }

    private void UnRetisterEvent(Microsoft.UI.Xaml.Controls.Frame value)
    {
        value.Navigated -= AppFrameHandle;
    }

    private void RegisterEvent(Microsoft.UI.Xaml.Controls.Frame frame)
    {
        frame.Navigated += AppFrameHandle;
    }

    public bool? AppFrameCanGoBack => _appframe.CanGoBack;

    public IPageType PageType { get; }

    public event NavigatedEventHandler AppFrameHandle;

    public bool GoBack()
    {
        if (AppFrameCanGoBack is true)
        {
            _appframe.GoBack();
            return true;
        }
        return false;
                
    }

    public bool GoForward()
    {
        if (_appframe.CanGoForward is true)
        {
            _appframe.GoForward();
            return true;
        }
        return false;
    }

    public bool NavigationTo(string pagekey, object parameter = null)
    {
        var pagetype = PageType.GetPageType(pagekey);

        if(_appframe != null
            && _appframe.Content.GetType() != pagetype)
        {
            var viewmodel = _appframe.GetPageViewModel();
            var naved = _appframe.Navigate(pagetype, parameter);
            return true;
        }
        return false;
    }


    public AppNavigationService(IPageType pageType)
    {
        PageType = pageType;
    }
}
