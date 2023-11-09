using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class ScorpController : MonoBehaviour
{

    [SerializeField] GameObject targetObject;
    [SerializeField] int limitLeft;
    [SerializeField] int limitRight;
    Rigidbody2D rd;
    private SpriteRenderer spriteRenderer;
    float currentX;
    public float moveSpeed = 3.0f; // Tốc độ di chuyển
    private int moveDirection = 1; // 
    // Start is called before the first frame update

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rd = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        Vector3 movement = new Vector3(moveSpeed * moveDirection * Time.deltaTime, 0, 0);
        int currentX = Mathf.RoundToInt(transform.position.x);
        if (currentX == limitLeft)
        {
            moveDirection = 1;
            spriteRenderer.flipX = false;

        }
        if (currentX == limitRight)
        {
            moveDirection = -1;
            spriteRenderer.flipX = true;
        }
        transform.Translate(movement);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("player"))
        {
            rd.velocity = new Vector2(rd.velocity.x, 21.0f);
        }
    }
}