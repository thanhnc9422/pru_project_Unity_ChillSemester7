using System;
using UnityEngine;

namespace script.Enemy.Arrow
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private float moveSpeed, lifeTime,accelerationTime, velocityRate, damage;
        
        

        private void Update()
        {
            Move();
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "player" )
            {
                PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
                thePlayerHealth.addDamage(damage);
                Destroy(gameObject);
            }
        }
        private void Move()
        {
            var speed = lifeTime > accelerationTime ? moveSpeed : moveSpeed * velocityRate;
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}