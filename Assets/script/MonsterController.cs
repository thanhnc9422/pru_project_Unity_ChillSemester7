using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    Transform target;
    GameObject targetObject;
    float speed = 6f;
    Rigidbody2D rd;
    float xSpeed, ySpeed;
    public float damage;
    [SerializeField] private Animator animator;
    private SpriteRenderer spriteRenderer;
    PlayerBlink playerBlink;
    // Start is called before the first frame update
   
    public float moveSpeed = 3.0f;
    private float died = 1f;


    void Start()
    {
        targetObject = GameObject.Find("Square");
        target = targetObject.transform;
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
                if ((transform.position.y < 0 && (int)transform.position.y - (int)targetObject.transform.position.y > 0) ||
                    (transform.position.y > 0 && (int)transform.position.y - (int)targetObject.transform.position.y < 0))
                {
                    // Thực hiện các hành động khác tại đây (như animation, di chuyển, vv.) 
                    // Nếu không muốn trừ máu, không gọi addDamage ở đây.
                    animator.SetFloat("died", Mathf.Abs(died));
                    Rigidbody2D rb = targetObject.GetComponent<Rigidbody2D>();
                    rb.velocity = new Vector2(rb.velocity.x, 21.0f);
                    Invoke("YourFunction", 0.5f);
                }
                else
                {
                    // Trừ máu và hiển thị văn bản trừ máu
                    PlayerHealth thePlayerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                    thePlayerHealth.addDamage(damage);
                    GameObject.FindGameObjectWithTag("player").GetComponent<PlayerBlink>().StartBlinking();
                }
            }
        }
    }

    void YourFunction()
    {
        
        gameObject.SetActive(false);
    }
}
