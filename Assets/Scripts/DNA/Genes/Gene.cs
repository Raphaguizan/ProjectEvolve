using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.DNAs.Genes
{
    [Serializable]
    public class Gene : IGene
    {
        [HideInInspector]
        public string name = "teste";
        public GeneType type;

        [SerializeField]
        protected string debugValue;
        protected GeneValue value;

        [Space, SerializeField]
        protected float mutateRange;
        [SerializeField]
        protected float mutationChance = .2f;

        //public Gene(GeneType t, GeneValue value, float mutate = 1, float chance = .2f)
        //{
        //    this.type = t;
        //    this.value = value;
        //    mutateRange = mutate;
        //    mutationChance = chance;
        //}

        public virtual T GetValue<T>() => value.GetValue<T>();
        public virtual void Mutate() 
        { 
            if (Random.value > mutationChance) return; 
        }
        public virtual void Reproduce(IGene other) { }
        public virtual float Decay() => 1;
    }
}