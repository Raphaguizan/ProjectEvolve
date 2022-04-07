using Game.Bixo.Movement;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Game.Bixo.Sensor
{
    [RequireComponent(typeof(MovementIA))]
    public class Sensor : MonoBehaviour
    {
        public GameObject colliderSensor;


        [Header("Tags"), SerializeField, Tag]
        protected string ObjTag = "Food";

        protected MovementIA mov = null;

        [Space, ReadOnly, SerializeField]
        protected Transform currentTarget = null;
        [SerializeField]
        //protected HashSet<Transform> listOfTargets = new HashSet<Transform>();
        protected List<Transform> listOfTargets = new List<Transform>();

        protected bool InDanger => mov.InDanger;

        protected float SensorRadius
        {
            get => colliderSensor.transform.localScale.x;
            set => colliderSensor.transform.localScale = Vector3.one * value;
        }

        private void Start()
        {
            mov = GetComponent<MovementIA>();
        }


        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(ObjTag))
            {
                listOfTargets.Add(collision.transform);
            }
        }

        protected virtual void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(ObjTag))
            {
                listOfTargets.Remove(collision.transform);
            }
        }

        protected virtual void FixedUpdate() { }
    }
}
