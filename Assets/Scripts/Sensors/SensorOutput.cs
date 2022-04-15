using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Creature.Sensor
{
    [Serializable]
    public class SensorOutput
    {
        public GameObject nearFood;
        public Vector2 foodDirection;

        public GameObject nearWater;
        public Vector2 waterDirection;

        public GameObject nearOpositeSex;
        public Vector2 opositeSexDirection;

        public GameObject near;
        public Vector2 closiestDirection;

        public void ChangeFood(SensorsAnswer s)
        {
            if(nearFood == null || s.direction.magnitude < foodDirection.magnitude)
            {
                nearFood = s.obj;
                foodDirection = s.direction;
            }
        }
        public void ChangeWater(SensorsAnswer s)
        {
            if (nearWater == null || s.direction.magnitude < waterDirection.magnitude)
            {
                nearWater = s.obj;
                waterDirection = s.direction;
            }
        }
        public void ChangeOpositeSex(SensorsAnswer s)
        {
            if (nearOpositeSex == null || s.direction.magnitude < opositeSexDirection.magnitude)
            {
                nearOpositeSex = s.obj;
                opositeSexDirection = s.direction;
            }
        }
        public void ChangeNear(SensorsAnswer s)
        {
            if (near == null || s.direction.magnitude < closiestDirection.magnitude)
            {
                near = s.obj;
                closiestDirection = s.direction;
            }
        }

        public void ResetOutput()
        {
            nearFood = null;
            foodDirection = Vector2.zero;

            nearWater = null;
            waterDirection = Vector2.zero;

            nearOpositeSex = null;
            opositeSexDirection = Vector2.zero;

            near = null;
            closiestDirection = Vector2.zero;
        }
    }
}