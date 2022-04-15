using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DNAStruct;
using NaughtyAttributes;
using Game.CrowdManager;

namespace Game.Creature
{
    public class LifeManagement : DNAUser, IConsumable
    {
        [Header("Setup")]
        [SerializeField]
        private PoolingObj creaturePooling;
        [Header("GENES"), SerializeField]
        private float _coupleDesireSpeed = .05f;
        [SerializeField]
        private float _gestationTime = 4f;
        [SerializeField]
        private float _valueAsFood = .2f;

        [Header("STATS")]
        [SerializeField, ProgressBar("Hunger", 1f, EColor.Red)]
        private float _currentHunger = 1f;
        [SerializeField, ProgressBar("Thirst", 1f, EColor.Blue)]
        private float _currentThirst = 1f;

        [Space,SerializeField, ProgressBar("Couple Desire", 1f, EColor.Pink)]
        private float _coupleDesire = 0f;

        // properties
        public float CoupleDesire => _coupleDesire;
        public float Thirst => _currentThirst;
        public float Hunger => _currentHunger;
        public bool CoupleHasDesire => _coupleDesire > .5f;
        // private
        private float _currentDecay = 0;
        [SerializeField, ReadOnly]
        private bool _isPregnant = false;

        #region SETUP
        public override void Init()
        {
            creaturePooling = GetComponentInParent<PoolingObj>();

            _currentHunger = 1f;
            _currentThirst = 1f;
            _currentDecay = myDNA.DecayMult;
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }
        #endregion

        #region Updates
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
            if (_isPregnant) return;
            _coupleDesire += _coupleDesireSpeed * Time.deltaTime;
            if(_coupleDesire > 1f)
                _coupleDesire = 1f;
        }
        #endregion

        #region COMSUME
        public bool Consume(string tag, float value)
        {
            if (tag.Equals(myDNA.waterTag))
            {
                Drink(value);
                return true;
            }
            else if (myDNA.IsFood(tag))
            {
                Eat(value);
                return true;
            }
            return false;
        }

        private void Eat(float value)
        {
            if (_currentHunger >= .8f) return;
            _currentHunger += value;
            if(_currentHunger > 1f)
                _currentHunger = 1f;
        }

        private void Drink(float value)
        {
            if (_currentThirst >= .8f) return;
            _currentThirst += value;
            if(_currentThirst > 1f)
                _currentThirst = 1f;
        }
        #endregion

        #region REPRODUTION
        private void ResetDesire()
        {
            _coupleDesire = 0f;
        }
        public void Reproduce(LifeManagement other)
        {
            if (_isPregnant) return;
            if (myDNA.Gender != GenderTypes.FEMALE || myDNA.Gender == other.myDNA.Gender) return;

            ResetDesire();
            other.ResetDesire();
            
            DNA newLife = myDNA.ReproduceDNA(other.myDNA);
            StartCoroutine(Gestation(newLife));
        }
        IEnumerator Gestation(DNA childDNA)
        {
            _isPregnant = true;
            yield return new WaitForSeconds(_gestationTime);
            Childbirth(childDNA);
            _isPregnant = false;
        }

        private void Childbirth(DNA childDNA)
        {
            var childAux = creaturePooling.Add(transform.position);
            if(childAux != null)
                childAux.GetComponent<DNAManager>().StartNewLife(childDNA);
        }
        #endregion

        #region DEATH
        public void Die()
        {
            creaturePooling.Remove(gameObject);
        }

        public float GetValue()
        {
            return _valueAsFood;
        }
        #endregion
    }
}

