using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class AimLogic : MonoBehaviour
{
    [SerializeField]
    float m_distanceToAim;

    [SerializeField]
    GameObject m_aimUiObject;

    private void OnDestroy()
    {
        m_aimUiObject.SetActive(false);
    }

    void Update()
    {
        //if the aim is activated
        if (m_aimUiObject.activeSelf)
        {
            //update aim position
            Vector3 aimPose = Camera.main.WorldToScreenPoint(this.transform.position);
            m_aimUiObject.transform.position = aimPose;
        }
        

        //activate aim with distance
        Vector3 heading = transform.position - Camera.main.transform.position;
        float distance = Vector3.Dot(heading, Camera.main.transform.forward);
        if (m_aimUiObject != null && distance < m_distanceToAim)
        {
            m_aimUiObject.SetActive(true);
        } 

        //deactivate aim when the distance is overcomed
        if (m_aimUiObject != null && distance > m_distanceToAim)
        {
            m_aimUiObject.SetActive(false);
        }
        
    }
}

