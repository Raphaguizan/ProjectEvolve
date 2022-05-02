using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DNAs;

namespace Game.Creature
{

    public class DNAUser : MonoBehaviour, IDNAUser
    {
        [HideInInspector]
        public DNA myDNA;
        protected GeneManager myGenes;

        public void Configure(DNA dna, GeneManager genes)
        {
            myDNA = dna;
            myGenes = genes;
            gameObject.tag = myDNA.SpecieTag;
            Init();
        }

        public virtual void Init()
        {

        }
    }
}