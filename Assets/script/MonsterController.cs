using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{

    [SerializeField]
    GameObject targetObject;
    float speed = 6f;
    Rigidbody2D rd;
    float xSpeed, ySpeed;
    [SerializeField]
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    public Transform target;
    public float moveSpeed = 3.0f;
    private float died = 1f;


    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float x = transform.position.x;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            if (x - transform.position.x < 0)
            {
                spriteRenderer.flipX = false; // Quay đầu về hướng trái


            }
            else
            {
                spriteRenderer.flipX = true; // Quay đầu về hướng trái

            }
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget < 1.0f)
            {
                // Ngừng di chuyển hoặc thực hiện hành động khác tại đây.
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("player"))
            {
                Debug.Log((int)transform.position.y + " " + (int)targetObject.transform.position.y);
                if ((transform.position.y <0 && (int)transform.position.y - (int)targetObject.transform.position.y > 0) || (transform.position.y>0 && (int)transform.position.y - (int)targetObject.transform.position.y < 0))
                {
                    animator.SetFloat("died", Mathf.Abs(died));

                    Rigidbody2D rb = targetObject.GetComponent<Rigidbody2D>();         
                    rb.velocity = new Vector2(rb.velocity.x, 18.0f);
                    Invoke("YourFunction", 1f);
                   
                }
                else {
                    targetObject.gameObject.transform.position = new Vector3(-2f, 7f, 0f);
                }
                //else 
                //{
                //    animator.SetInteger("isDied", 1);
                //    gameObject.SetActive(false);

                //}
                //else
                //{
                //    speed = -speed;
                //    Debug.Log(speed);
                //    Debug.Log("run1");
                //    rd.velocity = new Vector2(speed, rd.velocity.y);
                //}
            }
        }
            }
    void YourFunction()
    {
        
        gameObject.SetActive(false);
    }
}
