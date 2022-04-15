using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Creature.Sensor
{
    [Serializable]
    public class SensorOutput
    {
        [SerializeField]
        private float _foodDistance;
        public Vector2 closiestFoodDirection;

        [Space, SerializeField]
        private float _waterDistance;
        public Vector2 closiestWaterDirection;

        [Space, SerializeField]
        private float _coupleDistance;
        public Vector2 closiestCoupleDirection;
        public bool closiestCoupleDesire;

        [Space, SerializeField]
        private float _closiestObjDistance;
        public string nearObjTag;
        public Vector2 closiestObjDirection;

        public void ChangeFood(Vector2 d)
        {
            if(closiestFoodDirection == Vector2.zero || d.magnitude < closiestFoodDirection.magnitude)
            {
                closiestFoodDirection = d;

                _foodDistance = closiestFoodDirection.magnitude;
            }
        }
        public void ChangeWater(Vector2 d)
        {
            if (closiestWaterDirection == Vector2.zero || d.magnitude < closiestWaterDirection.magnitude)
            {
                closiestWaterDirection = d;

                _waterDistance = closiestWaterDirection.magnitude;
            }
        }
        public void ChangeCouple(Vector2 d, bool desire)
        {
            if (closiestCoupleDirection == Vector2.zero || d.magnitude < closiestCoupleDirection.magnitude)
            {
                closiestCoupleDirection = d;

                _coupleDistance = closiestCoupleDirection.magnitude;
                closiestCoupleDesire = desire;
            }
        }
        public void ChangeNear(Vector2 d, string tag)
        {
            if (closiestObjDirection == Vector2.zero || d.magnitude < closiestObjDirection.magnitude)
            {
                closiestObjDirection = d;
                nearObjTag = tag;

                _closiestObjDistance = closiestObjDirection.magnitude;
            }
        }
        public void ResetOutput()
        {
            closiestFoodDirection = Vector2.zero;
            closiestWaterDirection = Vector2.zero;
            closiestCoupleDesire = false;
            closiestCoupleDirection = Vector2.zero;
            nearObjTag = null;
            closiestObjDirection = Vector2.zero;

            _foodDistance = -1;
            _waterDistance = -1;
            _coupleDistance = -1;
            _closiestObjDistance = -1;
        }
    }
}