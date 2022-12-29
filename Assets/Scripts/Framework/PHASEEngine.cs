using System;
using UnityEngine;

#if UNITY_IPHONE || UNITY_IOS || UNITY_EDITOR_OSX
using Apple.PHASE;
#endif

[DisallowMultipleComponent]
public class PHASEEngine : MonoBehaviour
{
#if UNITY_IPHONE || UNITY_IOS || UNITY_EDITOR_OSX
    private void Awake()
    {
        bool result = Helpers.PHASEStart();
        if (result == false)
        {
            Debug.LogError("Failed to start PHASE Engine");
        }
    }

    private void OnDestroy()
    {
        PHASESoundEventNodeGraph.UnregisterAll();
        Helpers.PHASEStop();
    }

    private void LateUpdate()
    {
        Helpers.PHASEUpdate();
    }
#endif
}
