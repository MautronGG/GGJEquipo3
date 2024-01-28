using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float m_maxHealth = 10.0f;
    public float m_currentHealth = 10.0f;

    void Start()
    {
        m_currentHealth = m_maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_currentHealth -= 1;
        }
            

        if (m_currentHealth <= 0.0f)
        {
            m_currentHealth = 0.0f;
        }
    }
}
