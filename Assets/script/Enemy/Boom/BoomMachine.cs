using UnityEngine;

namespace script.Enemy.Boom
{
    public class BoomMachine : MonoBehaviour
    {
        public enum MachineDirection
        {
            Right, Left
        }
        [SerializeField] private Transform firePoint;
        [SerializeField] private Boom boomPrefab;
        [SerializeField] private float duration;
        [SerializeField] private MachineDirection direction;
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
                Fire();
            }
        }

        private void Fire()
        {
            var boom = Instantiate(boomPrefab, transform);
            boom.SetUp(direction);
            boom.transform.position = firePoint.position;
        }
    }
}