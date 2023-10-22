 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlink : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public float blinkDuration = 0.5f;
    private bool isBlinking = false;

    void Start()
    {
    }

    public void StartBlinking()
    {
        if (!isBlinking)
        {
            StartCoroutine(BlinkRoutine());
        }
    }

    private IEnumerator BlinkRoutine()
    {
        isBlinking = true;
        float elapsedTime = 0f;

        while (elapsedTime < blinkDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            Debug.Log("" + spriteRenderer.enabled);
            yield return new WaitForSeconds(0.1f); // Điều chỉnh tốc độ nhấp nháy tại đây
            elapsedTime += 0.1f;
        }

        spriteRenderer.enabled = true;
        isBlinking = false;
    }
}
