using Game.Bixo.Movement;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Game.Bixo.Sensor
{
    public class FollowBehaviour : Sensor
    {
        private Transform GetClosiest()
        {
            Transform resp = null;
            float minDist = SensorRadius;
            foreach (Transform t in listOfTargets)
            {
                float currentDist = Vector2.Distance(transform.position, t.position);
                if (currentDist < minDist)
                {
                    minDist = currentDist;
                    resp = t;
                }
            }
            currentTarget = resp;
            return resp;
        }

        protected override void FixedUpdate()
        {
            if (listOfTargets.Count > 0 && !InDanger)
            {
                mov.SetTarget(GetClosiest());
            }
        }
    }
}
