using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DNAs.Genes
{
    public class GeneInt : Gene
    {

        public GeneInt(GeneType t, int value, float mutate = 1, float chance = .2f)
        {
            name = this.GetType().Name;
            type = t;
            this.value = new GeneValue(value, typeof(int));
            debugValue = value.ToString();
            mutateRange = mutate;
            mutationChance = chance;
        }
        public override void Mutate()
        {
            base.Mutate();

            int aux = Random.Range(-((int)mutateRange), (int)mutateRange);
            // Teste min
            if(aux < 1) aux = 1;
            value.SetValue<int>(GetValue<int>() + aux);
        }

        public override void Reproduce(IGene other)
        {
            if (other.GetType().Equals(GetType()))
            {
                float resp;
                resp = (other.GetValue<float>() / GetValue<float>()) / 2;
                value.SetValue<int>(Mathf.RoundToInt(resp));
            }
        }
    }
}