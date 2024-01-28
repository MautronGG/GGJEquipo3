using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
  float time = 0f;
  bool gameOn = false;
  bool combat = false;
  bool onCombat = false;
  [SerializeField] int exploreTime;
  [SerializeField] int cardIntro;
  [SerializeField] int outro;
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
      if (time >= exploreTime)
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
      if (time >= cardIntro)
      {
        gameOn = true;
        time = 0f;
        //Main card dissapear from UI
      }
    }
    else if(combat)
    {
      time += Time.deltaTime;
      if(time >= outro)
      {
        //Activar canvas de combate
        combat = false;
        onCombat = true;
        time = 0f;
      }
    }
  }
}
