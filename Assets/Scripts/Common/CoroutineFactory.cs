using UnityEngine;
using System.Collections;

public class CoroutineFactory : MonoSingleton<CoroutineFactory>
{
    public static Coroutine Run(IEnumerator itor)
    {
        return Instance.StartCoroutine(itor);
    }

    public static void Stop(Coroutine cor)
    {
        Instance.StopCoroutine(cor);
    }
}
