using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pica.Extend;

public static class Tools
{
    public static ObservableCollection<T> ToObservableCollection<T>(this List<T> list)
    {
        var value = new ObservableCollection<T>();   
        list.ForEach((x)=>value.Add(x));
        return value;
    }

}
