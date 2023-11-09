using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumPadController : MonoBehaviour
{
    private float bounce = 50f;

    private void OnCollisionEnter2D(Collision2D collision ) {
        if (collision.gameObject.CompareTag("player")) {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, bounce);
        }
      }
}
