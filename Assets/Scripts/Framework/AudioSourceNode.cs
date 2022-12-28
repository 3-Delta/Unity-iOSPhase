using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apple.PHASE;

[DisallowMultipleComponent]
public class AudioSourceNode : MonoBehaviour
{
    public PHASESource source;

    public static List<PHASESource> sources = new List<PHASESource>();

    public void OnEnable()
    {
        if(this.source != null)
            sources.Add(this.source);
    }

    private void OnDisable()
    {
        sources.Remove(this.source);
    }
}
