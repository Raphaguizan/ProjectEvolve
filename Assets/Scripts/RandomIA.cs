using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Game.Util;

namespace Game.Creature
{
    [RequireComponent(typeof(Movement))]
    public class RandomIA : MonoBehaviour
    {
        [Header("GENES"),SerializeField]
        private Vector2 randomTime = Vector2.zero;

        [Header("SETUP"), SerializeField, Tag]
        private string wallTag = "Wall";

        [Header("DEBUG"),SerializeField, ReadOnly]
        private Vector2 _currentDirection;

        private Movement mov;

        private void Start()
        {
            mov = GetComponent<Movement>();
            RandomizeVector();
            StartCoroutine(RandomTime());
        }

        IEnumerator RandomTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(randomTime.x, randomTime.y));
                RandomizeVector();
            }
        }

        private void Update()
        {
             mov.Move(_currentDirection);
        }

        private void RandomizeVector()
        {
            _currentDirection = new Vector3().Randomize();
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(wallTag))
            {
                RandomizeVector();
            }
        }
    }
}