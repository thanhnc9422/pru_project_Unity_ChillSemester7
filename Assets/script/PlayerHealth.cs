using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    [SerializeField]
    private AudioClip hurtSound;
    [SerializeField]
    private AudioClip gameOverSound;
    public GameObject healTextPrefab;
    public GameObject damageTextPrefab;
    public float healTextDisplayTime = 1f;

    public Slider playerHealthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    void Update()
    {

    }


    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;
        AudioManager.Instance.PlayAudioOneShot(hurtSound);
        playerHealthSlider.value = currentHealth;

        GameObject healText = Instantiate(healTextPrefab, transform.position, Quaternion.identity);
        TextMeshPro textMesh = healText.GetComponent<TextMeshPro>();
        textMesh.text = "-" + damage.ToString();
        healText.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        StartCoroutine(DestroyHealText(healText));

        if (currentHealth <= 0)
            makeDead();
    }

    void makeDead()
    {
        // Không cần phần bloodEffect nữa
        gameObject.SetActive(false);
        AudioManager.Instance.PlayAudioOneShot(gameOverSound);
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        // Destroy(gameObject);
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        playerHealthSlider.value = currentHealth;

        GameObject healText = Instantiate(healTextPrefab, transform.position, Quaternion.identity);
        TextMeshPro textMesh = healText.GetComponent<TextMeshPro>();
        textMesh.text = "+" + amount.ToString();
        healText.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        StartCoroutine(DestroyHealText(healText));
    }

    private IEnumerator DestroyHealText(GameObject healText)
    {
        yield return new WaitForSeconds(healTextDisplayTime);
        Destroy(healText);
    }

}
