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
        public GenderTypes gender;

        [Tag]
        public List<string> foodTags = new List<string>();
        [Tag]
        public string waterTag;

        public float lifeTime;
        public float decayMult;

        private int initialTimeFrame;

        public DNA(string specie, Sprite img, List<string> foods, string water, float decay)
        {
            foodTags = foods;
            waterTag = water;
            SpecieTag = specie;
            SpecieImage = img;

            decayMult = decay;

            Init();
        }
        public DNA(DNA copy)
        {
            foodTags = copy.foodTags;
            waterTag = copy.waterTag;
            SpecieTag = copy.SpecieTag;
            SpecieImage = copy.SpecieImage;
            lifeTime = copy.lifeTime;
            decayMult = copy.decayMult;
            Init();
        }

        public void Init()
        {
            gender = Random.value > .5f ? GenderTypes.MALE : GenderTypes.FEMALE;
            initialTimeFrame = Time.frameCount;
            MakeMutations();
            CalculateDecay();
        }

        public void SetLifeTime()
        {
            lifeTime = (Time.frameCount - initialTimeFrame) * Time.deltaTime;
        }

        public DNA ReproduceDNA(DNA other)
        {
            if (!other.SpecieTag.Equals(SpecieTag)) return null;
            DNA newDNA = LerpGenes(this, other);
            return newDNA;
        }

        private DNA LerpGenes(DNA dna1, DNA dna2)
        {
            return new DNA(SpecieTag, SpecieImage, foodTags, waterTag, decayMult);
            //DNA_Obj newDNA = ScriptableObject.CreateInstance<DNA_Obj>();
            //newDNA.Init(SpecieTag, SpecieImage);
            //return newDNA;
        }

        private void MakeMutations()
        {
            
        }

        private void CalculateDecay()
        {
            
        }

        public bool IsFood(string tag)
        {
            return foodTags.Contains(tag);
        }
    }
}