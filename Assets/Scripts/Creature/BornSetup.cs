using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DNA;
using NaughtyAttributes;

namespace Game.Creature
{
    public class BornSetup : MonoBehaviour
    {
        public DNA_Obj myDNA;

        public void StartNewLife(DNA_Obj dna)
        {
            ConfigureLife();
        }

        private void OnEnable()
        {
            ConfigureLife();
        }

        [Button]
        private void ConfigureLife()
        {
            gameObject.name = myDNA.Gender+" "+myDNA.SpecieTag+" "+gameObject.GetInstanceID();
            var obj = gameObject.GetComponentsInChildren<IDNAUser>();
            foreach (var item in obj)
            {
                item.ConfigureDNA(myDNA);
            }
        }
    }
}