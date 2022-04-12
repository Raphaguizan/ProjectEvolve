using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DNA
{
    public class DNAUser : MonoBehaviour, IDNAUser
    {
        public DNA_Obj myDNA;
        public void ConfigureDNA(DNA_Obj dna)
        {
            myDNA = dna;
            Init();
        }

        protected virtual void Init() { }
    }
}
