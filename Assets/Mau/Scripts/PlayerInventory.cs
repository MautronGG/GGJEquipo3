using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
  public List <GameObject> m_memeCardsArray;
  public List <GameObject> m_accesoriesArray;
  // Start is called before the first frame update

  public bool AddToArray(List<GameObject> list, GameObject item)
  {
    if(list.Count < 5)
    {
      Debug.Log("Entró para Add");
      list.Add(item);
      return true;
    }
    else
    {
      return false;
    }
    
  }
  public bool RemoveFromArray(List<GameObject> list, GameObject item)
  {
    if (list.Count > 0)
    {
      list.Remove(item);
      return true;
    }
    else
    {
      return false;
    }
  }
}
