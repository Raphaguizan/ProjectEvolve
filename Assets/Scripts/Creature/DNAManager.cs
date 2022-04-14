using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DNAStruct;
using NaughtyAttributes;

namespace Game.Creature
{
    public class DNAManager : MonoBehaviour
    {

        [Space]
        public DNA BestDNA;


        private DNA myDNA;

        public void StartNewLife()
        {
            //Get Best DNA
            myDNA = new DNA(BestDNA.SpecieTag, BestDNA.SpecieImage);
            ConfigureLife();
        }
        public void StartNewLife(DNA dna)
        {
            myDNA = dna;
            ConfigureLife();
        }

        private void OnEnable()
        {
            StartNewLife();
        }

        [Button]
        private void ConfigureLife()
        {
            gameObject.name = myDNA.Gender+" "+ myDNA.SpecieTag+" "+gameObject.GetInstanceID();
            var obj = gameObject.GetComponentsInChildren<IDNAUser>();
            foreach (var item in obj)
            {
                 item.Configure(myDNA);
            }
        }
    }
}