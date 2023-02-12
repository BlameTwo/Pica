using CommunityToolkit.Mvvm.ComponentModel;
using Pica.Interfaces;

namespace Pica.ViewModels;

public partial class ShellViewModel:ObservableObject
{
	public ShellViewModel(IAppNavigationService appNavigationService, IAppNavigationViewService appNavigationViewService)
	{
        AppNavigationService = appNavigationService;
        AppNavigationViewService = appNavigationViewService;
    }

    public IAppNavigationService AppNavigationService { get; }
    public IAppNavigationViewService AppNavigationViewService { get; }
}
