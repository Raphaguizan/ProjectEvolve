using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Game.DNAs
{
    [CreateAssetMenu(menuName ="Game/BestDNA", fileName ="BestDNA")]
    public class BestDNA : ScriptableObject
    {
        [SerializeField]
        private DNA best;
        public DNA GetBestDNA()
        {
            return new DNA(best);
        }

        public void SaveBestDNA(DNA dna)
        {
            dna.SetLifeTime();
            if(dna.lifeTime > best.lifeTime)
            {
                best = new DNA(dna);
            }
        }
    }
}