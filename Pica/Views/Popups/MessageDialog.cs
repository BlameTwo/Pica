using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui;

namespace Pica.Views.Popups;

public class MessageDialog : Popup
{
    public MessageDialog(string message, Thickness padding)
    {
        Content =
            new Label()
            .Text(message)
            .Padding(padding)
            .CenterHorizontal()
            .CenterVertical();
        ResultWhenUserTapsOutsideOfPopup = false;
    }
}
