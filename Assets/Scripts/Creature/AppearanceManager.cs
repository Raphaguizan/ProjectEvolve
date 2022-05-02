using System.Collections;
using System.Collections.Generic;
using Game.DNAs;
using UnityEngine;
using NaughtyAttributes;

namespace Game.Creature
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class AppearanceManager : DNAUser
    {
        [Space, SerializeField]
        private GameObject _tieObj;

        [Space, SerializeField, ReadOnly]
        private SpriteRenderer spRend;

        //GENES
        [SerializeField]
        private Color color;
        [SerializeField]
        private float size = 1f;

        private void OnValidate()
        {
            spRend = GetComponent<SpriteRenderer>();
        }

        public override void Init()
        {
            spRend.sprite = myDNA.SpecieImage;
            spRend.color = myGenes.color;
            size = myGenes.size;
            transform.localScale = Vector3.one * size;

            _tieObj.SetActive(myDNA.gender == GenderTypes.FEMALE);
        }
    }
}