using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using Unity.Mathematics;
using Game.DNA;

namespace Game.Creature
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : DNAUser
    {
        [Header("GENES")]
        [SerializeField]
        private float speed = 50f;

        [Header("SETUP")]
        [SerializeField]
        private Transform graphic;

        [SerializeField]
        private float rotationTime = 1f;

        [Header("DEBUG"),SerializeField, ReadOnly]
        private Vector3 _moveDirection;

        private Rigidbody2D myRB;
        private Tween currentTween;
        private Vector3 lookAtPos;

        private void Start()
        {
            myRB = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            myRB.velocity = speed * Time.fixedDeltaTime * _moveDirection;
        }

        public void Move(Vector2 dir)
        {
            _moveDirection = dir;
            if(dir != Vector2.zero)
                CalculateRotation();
        }
        private void CalculateRotation()
        {
            if(currentTween != null && !currentTween.IsActive()) currentTween.Complete();

            lookAtPos = transform.position + _moveDirection;
            Vector2 dir = (Vector2)lookAtPos - (Vector2)transform.position;
            float angle = math.degrees(math.atan2(dir.y, dir.x));

            currentTween = graphic.transform.DORotateQuaternion(Quaternion.AngleAxis(angle, Vector3.forward), rotationTime);
        }
        private void OnDisable()
        {
            currentTween.Complete();
            currentTween = null;
        }
    }
}
