using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DNAs.Genes
{
    public class SpeedGene : Gene
    {
        [Space, SerializeField]
        private float value;

        public override object GetValue()
        {
            return value;
        }
        public override void Mutate()
        {
            value += Random.Range(-mutateRange, mutateRange);
        }
        public override void Reproduce(Gene other)
        {
            if (other.GetType().Equals(this.GetType()))
            {
                value = (value + (float)other.GetValue()) / 2;
            }
        }
        public override float Decay()
        {
            return 1;
        }
    }
}