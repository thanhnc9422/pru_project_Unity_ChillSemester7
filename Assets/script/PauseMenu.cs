using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Go to Home Scene");
    }
    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
    public void GoHome()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Go Home Scene");
    }

}
