using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    if (other.transform.tag == "Player")
    {
      other.transform.position = other.GetComponent<PlayerVariables>().m_initialPosition;
    }
  }
}
