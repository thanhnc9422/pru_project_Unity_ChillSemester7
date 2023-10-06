using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    int EnemyCount = 5;
    float duration = 0, screenWidth, screenHeight;
    int index = 0;
    List<GameObject> Enemies;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Camera.main.aspect;
        Enemies = new List<GameObject>();
        for (int i = 0; i < EnemyCount; i++)
        {
            GameObject gameObject = Instantiate(enemyPrefab);
            gameObject.SetActive(false);
            Enemies.Add(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (index >= EnemyCount) return;
        duration += Time.deltaTime;
        if (duration >= 1)
        {
            GameObject gameObject = GetFreeEnemy();
            if (gameObject != null)
            {
                gameObject.SetActive(true);
                // GameObject gameObject = Instantiate(enemyPrefab);
                float xPosition = Random.RandomRange(-screenWidth, screenHeight);
                float yPosition = Random.RandomRange(-screenWidth, screenHeight);
                index++;
                gameObject.transform.position = new Vector3(xPosition, yPosition, 0);
                duration = 0;
            }

        }
    }
    private GameObject GetFreeEnemy()
    {
        foreach (GameObject obj in Enemies)
        {
            if (gameObject.activeSelf)
            {
                return gameObject;
            }// active = true\

        }
        return null;
    }
}