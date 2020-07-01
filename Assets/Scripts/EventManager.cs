using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public event UnityAction<string> onUiInteraction;
    public void UiInteraction(string uiName)
    {
        if (onUiInteraction != null)
        {
            onUiInteraction(uiName);
        }
    }

    public event UnityAction onShowSwitchPathUI;
    public void ShowSwitchPathUI()
    {
        if (onShowSwitchPathUI != null)
        {
            onShowSwitchPathUI();
        }
    }

    public event UnityAction onHideSwitchPathUI;
    public void HideSwitchPathUI()
    {
        if (onHideSwitchPathUI != null)
        {
            onHideSwitchPathUI();
        }
    }
}
