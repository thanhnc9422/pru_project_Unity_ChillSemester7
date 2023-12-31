using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float verforce = 2.0f, horforce = 1.0f;
    [SerializeField]
    private Animator animator;
    Vector2 direction;
    Rigidbody2D rigit;
    private bool canJump = true;
    private SpriteRenderer spriteRenderer;


    float xSpeed, ySpped;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigit = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(canJump);
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        xSpeed = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("speed", Mathf.Abs(xSpeed));

        
        direction = new Vector2(xSpeed * 6f, rigit.velocity.y);
        //rigit.AddForce(direction * horforce);
        rigit.velocity = direction;
        //if (Input.GetKey(KeyCode.Space))
        //    rigit.AddForce(Vector2.up * verforce);
        if (xSpeed < 0)
        {
            spriteRenderer.flipX = true; // Quay đầu về hướng trái
        }
        else if (xSpeed > 0)
        {
            spriteRenderer.flipX = false; // Không quay
        }

    }
    private void Jump()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, 5.0f);
        canJump = false; // Ngăn sprite nhảy liên tục
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Khi sprite va chạm với mặt đất, cho phép nhảy lại
     
            canJump = true;
    }

}
