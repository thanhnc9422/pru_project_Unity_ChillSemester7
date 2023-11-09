using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    Vector3 Offset = new Vector3(0, (float)5, 0);
    // Start is cal
    // led before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 camPosition = Player.transform.position;
        camPosition.z = transform.position.z;
        transform.position = camPosition + Offset;
    }
}