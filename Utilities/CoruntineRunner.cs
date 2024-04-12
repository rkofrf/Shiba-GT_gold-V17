using UnityEngine;
using Mono;
using System.Collections;

public class CoroutineRunner : MonoBehaviour
{
    private static CoroutineRunner instance;

    private void Awake()
    {
        instance = this;
    }

    public static void RunCoroutine(IEnumerator coroutine)
    {
        instance.StartCoroutine(coroutine);
    }

    public static void StopRunningCoroutine(IEnumerator coroutine)
    {
        instance.StopCoroutine(coroutine);
    }
}