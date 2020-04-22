using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Utils
{
    public static bool dEquals(this double d1, double d2, double e = 1E-5)
    {
        return Math.Abs(d1 - d2) <= e;
    }

    public static T GetOrAddComponent<T>(this GameObject go) where T:Component
    {
        return go.GetComponent<T>() ?? go.AddComponent<T>();
    }

    public static Component GetOrAddComponent(this GameObject go, Type component)
    {
        return go.GetComponent(component) ?? go.AddComponent(component);
    }

    public static Component GetOrAddComponent(this GameObject go, string component)
    {
        return go.GetComponent(component) ?? go.AddComponent(typeof(Utils).Assembly.GetType(component));
    }
}
