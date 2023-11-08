using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayUIController : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] TextMeshProUGUI txtTime;
    [SerializeField] TextMeshProUGUI txtScore;
    public static float totalTime = 0;
    public int totalScore = 0;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        txtTime.text = "Time: " + totalTime.ToString();
        txtScore.text = totalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int k = PlayerPrefs.GetInt("Score", -1);
        if (k != -1)
        {
            totalScore = k;
            if (totalScore < 0)
            {
                Time.timeScale = 0;
            }
            txtScore.text = "Score: " + totalScore.ToString();
        }
        time += Time.deltaTime;
        if (time > 1)
        {
            totalTime += 1;
            time = 0;
            txtTime.text = "Time: " + totalTime.ToString();
            PlayerPrefs.SetFloat("Time", totalTime);
        }
    }
    
}
