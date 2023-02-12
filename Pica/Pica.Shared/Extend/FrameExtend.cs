using Microsoft.UI.Xaml.Controls;

namespace Pica.Extend;

public static class FrameExtend
{
    public static object? GetPageViewModel(this Frame frame)=>
        frame?.Content?.GetType()?.GetProperty("ViewModel")?.GetValue(frame.Content,null);
}
