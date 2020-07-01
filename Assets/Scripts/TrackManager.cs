using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TrackManager : MonoBehaviour
{

    //gameobject with the Dolly Cart component
    //public CinemachineDollyCart GameplayPlaneObj;
    //tracks to switch
    public Cinemachine.CinemachinePathBase[] m_Paths;

    private Dictionary<string, int> dictUiPaths;

    private void Start()
    {
        EventManager.instance.onUiInteraction += OnUiInteraction;
        dictUiPaths = new Dictionary<string, int>() {
            { "Left Button", 1 }, 
            { "Right Button", 0 } 
        };
    }

    private void OnDestroy()
    {
        EventManager.instance.onUiInteraction += OnUiInteraction;
    }

    void OnUiInteraction(string uiName)
    {
        GameObject gameplayPlane = GameObject.FindGameObjectWithTag("GameplayPlane");
        gameplayPlane.GetComponent<Cinemachine.CinemachineDollyCart>().m_Path = m_Paths[dictUiPaths[uiName]];
    }
}
