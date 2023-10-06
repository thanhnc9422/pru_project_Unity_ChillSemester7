using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    GameObject targetObject;
    float speed = 0.8f;
    Rigidbody2D rd;
    // Start is called before the first frame update

    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
        rd.velocity = new Vector2(0.8f, rd.velocity.y);
    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            targetObject.gameObject.transform.position = new Vector3(24.3f, -8.8f, 0f);
        }
        else {
            speed = -speed;
            Debug.Log(speed);
            Debug.Log("run1");
            rd.velocity = new Vector2(speed, rd.velocity.y);
        }
    }
}
