using System;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_IPHONE || UNITY_IOS || UNITY_EDITOR_OSX
using System.Collections;
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
        gameObject.AddComponent<PHASEEngine>();

        SceneManager.sceneLoaded += OnSceneLoaded;

        var go = new GameObject("Listener");
        go.AddComponent<ReplacePhaseListener>().GetComponent<PHASEListener>().enabled = false;
        DontDestroyOnLoad(go);
        
        slider.onValueChanged.AddListener(OnValueChanged);
        button1.onClick.AddListener(Onbutton1Clicked);
        button2.onClick.AddListener(Onbutton2Clicked);
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.LogError($"SceneName {arg0.name}");
        if (arg0.name.Equals("1"))
        {
            StartCoroutine(nameof(LoadListener));
        }
    }

    private IEnumerator LoadListener()
    {
        yield return new WaitForSeconds(13f);
        
        var go = new GameObject("ListenerFinal", typeof(ReplacePhaseListener));
        go.transform.localPosition = new Vector3(100, 100, 100);
    }

    private void OnValueChanged(float v)
    {
        Debug.LogError("===============");
        foreach (var kvp in PHASESource._registeredSources)
        {
            if (kvp.Value == null)
            {
                continue;
            }

            Debug.LogError($"id:{kvp.Key} {kvp.Value.name} isPlaying? {kvp.Value.IsPlaying()}");
            Helpers.PHASEAdjustVolume(kvp.Key, v);
        }
    }

    private void Update()
    {
        num.text = $"sources: {PHASESource._registeredSources.Count.ToString()} listener: {Helpers.PHASEExistListener()}";
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
