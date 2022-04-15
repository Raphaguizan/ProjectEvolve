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
        public List<string> foodTags = new List<string>();
        [Tag]
        public string waterTag;

        public float LifeTime;
        public float DecayMult;

        public DNA(string specie, Sprite img, List<string> foods, string water)
        {
            foodTags = foods;
            waterTag = water;
            SpecieTag = specie;
            SpecieImage = img;

            Init();
        }

        public void Init()
        {
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
            return new DNA(SpecieTag, SpecieImage, foodTags, waterTag);
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

        public bool IsFood(string tag)
        {
            return foodTags.Contains(tag);
        }
    }
}