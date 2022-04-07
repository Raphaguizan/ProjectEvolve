using System.Collections;
using System.Collections.Generic;
using Game.Bixo.Movement;
using Game.Bixo.Sensor;
using NaughtyAttributes;
using UnityEngine;

namespace Game.Bixo.Sensor
{
    [RequireComponent(typeof(MovementIA))]
    public class ColisionDetection : MonoBehaviour
    {
        [Header("Tags"), SerializeField, Tag]
        private string foodTag = "Food";
        [SerializeField, Tag]
        private string wallTag = "Wall";


        private MovementIA mov = null;
        private void Start()
        {
            mov = GetComponent<MovementIA>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(foodTag))
            {
                collision.gameObject.SetActive(false);
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(wallTag))
            {
                mov.SetTarget(null);
            }
        }
    }
}
