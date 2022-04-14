using System;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

using Random = UnityEngine.Random;

namespace Game.DNAStruct
{
    [Serializable]
    public class DNA 
    {
        [Tag]
        public string SpecieTag;
        public Sprite SpecieImage;
        public GenderTypes Gender;

        [Tag]
        public List<string> _foodTags = new List<string>();

        public float LifeTime;
        public float DecayMult;

        public DNA(string specie, Sprite img)
        {
            Init(specie, img);
        }

        public void Init(string specie, Sprite img)
        {
            SpecieTag = specie;
            SpecieImage = img;

            Gender = Random.value > .5f ? GenderTypes.MALE : GenderTypes.FEMALE;
            MakeMutations();
            CalculateDecay();
        }

        public DNA ReproduceDNA(DNA other)
        {
            if (!other.SpecieTag.Equals(SpecieTag)) return null;
            DNA newDNA = LerpGenes(this, other);
            return newDNA;
        }

        private DNA LerpGenes(DNA dna1, DNA dna2)
        {
            return new DNA(SpecieTag, SpecieImage);
            //DNA_Obj newDNA = ScriptableObject.CreateInstance<DNA_Obj>();
            //newDNA.Init(SpecieTag, SpecieImage);
            //return newDNA;
        }

        private void MakeMutations()
        {
            
        }

        private void CalculateDecay()
        {
            DecayMult = .02f;
        }
    }
}