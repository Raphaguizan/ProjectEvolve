using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DNA;

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

        private void ConfigureLife()
        {
            var obj = gameObject.GetComponentsInChildren<IDNAUser>();
            foreach (var item in obj)
            {
                item.ConfigureDNA(myDNA);
            }
        }
    }
}