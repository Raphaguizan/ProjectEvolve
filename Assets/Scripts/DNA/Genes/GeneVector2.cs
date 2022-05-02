using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DNAs.Genes
{
    public class GeneVector2 : Gene
    {

        public GeneVector2(GeneType t, Vector2 value, float mutate = 1, float chance = .2f)
        {
            name = this.GetType().Name;
            type = t;
            this.value = new GeneValue(value, typeof(Vector2));
            debugValue = value.ToString();
            mutateRange = mutate;
            mutationChance = chance;
        }
        public override void Mutate()
        {
            base.Mutate();

            float auxX = Random.Range(-mutateRange, mutateRange);
            float auxY = Random.Range(-mutateRange, mutateRange);

            Vector2 oldVector = GetValue<Vector2>();
            Vector2 newVector = new Vector2(auxX + oldVector.x, auxY + oldVector.y);

            // test min
            if (newVector.x < 0) newVector.x = 0;
            if (newVector.y < 0) newVector.y = 0;

            value.SetValue<Vector2>(newVector);
        }

        public override void Reproduce(IGene other)
        {
            if (other.GetType().Equals(GetType()))
            {
                Vector2 oldVector = GetValue<Vector2>();
                Vector2 otherVector = other.GetValue<Vector2>();
                Vector2 newVector = new Vector2((otherVector.x + oldVector.x)/2, (otherVector.y + oldVector.y) / 2);

                value.SetValue<Vector2>(newVector);
            }
        }
    }
}