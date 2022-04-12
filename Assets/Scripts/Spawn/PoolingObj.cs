using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Creature;
using Game.Util.RandomValue;
using Game.Util;

namespace Game.CrowdManager
{
    public class PoolingObj : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> objectPool;

        [Header("Random Position")]
        [SerializeField]
        private RandomFloat x;
        [SerializeField]
        private RandomFloat y;

        public void Remove(GameObject obj)
        {
            obj.SetActive(false);
        }

        public void Add()
        {
            GameObject newObj = Add(RandomizePos());
        }

        public GameObject Add(Vector3 pos)
        {
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