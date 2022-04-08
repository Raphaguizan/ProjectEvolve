using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Game.Creature
{
    public class LifeManagement : MonoBehaviour
    {
        [Header("GENES"), SerializeField]
        private float _coupleDesireSpeed = .05f;

        [Header("STATS")]
        [SerializeField, ProgressBar("Hunger", 1f, EColor.Red)]
        private float _currentHunger = 1f;
        [SerializeField, ProgressBar("Thirst", 1f, EColor.Blue)]
        private float _currentThirst = 1f;

        [Space,SerializeField, ProgressBar("Couple Desire", 1f, EColor.Pink)]
        private float _coupleDesire = 0f;


        // private
        private float _currentDecay = 0;

        private void OnEnable()
        {
            Init();
        }

        private void Init()
        {
            CalculateDecay();
            _currentHunger = 1f;
            _currentThirst = 1f;
        }
        // make Genes Decay calc
        private void CalculateDecay()
        {
            _currentDecay = .02f;
        }

        private void Update()
        {
            Decay();
        }

        private void Decay()
        {
            _currentHunger -= _currentDecay * Time.deltaTime;
            _currentThirst -= _currentDecay * Time.deltaTime;

            if (_currentHunger <= 0 || _currentThirst <= 0)
                Die();

            IncreaseDesire();
        }

        private void IncreaseDesire()
        {
            _coupleDesire += _coupleDesireSpeed * Time.deltaTime;
            if(_coupleDesire > 1f)
                _coupleDesire = 1f;
        }

        public void Eat(float value)
        {
            _currentHunger += value;
            if(_currentHunger > 1f)
                _currentHunger = 1f;
        }

        public void Drink(float value)
        {
            _currentThirst += value;
            if(_currentThirst > 1f)
                _currentThirst = 1f;
        }

        public void Die()
        {
            gameObject.SetActive(false);
        }
    }
}

