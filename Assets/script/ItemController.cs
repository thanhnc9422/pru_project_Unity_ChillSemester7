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
    private List<Vector3> positionSpawn;
    Vector3 spawnPosition;
    [SerializeField]
    GameObject targetObject;
    void Start()
    {
        positionSpawn = new List<Vector3>();
        positionSpawn.Add(new Vector3(-19, 13.4f, 0));
        positionSpawn.Add(new Vector3(-29, 7.4f, 0));
        positionSpawn.Add(new Vector3(-29, 19.3f, 0));
        positionSpawn.Add(new Vector3(-19, 25.4f, 0));
        positionSpawn.Add(new Vector3(0, 19.6f, 0));
        positionSpawn.Add(new Vector3(0, 7.6f, 0));
        positionSpawn.Add(new Vector3(18, 13.4f, 0));
        positionSpawn.Add(new Vector3(26, 19.4f, 0));
        positionSpawn.Add(new Vector3(18, 25.6f, 0));
        positionSpawn.Add(new Vector3(27, 7.5f, 0));
        int randomIndex = Random.Range(0, positionSpawn.Count);
        spawnPosition = positionSpawn[randomIndex];
    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            int randomIndex = Random.Range(0, positionSpawn.Count);
            spawnPosition = positionSpawn[randomIndex];
          gameObject.transform.position = spawnPosition;
        }
    }
}
