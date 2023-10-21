using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth;
    float currentHealth;

    public GameObject bloodEffect;
    // Start is called before the first frame update

    public Slider playerHealthSlider;
    void Start()
    {
        currentHealth = maxHealth;

        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;

        if (currentHealth <= 0)
            makeDead();
    }

    void makeDead()
    {
        Instantiate(bloodEffect, transform.position, transform.rotation);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        // ??m b?o máu không v??t quá giá tr? t?i ?a
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        // C?p nh?t UI ho?c hi?u ?ng h?i máu n?u c?n
    }
}
