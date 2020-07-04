using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float m_bulletSpeed;
    [SerializeField]
    float m_bulletLifeTime;

    Rigidbody m_rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        if (m_rigidBody)
        {
            m_rigidBody.velocity = transform.up * m_bulletSpeed;
        }
    }

    private void Update()
    {
        m_bulletLifeTime -= Time.deltaTime;
        if (m_bulletLifeTime < 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy Hit");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
