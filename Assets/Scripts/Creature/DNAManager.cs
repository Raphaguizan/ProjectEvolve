using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DNAs;
using Game.DNAs.Genes;
using NaughtyAttributes;

namespace Game.Creature
{
    public class DNAManager : MonoBehaviour
    {
        public BestDNA BestDNA;
        public GeneManager geneManager;

        [SerializeField]
        private DNA myDNA;

        public void StartNewLife()
        {
            //Get Best DNA
            myDNA = new DNA(BestDNA.GetBestDNA());
            ConfigureLife();
        }
        public void StartNewLife(DNA dna)
        {
            myDNA = dna;
            ConfigureLife();
        }

        private void OnEnable()
        {
            StartNewLife();
        }

        [Button]
        private void ConfigureLife()
        {
            gameObject.name = myDNA.gender+" "+ myDNA.SpecieTag+" "+gameObject.GetInstanceID();
            geneManager.InitializeGenes(myDNA);
            var obj = gameObject.GetComponentsInChildren<IDNAUser>();
            foreach (var item in obj)
            {
                 item.Configure(myDNA, geneManager);
            }
        }

        public void SaveDNA(DNA dna)
        {
            BestDNA.SaveBestDNA(myDNA);
        }
    }
}