using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
  float time = 0f;
  bool gameOn = false;
  bool combat = false;
  bool onCombat = false;
  [SerializeField] int exploreTime;
  [SerializeField] int cardIntro;
  [SerializeField] int outro;
  PlayerInput[] inputs;
  [SerializeField] TextMeshProUGUI timer;
  // Start is called before the first frame update
  void Start()
  {
    inputs = FindObjectsOfType<PlayerInput>();
    foreach (PlayerInput inputi in inputs)
    {
      inputi.currentActionMap.Disable();
    }
    Cursor.lockState = CursorLockMode.Locked;
    //ActionMaps Disable
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
      time -= Time.deltaTime;
      timer.text = time.ToString();
      if (time <= 0)
      {
        gameOn = false;
        combat = true;
        time = 0f;
        //ActionMaps Disable
        foreach (PlayerInput inputi in inputs)
        {
          inputi.currentActionMap.Disable();
        }
        Cursor.lockState = CursorLockMode.None;
      }
    }
    else if(!gameOn && !combat)
    {
      time += Time.deltaTime;
      if (time >= cardIntro)
      {
        gameOn = true;
        time = exploreTime;
        //Main card dissapear from UI
        foreach (PlayerInput inputi in inputs)
        {
          inputi.currentActionMap.Enable();
        }
      }
    }
    else if(combat)
    {
      time += Time.deltaTime;
      if(time >= outro)
      {
        SceneManager.LoadScene(3);
      }
    }
  }
}
