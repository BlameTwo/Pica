using Microsoft.UI.Xaml.Controls;

namespace Pica.Interfaces;

public interface IAppNavigationViewService
{

    void Initialize(NavigationView navigationView);

    void UnreigisterEvent();

    NavigationViewItem GetSelectItem();


}
