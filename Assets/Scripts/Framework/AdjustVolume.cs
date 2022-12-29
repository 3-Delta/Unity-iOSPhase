using System;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_IPHONE || UNITY_IOS || UNITY_EDITOR_OSX
using Apple.PHASE;
using UnityEngine.SceneManagement;

public class AdjustVolume : MonoBehaviour
{
    public Slider slider;
    public Text num;
    
    public Button button1;
    public Button button2;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        slider.onValueChanged.AddListener(OnValueChanged);
        button1.onClick.AddListener(Onbutton1Clicked);
        button2.onClick.AddListener(Onbutton2Clicked);
    }

    private void OnValueChanged(float v)
    {
        foreach (var kvp in PHASESource._registeredSources)
        {
            Helpers.PHASEAdjustVolume(kvp.Key, v);
        }
    }

    private void Update()
    {
        num.text = $"sources: {PHASESource._registeredSources.Count.ToString()}";
    }

    private void Onbutton1Clicked()
    {
        SceneManager.LoadScene(1);
    }
    
    private void Onbutton2Clicked() {
        SceneManager.LoadScene(2);
    }
}
#else
public class AdjustVolume : MonoBehaviour { }
#endif
