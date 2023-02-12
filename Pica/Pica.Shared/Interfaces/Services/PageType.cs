using Microsoft.UI.Xaml.Controls;
using Pica.ViewModels;
using Pica.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pica.Interfaces.Services;

public class PageType : IPageType
{
    public readonly Dictionary<string, Type> _pages = new();


    public PageType()
    {
        Register<LoginViewModel, LoginPage>();
    }

    private void Register<VM, V>()
        where V:Page
    {
        lock (_pages)
        {
            var key = typeof(VM).FullName;

            if (_pages.ContainsKey(key))
                throw new ArgumentException($"不存在{key}");
            var type = typeof(V);
            if(_pages.ContainsValue(type))
                throw new ArgumentException($"不存在{type}");

            _pages.Add(key, type);
        }
    }

    public Type GetPageType(string key)
    {
        Type type;
        lock (_pages)
        {
            if(!_pages.TryGetValue(key,out type))
            {
                throw new ArgumentException($"不存在{key} 和 {type}");
            }
        }
        return type;
    }
}
