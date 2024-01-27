using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
  public List <GameObject> lights;
 
  private void OnTriggerEnter(Collider other)
  {
    if(other.transform.tag == "Player")
    {
      foreach (GameObject light in lights)
      {
        light.SetActive(true);
      }
    }
  }
  private void OnTriggerExit(Collider other)
  {
    if(other.transform.tag == "Player")
    {
      foreach (GameObject light in lights)
      {
        light.SetActive(false);
      }
    }
  }
}
