using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Creature;
using Game.Util.RandomValue;
using Game.Util;
using NaughtyAttributes;

namespace Game.CrowdManager
{
    public class PoolingObj : MonoBehaviour
    {
        [SerializeField]
        private int MAX;
        [SerializeField]
        private List<GameObject> objectPool;

        [Header("Random Position")]
        [SerializeField]
        private RandomFloat x;
        [SerializeField]
        private RandomFloat y;

        [Header("DEBUG"), ReadOnly]
        public float Count = 0;


        public void Remove(GameObject obj)
        {
            Count--;
            obj.SetActive(false);
        }

        public void Add()
        {
            GameObject newObj = Add(RandomizePos());
        }

        public GameObject Add(Vector3 pos)
        {
            if(Count >= MAX)return null;
            Count++;
            GameObject resp = null;
            foreach (Transform trans in transform)
            {
                if (!trans.gameObject.activeInHierarchy)
                {
                    resp = trans.gameObject;
                }
            }
            
            if(resp == null)
                resp = Instantiate(objectPool.GetRandom<GameObject>(), transform);

            resp.transform.position = pos;
            resp.SetActive(true);
            return resp;
        }

        private Vector2 RandomizePos()
        {
            return new Vector2(x, y);
        }
    }
}