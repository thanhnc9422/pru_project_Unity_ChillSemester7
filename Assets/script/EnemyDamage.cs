using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float damage;
    float dameRate = 0.5f;
    public float pushBackForce;
    float nextDamage;

    void Start()
    {
        nextDamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.tag == "player" && nextDamage < Time.time)
    {
        PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
        thePlayerHealth.addDamage(damage);
        nextDamage = dameRate + Time.time;
    }
}


}
