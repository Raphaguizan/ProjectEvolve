using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DNAs.Genes
{
    public interface IGene
    {
        public object GetValue();
        public void Mutate();
        public void Reproduce(Gene other);
        public float Decay();
    }
}