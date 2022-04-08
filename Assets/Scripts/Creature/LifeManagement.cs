using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DNA;
using NaughtyAttributes;

namespace Game.Creature
{
    public class LifeManagement : DNAUser
    {
        [Header("GENES"), SerializeField]
        private float _coupleDesireSpeed = .05f;
        private float _gestationTime = 4f;
        [SerializeField, Tag]
        private List<string> _foodTags = new List<string>();

        [Space, SerializeField, Tag]
        private string _waterTag = "Water";

        [Header("STATS")]
        [SerializeField, ProgressBar("Hunger", 1f, EColor.Red)]
        private float _currentHunger = 1f;
        [SerializeField, ProgressBar("Thirst", 1f, EColor.Blue)]
        private float _currentThirst = 1f;

        [Space,SerializeField, ProgressBar("Couple Desire", 1f, EColor.Pink)]
        private float _coupleDesire = 0f;

        // properties
        public float CoupleDesire => _coupleDesire;
        // private
        private float _currentDecay = 0;

        protected override void Init()
        {
            _currentHunger = 1f;
            _currentThirst = 1f;
            _currentDecay = myDNA.DecayMult;
        }

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
            _coupleDesire += _coupleDesireSpeed * Time.deltaTime;
            if(_coupleDesire > 1f)
                _coupleDesire = 1f;
        }
        #endregion

        #region COMSUME
        public bool Consume(string tag, float value)
        {
            if (tag.Equals(_waterTag))
            {
                Drink(value);
                return true;
            }
            else if (_foodTags.Contains(tag))
            {
                Eat(value);
                return true;
            }
            return false;
        }

        private void Eat(float value)
        {
            _currentHunger += value;
            if(_currentHunger > 1f)
                _currentHunger = 1f;
        }

        private void Drink(float value)
        {
            _currentThirst += value;
            if(_currentThirst > 1f)
                _currentThirst = 1f;
        }
        #endregion

        #region REPRODUTION
        public void Reproduce(DNA_Obj other)
        {
            if (myDNA.Gender != GenderTypes.FEMALE || myDNA.Gender == other.Gender) return;
            DNA_Obj newLife = myDNA.ReproduceDNA(other);
            StartCoroutine(Gestation(newLife));
        }
        IEnumerator Gestation(DNA_Obj childDNA)
        {
            yield return new WaitForSeconds(_gestationTime);
            Childbirth(childDNA);
        }

        private void Childbirth(DNA_Obj childDNA)
        {
            GameObject childPrefab = Resources.Load("Prefabs/PFB_CREATURE") as GameObject;
            var childAux = Instantiate(childPrefab);
            childAux.GetComponent<BornSetup>().StartNewLife(childDNA);
        }
        #endregion


        #region DEATH
        public void Die()
        {
            gameObject.SetActive(false);
        }
        #endregion
    }
}

