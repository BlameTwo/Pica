using Pica.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Pica.Helper;

public static class ToolsHelper
{

    /// <summary>
    /// 转换列表，<see cref="ObservableCollection{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    public static ObservableCollection<T> ToObservable<T>(this List<T> values)
    {
        var list = new ObservableCollection<T>();
        values.ForEach((val)=>list.Add(val));
        return list;
    }


    /// <summary>
    /// 父-->子，无参转换
    /// </summary>
    /// <typeparam name="Parent">父类</typeparam>
    /// <typeparam name="Child">子类</typeparam>
    /// <param name="data">父类本身</param>
    /// <returns></returns>
    public static Child ChildConvert<Parent, Child>(this Parent data)
        where Parent : class, new()
        where Child : Parent, new()
    {
        Child returnvalue = new Child();
        System.Reflection.PropertyInfo[] properties = data.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var item in properties)
        {
            if (!(item.CanRead && item.CanWrite)) continue;
            item.SetValue(returnvalue, item.GetValue(data));
        }
        return returnvalue;
    }

    /// <summary>
    /// 父-->子，带一个参数转换
    /// </summary>
    /// <typeparam name="Parent">父类</typeparam>
    /// <typeparam name="Child">子类</typeparam>
    /// <typeparam name="Paramer">子类继承参数</typeparam>
    /// <param name="parent">父类本身</param>
    /// <param name="paramer">参数</param>
    /// <returns></returns>
    public static Child ChildConvert<Parent, Child, Patamar>(this Parent parent, Patamar paramer)
        where Child:Parent,IChildPatamar<Patamar>, new()
        where Parent:class,new()
    {
        var result = ChildConvert<Parent, Child>(parent);
        result.ChildPatamar = paramer;
        return result;
    }
}
