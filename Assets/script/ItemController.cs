using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    Rigidbody2D rd;
    // Start is called before the first frame update
    [SerializeField] List<Vector3> positionSpawn;
    Vector3 spawnPosition;
    [SerializeField]
    GameObject targetObject;
    PlayerHealth playerHealth;
    int totalScore;

  
    void Start()
    {
        totalScore = PlayerPrefs.GetInt("Point", 0);
        int randomIndex = Random.Range(0, positionSpawn.Count);
        spawnPosition = positionSpawn[randomIndex];
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            totalScore += 5;
            int randomIndex = Random.Range(0, positionSpawn.Count);
            spawnPosition = positionSpawn[randomIndex];
            gameObject.transform.position = spawnPosition;

            // Gọi hàm hồi máu trong PlayerController khi ăn item
            playerHealth.Heal(playerHealth.maxHealth * 0.1f);
        }
        PlayerPrefs.SetInt("Score", totalScore);

    }
}
