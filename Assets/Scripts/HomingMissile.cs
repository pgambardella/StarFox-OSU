using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HomingMissile : MonoBehaviour
{
    [SerializeField]
    float m_speed;

    [SerializeField]
    float m_rotateSpeed;

    Transform m_target;
    Rigidbody m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            if (enemy.activeSelf)
            {
                m_target = enemy.transform;
                break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //set speed
        if (m_rb)
        {
            m_rb.velocity = transform.forward * m_speed;
        }

        if (m_target != null)
        {
            //set rotation
            var rocketTargetRotation = Quaternion.LookRotation(m_target.position - transform.position);
            m_rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rocketTargetRotation, m_rotateSpeed));
        } else
        {
            //Debug.LogError("No enemy as target of the bullet");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
