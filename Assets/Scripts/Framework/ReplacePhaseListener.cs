using System;
using UnityEngine;

#if UNITY_IPHONE || UNITY_IOS || UNITY_EDITOR_OSX
[DisallowMultipleComponent]
public class ReplacePhaseListener : ReplaceComponent<Apple.PHASE.PHASEListener>
{
    public override Action<int> onReplace
    {
        get { return DEFAULT_REPLACE; }
    }

    public static void DEFAULT_REPLACE(int arg)
    {
        if (arg == 1 || arg == 2)
        {
            foreach (var item in AudioSourceNode.sources)
            {
                if (item != null)
                {
                    // 替换listener之后重新激活所有source
                    item.enabled = false;
                    item.enabled = true;
                }
            }
        }
    }
}
#endif