using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DNAStruct;

namespace Game.Creature.Sensor
{
    [RequireComponent(typeof(Sensors))]
    public class SensorReader : DNAUser
    {
        public Sensors _sensor;

        public SensorOutput output;

        private SensorOutput _outputAux;
        private bool _initialized = false;

        private void Awake()
        {
            _sensor = GetComponent<Sensors>(); 
            output = new SensorOutput();
            _outputAux = new SensorOutput();
        }
        private void OnEnable()
        {
            foreach (var sensor in _sensor.SensAnswers)
            {
                sensor.update += VerifySensors; 
            }
        }
        private void OnDisable()
        {
            foreach (var sensor in _sensor.SensAnswers)
            {
                sensor.update -= VerifySensors;
            }
            _initialized = false;
        }

        public override void Init()
        {
            _initialized = true;
        }

        private void VerifySensors()
        {
            if (!_initialized) return;

            _outputAux.ResetOutput();
            foreach(var sensor in _sensor.SensAnswers)
            {
                if (sensor.obj == null) continue;

                else if (sensor.obj.CompareTag(myDNA.SpecieTag))
                {
                    Debug.Log("AKI");
                    if (sensor.obj.GetComponent<DNAUser>().myDNA.Gender != myDNA.Gender)
                    {
                        Debug.Log("ENTREi");
                        _outputAux.ChangeOpositeSex(sensor);
                    }
                }
                else if (sensor.obj.CompareTag(myDNA.waterTag))
                {
                    _outputAux.ChangeWater(sensor);
                }
                else if (myDNA.IsFood(sensor.obj.tag))
                {
                    _outputAux.ChangeFood(sensor);
                }
                 _outputAux.ChangeNear(sensor);
                
            }
            output = _outputAux;
        }

    }
}