using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
  float time = 0f;
  bool gameOn = false;
  bool combat = false;
  bool onCombat = false;
  // Start is called before the first frame update
  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
  }

  // Update is called once per frame
  void Update()
  {
    if(onCombat)
    {
      //Smth Smth
    }
    else if(gameOn)
    {
      time += Time.deltaTime;
      if (time >= 180)
      {
        gameOn = false;
        combat = true;
        time = 0f;
        //Desactivar ActionMap
        Cursor.lockState = CursorLockMode.None;
      }
    }
    else if(!gameOn && !combat)
    {
      time += Time.deltaTime;
      if (time >= 20)
      {
        gameOn = true;
        time = 0f;
      }
    }
    else if(combat)
    {
      time += Time.deltaTime;
      if(time >= 20)
      {
        //Activar canvas de combate
        combat = false;
        onCombat = true;
        time = 0f;
      }
    }
  }
}
