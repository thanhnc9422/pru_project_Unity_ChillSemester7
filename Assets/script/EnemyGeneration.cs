using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{

    [SerializeField]
    private float spawnRate = 1f;
    [SerializeField]
    private GameObject[] enemyPrefab;
    [SerializeField]
    private bool canSpawn = true;
    void Start()
    {
        StartCoroutine(Spawnner());
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private IEnumerator Spawnner() {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn) {
            yield return wait;  
                float spawnX = Random.Range(0, 50);
                int[] valuesToRandom = { -50, -50 };
                int spawnY = valuesToRandom[Random.Range(0, valuesToRandom.Length)];
                int rand = Random.Range(0, enemyPrefab.Length);
                Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
                GameObject enemyToSpawn = enemyPrefab[rand];
              Instantiate(enemyToSpawn, transform.position + spawnPosition, Quaternion.identity);
            }
        }
    

}