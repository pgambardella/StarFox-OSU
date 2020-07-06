using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimManager : MonoBehaviour
{
    [SerializeField]
    GameObject m_AimUIPrefab;

    GameObject m_aimObj;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.onShowAimUI += OnShowAimUI;
        EventManager.instance.onHideAimUI += OnHideAimUI;
    }

    private void OnDestroy()
    {
        EventManager.instance.onShowAimUI -= OnShowAimUI;
        EventManager.instance.onHideAimUI -= OnHideAimUI;
    }

    void OnShowAimUI()
    {
        if (m_AimUIPrefab != null)
        {
            m_aimObj = Instantiate(m_AimUIPrefab);
            m_aimObj.transform.SetParent(gameObject.transform);
            EventManager.instance.AimUIActivated(m_aimObj);
        }
    }

    void OnHideAimUI()
    {
        if (m_aimObj != null)
        {
            Destroy(m_aimObj);
        }
    }
}
