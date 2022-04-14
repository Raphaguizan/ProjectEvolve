using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DNAStruct;

namespace Game.Creature
{

    public class DNAUser : MonoBehaviour, IDNAUser
    {
        public DNA myDNA;

        public void Configure(DNA dna)
        {
            myDNA = dna;
            Init();
        }

        public virtual void Init()
        {

        }
    }
}