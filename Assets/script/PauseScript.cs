using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public void Pause()
    {

        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void Home()
    {
        PlayerPrefs.SetFloat("Time", 0);
        SceneManager.LoadScene("Menu");

    }
}
