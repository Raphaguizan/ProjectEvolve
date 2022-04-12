using System.Collections;
using System.Collections.Generic;
using Game.DNA;
using UnityEngine;

namespace Game.Creature
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class AppearanceManager : DNAUser
    {
        [Header("GENES")]
        [SerializeField]
        private Color color;
        [SerializeField]
        private float size = 1f;
        private SpriteRenderer spRend;
        protected override void Init()
        {
            base.Init();
            spRend = GetComponent<SpriteRenderer>();
            SetColor();
            SetSize();
        }

        private void SetColor()
        {
            spRend.color = color;
        }

        private void SetSize()
        {
            transform.localScale = Vector3.one * size;
        }
    }
}