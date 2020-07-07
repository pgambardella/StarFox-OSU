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

    public event UnityAction onShowAimUI;
    public void ShowAimUI()
    {
        if (onShowAimUI != null)
        {
            onShowAimUI();
        }
    }

    public event UnityAction onHideAimUI;
    public void HideAimUI()
    {
        if (onHideAimUI != null)
        {
            onHideAimUI();
        }
    }

    public event UnityAction<GameObject> onAimUIActivated;
    public void AimUIActivated(GameObject aimObj)
    {
        if (onAimUIActivated != null)
        {
            onAimUIActivated(aimObj);
        }
    }

    public event UnityAction onAimUIDeactivated;
    public void AimUIDeactivated()
    {
        if (onAimUIDeactivated != null)
        {
            onAimUIDeactivated();
        }
    }
}
