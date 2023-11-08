using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class SpawnMonster : MonoBehaviour
{
    [SerializeField]
    GameObject Enemies;
    public Vector2 spawnArea;
    public GameObject spawnedObject;
    public float timeBetweenSpawns = 1.0f;
    // Thời gian đếm giây ban đầu (5 giây)

    void Start()
    {

        StartCoroutine(ExecuteAfterDelay(5.0f)); // Gọi coroutine và chờ 1 giây
    }

    // Update is called once per frame
    IEnumerator ExecuteAfterDelay(float delay)
    {
        for (int i = 0; i < 100; i++)
        {
            float spawnX = Random.Range(0, 50);
            int[] valuesToRandom = { -50, 50};
            int spawnY = valuesToRandom[Random.Range(0, valuesToRandom.Length)];

            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
            GameObject spawnedObject = Instantiate(Enemies, transform.position + spawnPosition, Quaternion.identity);

            // Gán số điểm cho từng vật thể



            // Gắn số điểm cho vật thể
            //spawnedObject.GetComponent<PlayerController>().scoreValue = score;
            yield return new WaitForSeconds(delay); // Chờ 1 giây
        }



        // Thực hiện code sau 1 giây
        Debug.Log("Code đã được thực hiện sau 1 giây");
    }
    void Update()
    {


    }


}
