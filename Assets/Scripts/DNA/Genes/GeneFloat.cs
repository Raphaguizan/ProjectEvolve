using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Game.DNAs.Genes
{
    [Serializable]
    public class GeneFloat : Gene
    {

        public GeneFloat(GeneType t, float value, float mutate = .5f, float chance = .2f)
        {
            name = this.GetType().Name;
            type = t;
            this.value = new GeneValue(value, typeof(float));
            debugValue = value.ToString();
            mutateRange = mutate;
            mutationChance = chance;
        }
        public override void Mutate()
        {
            base.Mutate();

            float aux = Random.Range(-mutateRange, mutateRange);
            // Test min
            if (aux < .1f) aux = .1f;
            value.SetValue<float>(GetValue<float>()+ aux);
        }

        public override void Reproduce(IGene other)
        {
            if (other.GetType().Equals(GetType())){
                float resp;
                resp = (other.GetValue<float>()/GetValue<float>())/2;
                value.SetValue<float>(resp);
            }
        }
    }
}