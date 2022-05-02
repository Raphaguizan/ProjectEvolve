using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DNAs.Genes
{
    public class GeneColor : Gene
    {
        public GeneColor(GeneType t, Color value, float mutate = .1f, float chance = .2f)
        {
            name = this.GetType().Name;
            type = t;
            this.value = new GeneValue(value, typeof(Color));
            debugValue = value.ToString();
            mutateRange = mutate;
            mutationChance = chance;
        }
        public override void Mutate()
        {
            base.Mutate();

            float auxR = Random.Range(-mutateRange, mutateRange);
            float auxG = Random.Range(-mutateRange, mutateRange);
            float auxB = Random.Range(-mutateRange, mutateRange);

            Color oldColor = GetValue<Color>();
            Color newColor = new Color(auxR + oldColor.r, auxG + oldColor.g, auxB + oldColor.b);

            // test min
            if(newColor.r < 0 )newColor.r = 0;
            if(newColor.g < 0 )newColor.g = 0;
            if(newColor.b < 0 )newColor.b = 0;
            // test Max
            if (newColor.r > 1) newColor.r = 1;
            if (newColor.g > 1) newColor.g = 1;
            if (newColor.b > 1) newColor.b = 1;

            value.SetValue<Color>(newColor);
        }

        public override void Reproduce(IGene other)
        {
            if (other.GetType().Equals(GetType()))
            {
                Color oldColor = GetValue<Color>();
                Color newColor = Color.Lerp(oldColor, other.GetValue<Color>(), .5f);

                value.SetValue<Color>(newColor);
            }
        }
    }
}