using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject switchPathUi;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.onShowSwitchPathUI += OnShowSwitchPathUi;
        EventManager.instance.onHideSwitchPathUI += OnHideSwitchPathUi;
    }

    private void OnDestroy()
    {
        EventManager.instance.onShowSwitchPathUI -= OnShowSwitchPathUi;
        EventManager.instance.onHideSwitchPathUI -= OnHideSwitchPathUi;
    }

    void OnShowSwitchPathUi()
    {
        switchPathUi.SetActive(true);
    }

    void OnHideSwitchPathUi()
    {
        switchPathUi.SetActive(false);
    }
}
