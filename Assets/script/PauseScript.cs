using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] public GameObject PausePanel;
    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home()
    {
        PlayerPrefs.SetFloat("Time", 0);
        Application.Quit();
        SceneManager.LoadScene("Menu");

    }
}
