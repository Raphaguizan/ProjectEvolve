using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Game.Util;
using Game.DNAs;
using Game.Creature.Sensor;

namespace Game.Creature
{
    [RequireComponent(typeof(Movement))]
    public class RandomIA : DNAUser
    {
        [Header("GENES"),SerializeField]
        private Vector2 randomTime = Vector2.zero;

        [Header("SETUP"), SerializeField, Tag]
        private string wallTag = "Wall";

        [Header("DEBUG"),SerializeField, ReadOnly]
        private Vector2 _currentDirection;
        [SerializeField, ReadOnly]
        private string _following;

        [Space, SerializeField]
        private Sensors sensor;
        [SerializeField]
        private LifeManagement lifeManagement;

        private Movement mov;
        private bool chasing = false;

        private void Start()
        {
            mov = GetComponent<Movement>(); 
        }

        private void OnEnable()
        {
            RandomizeVector();
            StartCoroutine(RandomTime());
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }

        IEnumerator RandomTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(randomTime.x, randomTime.y));
                yield return new WaitWhile(() => chasing == true);
                RandomizeVector();
            }
        }

        private void Update()
        {
            ReadSensor();
            mov.Move(_currentDirection);
        }

        private void RandomizeVector()
        {
            _currentDirection = new Vector3().Randomize();
        }

        private void ReadSensor()
        {
            if (sensor.output.closiestCoupleDirection != Vector2.zero && lifeManagement.CoupleDesire > .5f && sensor.output.closiestCoupleDesire)
            {
                chasing = true;
                _currentDirection = sensor.output.closiestCoupleDirection.normalized;
                _following = "Couple";
            }

            if (sensor.output.closiestWaterDirection != Vector2.zero && lifeManagement.Thirst < .7f)
            {
                chasing = true;
                _currentDirection = sensor.output.closiestWaterDirection.normalized;
                _following = "Water";
            }

            if (sensor.output.closiestFoodDirection != Vector2.zero && lifeManagement.Hunger < .7f)
            {
                chasing = true;
                _currentDirection = sensor.output.closiestFoodDirection.normalized;
                _following = "Food";
            }
            else
            {
                chasing = false;
                _following = "None";
            }
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