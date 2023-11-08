using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{

    [SerializeField] GameObject targetObject;
    [SerializeField] int limitLeft;
    [SerializeField] int limitRight;
    Rigidbody2D rd;
    float currentX;
    public float moveSpeed = 3.0f; // Tốc độ di chuyển
    private int moveDirection = 1; // 
    // Start is called before the first frame update

    void Start()
    {
    }
    void Update()
    {
        
        Vector3 movement = new Vector3(moveSpeed * moveDirection * Time.deltaTime, 0, 0);
        int currentX = Mathf.RoundToInt(transform.position.x);
        if ( currentX == limitLeft)
        {
            moveDirection = 1;
        }
        if (currentX == limitRight) {
            moveDirection = -1;
        }
        transform.Translate(movement);
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("player"))
        {
            targetObject.gameObject.transform.position = new Vector3(-2f, 7f, 0f);
        }
    }*/
}
