using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    GameObject m_bulletPrefab;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (m_bulletPrefab)
            {
                Instantiate(m_bulletPrefab, transform.position, transform.rotation * m_bulletPrefab.transform.rotation);
            } else
            {
                Debug.LogError("you forgot to put the bullet prefab in the weapon: " + gameObject.name);
            }
        }
    }
}
