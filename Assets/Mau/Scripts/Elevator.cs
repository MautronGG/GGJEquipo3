using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
  public bool m_elevatorON = false;
  bool m_elevatorUP = false;
  float m_elevatorProgress = 0f;
  float m_elevatorSpeed;
  Vector3 m_elevatorDirection;
  Vector3 m_elevatorStart;
  Vector3 m_elevatorEnd;
  [SerializeField] float m_elevatorTime = 0f;
  [SerializeField] Vector3 m_initialPosition;
  [SerializeField] Vector3 m_finalPosition;
  [SerializeField] float m_elevatorDistance;
  [SerializeField] float time = 0f;
  [SerializeField] float proxiimityOutset = 1;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (m_elevatorON)
    {
      time += Time.deltaTime;
      var positionY = Vector3.zero;

      m_elevatorDirection = m_elevatorEnd - transform.position;
      m_elevatorDistance = m_elevatorDirection.magnitude;
      m_elevatorProgress = Mathf.Max(m_elevatorDistance, 0);
      if (!(m_elevatorDistance < proxiimityOutset))
      {
        var advance = m_elevatorDirection.normalized * Time.deltaTime * m_elevatorSpeed;
        if (advance.magnitude > m_elevatorDistance)
        {
          advance.Normalize();
          advance *= m_elevatorDistance;
        }
        transform.position += advance;
      }
      else
      {
        m_elevatorON = false;
        if(m_elevatorUP)
        {
          m_elevatorUP = false;
        }
        else
        {
          m_elevatorUP = true;
        }
      }

      //m_elevatorProgress = Mathf.Max(m_elevatorProgress, 0);
      //float tR = m_elevatorProgress / m_elevatorTime;
      //if (!m_elevatorUP)
      //{
      //  //positionY = Mathf.Lerp(m_initialPosition.y, m_elevatorDistance.y, tR);
      //  positionY = Vector3.Lerp(m_initialPosition, m_finalPosition, tR);
      //  if (tR >= 1.0f)
      //  {
      //    m_elevatorON = false;
      //    m_elevatorUP = true;
      //    m_elevatorProgress = 0;
      //  }
      //}
      //else
      //{
      //  //positionY = Mathf.Lerp(m_elevatorDistance.y, m_initialPosition.y, tR);
      //  positionY = Vector3.Lerp(m_finalPosition, m_initialPosition, tR);
      //  if (tR == 1.0f)
      //  {
      //    m_elevatorON = false;
      //    m_elevatorUP = false;
      //    m_elevatorProgress = 0;
      //  }
      //}
      //transform.localPosition += positionY * Time.deltaTime;
    }
  }
  private void OnCollisionEnter(Collision collision)
  {
    if (collision.transform.tag == "Player")
    {
      StartElevator(collision.gameObject, this.gameObject.transform, true);
    }
  }
  private void OnCollisionExit(Collision collision)
  {
    if (collision.transform.tag == "Player")
    {
      StartElevator(collision.gameObject, null, false);
    }
  }
  public void StartElevator(GameObject player, Transform parent, bool state)
  {
    time = 0f;
    player.transform.SetParent(parent);
    if (m_elevatorUP)
    {
      m_elevatorStart = m_finalPosition;
      m_elevatorEnd = m_initialPosition;
    }
    else
    {
      m_elevatorStart = m_initialPosition;
      m_elevatorEnd = m_finalPosition;
    }
    m_elevatorDirection = m_elevatorEnd - m_elevatorStart;
    m_elevatorDistance = m_elevatorDirection.magnitude;
    m_elevatorSpeed = m_elevatorDistance / m_elevatorTime;
    m_elevatorON = state;
  }
}
