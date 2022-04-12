using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Creature;
using Game.Util.RandomValue;

namespace Game.CrowdManager
{
    public class PoolingObj : MonoBehaviour
    {
        [SerializeField]
        private GameObject objectPool;

        [Header("Random Position")]
        [SerializeField]
        private RandomFloat x;
        [SerializeField]
        private RandomFloat y;

        public void Remove(GameObject obj)
        {
            obj.SetActive(false);
        }

        public GameObject Add()
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
                resp = Instantiate(objectPool, transform);

            resp.SetActive(true);
            resp.transform.position = RandomizePos();
            return resp;
        }

        private Vector2 RandomizePos()
        {
            return new Vector2(x, y);
        }
    }
}