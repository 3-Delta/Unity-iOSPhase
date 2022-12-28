using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apple.PHASE;

[DisallowMultipleComponent]
public class InstanceReplace : MonoBehaviour
{
    public PHASEListener target;

    [ContextMenu(nameof(Replace))]
    public void Replace() {
        StartCoroutine(nameof(_Replace));
    }

    private IEnumerator _Replace() {
        target.enabled = false;
        yield return null;

        var go = GameObject.Instantiate(target.gameObject, target.transform.parent);
        //go.transform.localPosition = Vector3.zero;
        var cp = go.GetComponent<PHASEListener>();
        cp.enabled = true;

        yield return null;
        foreach (var item in AudioSourceNode.sources)
        {
            if (item != null)
            {
                item.enabled = false;
                item.enabled = true;
            }
        }
    }
}
