using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pica.Interfaces;

public interface IAppNavigationService
{
    Frame AppFrame { get; set; }


    bool? AppFrameCanGoBack { get; }


    event NavigatedEventHandler AppFrameHandle;

    bool GoBack();

    bool GoForward();


    bool NavigationTo(string pagekey, object parameter = null);
}
