using System;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Game.DNAs.Genes;

using Random = UnityEngine.Random;

namespace Game.DNAs
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

        public List<Gene> genes;

        public float lifeTime;
        public float decayMult;

        private int initialTimeFrame;

        public DNA(string specie, Sprite img, List<string> foods, string water, List<Gene> gen, float decay)
        {
            foodTags = foods;
            waterTag = water;
            SpecieTag = specie;
            SpecieImage = img;
            
            genes = gen;

            decayMult = decay;

            Init();
        }
        public DNA(DNA copy)
        {
            foodTags = copy.foodTags;
            waterTag = copy.waterTag;
            SpecieTag = copy.SpecieTag;
            SpecieImage = copy.SpecieImage;

            genes = copy.genes;

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
            DNA newDNA = new DNA(dna1);
            foreach(Gene gen in newDNA.genes)
            {
                gen.Reproduce(dna2.GetGeneOfType(gen.type));
            }
            //DNA_Obj newDNA = ScriptableObject.CreateInstance<DNA_Obj>();
            //newDNA.Init(SpecieTag, SpecieImage);
            return newDNA;
        }

        private void MakeMutations()
        {
            foreach (Gene gen in genes)
            {
                gen.Mutate();
            }
        }

        private void CalculateDecay()
        {
            foreach (Gene gen in genes)
            {
                decayMult *= gen.Decay();
            }
        }

        public bool IsFood(string tag)
        {
            return foodTags.Contains(tag);
        }

        public Gene GetGeneOfType(GeneType gen)
        {
            return genes.Find(g => g.type.Equals(gen));
        }
        public void SaveGene(Gene newGene)
        {
            Gene geneAux = genes.Find(g => g.type.Equals(newGene.type));
            if (geneAux != null)
            {
                int auxIndex = genes.FindIndex(g => g.Equals(geneAux));
                genes[auxIndex] = newGene;
            }
            else
            {
                genes.Add(newGene);
            }
        }
    }
}