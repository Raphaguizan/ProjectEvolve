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
        [Tag]
        public string tag;
        public float distance;

        public SensorsAnswer(int i)
        {
            id = i;
            tag = null;
            distance = -1;
        }

        public void ResetAnswer()
        {
            tag = null;
            distance = -1;
        }

        public void UpdateSensor(string t, float d)
        {
            tag = t;
            distance = d;
        }
    }
}