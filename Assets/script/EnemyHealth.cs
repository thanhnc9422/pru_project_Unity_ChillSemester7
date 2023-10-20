using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamge(float damge)
    {
        currentHealth -= damge;
        if (currentHealth <= 0)
            makeDead();
    }

    void makeDead()
    {
        Destroy(gameObject);
    }
}
