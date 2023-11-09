using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
public class PortalController : MonoBehaviour
{
    [SerializeField] public float deplaySecond;
	[SerializeField] public string nameScene;


    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
           
            collision.gameObject.SetActive(false);
            ModeSeletet();
        }
      

    }

    private void ModeSeletet()
    {
        StartCoroutine(LoadAfterDelay());
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(deplaySecond);
        SceneManager.LoadScene(nameScene);
    }

  
}

