using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class AimLogic : MonoBehaviour
{
    [SerializeField]
    float m_distanceToAim;

    GameObject m_aimUiObject;

    private void Start()
    {
        m_aimUiObject = null;
        EventManager.instance.onAimUIActivated += OnAimUIActivated;
    }

    private void OnDestroy()
    {
        EventManager.instance.onAimUIActivated -= OnAimUIActivated;
    }

    void Update()
    {
        //if the aim is activated
        if (m_aimUiObject != null)
        {
            //update aim position
            Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
            m_aimUiObject.transform.position = namePose;
        }
        

        //activate aim with distance
        Vector3 heading = transform.position - Camera.main.transform.position;
        float distance = Vector3.Dot(heading, Camera.main.transform.forward);
        if (m_aimUiObject == null && distance < m_distanceToAim)
        {
            EventManager.instance.ShowAimUI();
        } 

        //deactivate aim when the distance is overcomed
        if (m_aimUiObject != null && distance > m_distanceToAim)
        {
            EventManager.instance.HideAimUI();
        }
        
    }

    void OnAimUIActivated(GameObject aimObj)
    {
        if (aimObj != null)
        {
            m_aimUiObject = aimObj;
        }
    }
}

