using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RetryButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExistButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
