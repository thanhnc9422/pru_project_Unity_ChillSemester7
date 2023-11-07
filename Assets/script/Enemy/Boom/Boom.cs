using UnityEngine;

namespace script.Enemy.Boom
{
    public class Boom : MonoBehaviour
    {
        [SerializeField] private float moveSpeed, lifeTime, damage;

        private Vector3 dir;
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
            if (other.gameObject.tag == "player")
            {
                PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
                thePlayerHealth.addDamage(damage);
                Destroy(gameObject);
            }
        }
        public void SetUp(BoomMachine.MachineDirection direction)
        {
            dir = direction == BoomMachine.MachineDirection.Left ? Vector3.left : Vector3.right;
        }
        private void Move()
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        
        
    }
}