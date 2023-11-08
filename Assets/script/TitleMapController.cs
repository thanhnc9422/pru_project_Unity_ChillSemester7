using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TitleMapController: MonoBehaviour
{


    private SpriteRenderer spriteRenderer;
    private TilemapCollider2D tc;

    void Start()
    {
    
        spriteRenderer = GetComponent<SpriteRenderer>();
        tc = GetComponent<TilemapCollider2D>();
        TilemapCollider2D tilemapCollider = GetComponent<TilemapCollider2D>();

    }
    void Update()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("player"))
            {
                tc.isTrigger = false;

            }
        }
    }
   
}
