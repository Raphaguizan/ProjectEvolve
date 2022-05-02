using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DNAs.Genes
{
    public interface IGene
    {
        public T GetValue<T>();
        public void Mutate();
        public void Reproduce(IGene other);
        public float Decay();
    }
}