using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Creature;
using Game.Util.RandomValue;
using NaughtyAttributes;

namespace Game.CrowdManager
{
    [RequireComponent(typeof(PoolingObj))]
    public class RandomSpawn : MonoBehaviour
    {
        [SerializeField, Limit(0, 100)]
        private RandomInt qty;
        [SerializeField, Limit(0,100), ShowIf("loop")]
        private RandomFloat delayTime;
        [Space, SerializeField]
        private bool loop = false; 


        private PoolingObj objs;
        private void OnValidate()
        {
            objs = GetComponent<PoolingObj>();
        }

        private void Start()
        {
            StartCoroutine(SpawnTime());
        }
        IEnumerator SpawnTime()
        {
            do
            {
                for (int i = 0; i < qty; i++)
                {
                    objs.Add();
                }
                yield return new WaitForSeconds(delayTime);
            }
            while (loop);
        }
    }
}