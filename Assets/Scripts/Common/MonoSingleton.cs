using UnityEngine;
using System.Collections;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance 
    {
        get
        {
            if(_instance==null)
            {
                _instance = FindObjectOfType<T>();
            }
            if(_instance==null)
            {
                var go = new GameObject(typeof(T).FullName);
                go.hideFlags = HideFlags.HideAndDontSave | HideFlags.HideInInspector; // 63
                _instance = go.AddComponent<T>();
            }
            return _instance;
        }
    }
}
