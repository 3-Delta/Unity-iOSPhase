using UnityEngine;
using UnityEngine.UI;

#if UNITY_IPHONE || UNITY_IOS || UNITY_EDITOR_OSX
using Apple.PHASE;

public class AdjustVolume : MonoBehaviour
{
    public Slider slider;
    public PHASESource source;

    private void Awake()
    {
        slider.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(float v)
    {
        Helpers.PHASEAdjustVolume(source.GetSourceId(), v);
    }
}
#else
public class AdjustVolume : MonoBehaviour { }
#endif
