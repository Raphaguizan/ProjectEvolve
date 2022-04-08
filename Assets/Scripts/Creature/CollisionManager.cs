using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Creature
{
    [RequireComponent(typeof(LifeManagement))]
    public class CollisionManager : MonoBehaviour
    {
        LifeManagement lifeManagement;

        private void Start()
        {
            lifeManagement = GetComponent<LifeManagement>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var other = collision.gameObject.GetComponent<LifeManagement>();
            if (other.CoupleDesire >.5f)
            {
                lifeManagement.Reproduce(other.myDNA);
            }
        }
    }
}
