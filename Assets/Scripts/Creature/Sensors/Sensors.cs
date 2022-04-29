using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DNAStruct;
using Game.Util;

namespace Game.Creature.Sensor
{
    public class Sensors : DNAUser
    {
        [Header("GENES")]
        public float distance = 1f;
        public int sensorNum = 1;

        private SensorOutput _outputAux;
        
        public SensorOutput output;

        private void Awake()
        {
            output = new SensorOutput();
            _outputAux = new SensorOutput();
            output.ResetOutput();
        }

        private void Update()
        {
            CastSensor();
        }

        private void CastSensor()
        {
            _outputAux.ResetOutput();

            float angle = 180f / (sensorNum+1);
            Vector2 newDir = transform.right;
            newDir = newDir.Rotate(90);
            for (int i = 0; i < sensorNum; i++)
            {
                newDir = newDir.Rotate(-angle);
                CastRay(i, newDir.normalized);
            }

            output = _outputAux;
        }

        private void CastRay(int id, Vector3 dir)
        {
            var hit = Physics2D.Raycast(transform.position, dir, distance);
            if (hit)
                VerifySensors(hit.collider.gameObject);

            Debug.DrawLine(transform.position, transform.position + ((Vector3)dir * distance), Color.red);
        }

        private void VerifySensors(GameObject hit)
        {
            if (hit == null) return;
            Vector2 pos = hit.transform.position - transform.position; 

            if (hit.CompareTag(myDNA.SpecieTag))
            {
                var other = hit.GetComponentInParent<LifeManagement>();
                if (other.myDNA.gender != myDNA.gender)
                {
                    _outputAux.ChangeCouple(pos, other.CoupleHasDesire);
                }
            }
            else if (hit.CompareTag(myDNA.waterTag))
            {
                _outputAux.ChangeWater(pos);
            }
            else if (myDNA.IsFood(hit.tag))
            {
                _outputAux.ChangeFood(pos);
            }
            _outputAux.ChangeNear(pos, hit.tag);
        }
    }
}

