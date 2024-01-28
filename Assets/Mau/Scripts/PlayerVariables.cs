using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
  public Vector3 m_initialPosition;
  private void Start()
  {
    m_initialPosition = transform.position;
  }
}
