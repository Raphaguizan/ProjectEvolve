using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DNA;
using Game.Util;

namespace Game.Creature.Sensor
{
    public class Sensors : DNAUser
    {
        [Header("GENES")]
        public float distance = 1f;
        public int sensorNum = 1;
        [Space, Header("ANSWERS"), SerializeField]
        private List<SensorsAnswer> _answers;

        public List<SensorsAnswer> SensAnswers => _answers;

        protected override void Init()
        {
            InitializeSensor();
        }

        private void InitializeSensor()
        {
            _answers = new List<SensorsAnswer>();
            for (int i = 0; i < sensorNum; i++)
            {
                _answers.Add(new SensorsAnswer(i));
            }
        }

        private void Update()
        {
            CastSensor();
        }

        private void CastSensor()
        {
            float angle = 180f / (sensorNum+1);
            Vector2 newDir = transform.right;
            newDir = newDir.Rotate(90);
            for (int i = 0; i < sensorNum; i++)
            {
                newDir = newDir.Rotate(-angle);
                CastRay(i, newDir.normalized);
            }
        }

        private void CastRay(int id, Vector3 dir)
        {
            var hit = Physics2D.Raycast(transform.position, dir, distance);
            if (hit)
                _answers[id].UpdateSensor(hit.collider.tag, hit.distance);
            else
                _answers[id].ResetAnswer();

            Debug.DrawLine(transform.position, transform.position + ((Vector3)dir * distance), Color.red);
        }
    }
}

