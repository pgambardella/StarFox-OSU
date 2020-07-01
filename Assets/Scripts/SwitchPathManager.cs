using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPathManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EventManager.instance.ShowSwitchPathUI();
    }

    private void OnTriggerExit(Collider other)
    {
        EventManager.instance.HideSwitchPathUI();
    }
}
