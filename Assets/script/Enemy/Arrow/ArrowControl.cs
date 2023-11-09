using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace script.Enemy.Arrow
{
    public class ArrowControl : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Arrow arrowPrefab;
        [SerializeField] private float duration, y, minx, maxX;
        private float currentDuration;
        private void Start()
        {
            currentDuration = duration;
        }

        private void Update()
        {
            currentDuration -= Time.deltaTime;
            if (currentDuration <= 0)
            {
                currentDuration = duration;
                SpawnArrow();
            }
        }

        private void SpawnArrow()
        {
            var arrow = Instantiate(arrowPrefab, transform);
            var randomX = Random.Range(minx, maxX);
            arrow.transform.position = new Vector3(player.position.x + randomX, transform.position.y, 0);
        }
        
    }
}