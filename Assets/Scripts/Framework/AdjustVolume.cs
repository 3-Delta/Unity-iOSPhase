using UnityEngine;
using UnityEngine.UI;

#if UNITY_IPHONE || UNITY_IOS || UNITY_EDITOR_OSX
using Apple.PHASE;

public class AdjustVolume : MonoBehaviour
{
    public Slider slider;
    public PHASESource source;
    public Rotator r;
    public Button button;

    private void Awake()
    {
        slider.onValueChanged.AddListener(OnValueChanged);
        button.onClick.AddListener(OnClicked);
    }

    private void OnValueChanged(float v)
    {
        Helpers.PHASEAdjustVolume(source.GetSourceId(), v);
    }

    private bool flag = true;
    private void OnClicked() {
        flag = !flag;
        r.enabled = flag;
    }
}
#else
public class AdjustVolume : MonoBehaviour { }
#endif
