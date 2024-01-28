using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;


public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("StartGame");
        SceneManager.LoadScene(2);
    }


    public void BackToMenu()
    {
        Debug.Log("BackToMenu");
        SceneManager.LoadScene(0);
    }


    public void Credits()
    {   
        Debug.Log("CreditsGame");
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("EndGame");
        Application.Quit();
    }
}
