using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace script.Enemy.Boom
{
    public class BoomMachineControl : MonoBehaviour
    {
        [SerializeField] private List<BoomMachine> boomMachine;
        [SerializeField] private float duration, maxMachine;
        private float currentMachine, currentDuration;

        private void Start()
        {
            currentDuration = duration;
        }

        private void Update()
        {
            if (currentMachine < maxMachine)
            {
                currentDuration -= Time.deltaTime;
                if (currentDuration <= 0)
                {
                    RandomMachine();
                }
            };
        }

        private void RandomMachine()
        {
            var boomMcn = boomMachine[Random.Range(0, boomMachine.Count)];
            boomMachine.Remove(boomMcn);
            boomMcn.gameObject.SetActive(true);
            currentMachine += 1;
            currentDuration = duration;
        }
    }
}