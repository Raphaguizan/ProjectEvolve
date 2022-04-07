using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Game.Bixo.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementIA : MonoBehaviour
    {
        [SerializeField]
        private float speed = 4f;
        [SerializeField]
        private Vector2 randomTime = Vector2.zero;

        [Space, Header("Debug")]
        [ SerializeField, ReadOnly]
        private Vector2 direction = Vector2.zero;
        // teste
        [ReadOnly]
        private bool isRandomizing = true;
        [Space, ReadOnly]
        public bool InDanger = false;


        private Rigidbody2D myRB = null;

        private void Start()
        {
            myRB = GetComponent<Rigidbody2D>();
            StartCoroutine(RandomizeByTime());
        }

        private void FixedUpdate()
        {
            myRB.velocity = direction.normalized * speed * Time.fixedDeltaTime;
        }

        public void SetDirection(Vector2 dir)
        {
            direction = dir;
        }

        public void SetTarget(Transform trans)
        {
            if (trans == null) 
                SetTarget(Vector3.zero);
            else 
                SetTarget(trans.position - transform.position);
        }

        public void SetTarget(Vector3 vec)
        {
            if (vec == Vector3.zero)
            {
                RandomizeDirection();
                return;
            }

            isRandomizing = false;
            SetDirection(vec);
        }

        private void RandomizeDirection()
        {
            isRandomizing = true;
            Vector2 randomizedVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            SetDirection(randomizedVector);
        }

        IEnumerator RandomizeByTime()
        {
            while (true)
            {
                if(isRandomizing)RandomizeDirection();
                yield return new WaitForSeconds(Random.Range(randomTime.x, randomTime.y));
            }
        }
    }
}

