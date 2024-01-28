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
        SceneManager.LoadScene("Assets/Dani/Scenes/City_SearchScene.unity");
    }


    public void BackToMenu()
    {
        Debug.Log("BackToMenu");
        SceneManager.LoadScene("Assets/Aramis/Scenes/Menu.unity");
    }


    public void Credits()
    {   
        Debug.Log("CreditsGame");
        SceneManager.LoadScene("Assets/Aramis/Scenes/Creditos.unity");
    }

    public void ExitGame()
    {
        Debug.Log("EndGame");
        Application.Quit();
    }
}
