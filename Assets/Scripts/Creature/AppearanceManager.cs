using System.Collections;
using System.Collections.Generic;
using Game.DNA;
using UnityEngine;
using NaughtyAttributes;

namespace Game.Creature
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class AppearanceManager : DNAUser
    {
        [Header("GENES")]
        [SerializeField]
        private Sprite sprite;
        [SerializeField]
        private Color color;
        [SerializeField]
        private float size = 1f;
        [Space, SerializeField, ReadOnly]
        private SpriteRenderer spRend;

        private void OnValidate()
        {
            spRend = GetComponent<SpriteRenderer>();
        }

        protected override void Init()
        {
            base.Init();
            spRend.sprite = sprite;
            spRend.color = color;
            transform.localScale = Vector3.one * size;
        }
    }
}