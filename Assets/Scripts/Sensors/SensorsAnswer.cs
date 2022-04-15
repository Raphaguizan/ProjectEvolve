using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Game.Creature.Sensor
{
    [Serializable]
    public class SensorsAnswer
    {
        public int id;
     
        public GameObject obj;
        public Vector2 direction;

        [HideInInspector]
        public Action update;

        public SensorsAnswer(int i)
        {
            id = i;
            obj = null;
            direction = Vector2.zero;
        }

        public void ResetAnswer()
        {
            obj = null;
            direction = Vector2.zero;
        }

        public void UpdateSensor(GameObject g, Vector2 d)
        {
            obj = g;
            direction = d;
            update?.Invoke();
        }
    }
}