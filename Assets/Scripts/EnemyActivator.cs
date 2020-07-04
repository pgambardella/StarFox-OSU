using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    public GameObject m_enemyObj;
    private void OnTriggerEnter(Collider other)
    {
        if (m_enemyObj != null)
        {
            if (m_enemyObj.activeSelf)
            {
                Debug.LogError("the enemy " + m_enemyObj.name + " was already activated");
            }
            m_enemyObj.SetActive(true);
        } else
        {
            Debug.LogError("you have to associate an Enemy to the EnemyActivator component of " + gameObject.name);
        }
    }
}
