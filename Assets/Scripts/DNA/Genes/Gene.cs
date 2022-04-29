using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Game.DNAs.Genes
{
    [Serializable]
    public class Gene : IGene
    {
        [SerializeField]
        protected float mutateRange;

        public virtual object GetValue() => null;
        public virtual void Mutate() { }
        public virtual void Reproduce(Gene other) { }
        public virtual float Decay() => -1;
    }
}