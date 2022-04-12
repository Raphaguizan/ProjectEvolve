using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Game.DNA
{
    [CreateAssetMenu(menuName = "Game/DNA", fileName = "new DNA")]
    public class DNA_Obj : ScriptableObject
    {
        [Tag]
        public string SpecieTag;
        public Sprite SpecieImage;
        public GenderTypes Gender;

        [Tag]
        public List<string> _foodTags = new List<string>();

        public float LifeTime;
        public float DecayMult;

        public DNA_Obj(string specie, Sprite img)
        {
            Init(specie, img);
        }

        public void Init(string specie, Sprite img)
        {
            SpecieTag = specie;
            SpecieImage = img;

            Gender = Random.value > .5f ? GenderTypes.MALE : GenderTypes.FEMALE;
        }

        public DNA_Obj ReproduceDNA(DNA_Obj other)
        {
            if (!other.SpecieTag.Equals(SpecieTag)) return null;
            DNA_Obj newDNA = LerpGenes(this, other);

            newDNA.MakeMutations();
            newDNA.CalculateDecay();
            return newDNA;
        }

        private DNA_Obj LerpGenes(DNA_Obj dna1, DNA_Obj dna2)
        {
            return new DNA_Obj(SpecieTag, SpecieImage);
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