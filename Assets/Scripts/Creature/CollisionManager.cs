using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Creature
{
    [RequireComponent(typeof(LifeManagement))]
    public class CollisionManager : MonoBehaviour
    {
        private LifeManagement lifeManagement;

        private void Awake()
        {
            lifeManagement = GetComponent<LifeManagement>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var food = collision.gameObject.GetComponent<IConsumable>();
            if (food != null && !(food is Water))
            {
                if (lifeManagement.Consume(collision.transform.tag, food.GetValue()))
                {
                    food.Die();
                    return;
                }
            }
            var other = collision.gameObject.GetComponent<LifeManagement>();
            if (other != null)
            {
                if (other.CoupleDesire > .5f && other.CompareTag(gameObject.tag))
                {
                    lifeManagement.Reproduce(other);
                }
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            var food = collision.gameObject.GetComponent<IConsumable>();
            if (food != null && food is Water)
            {
                lifeManagement.Consume(collision.transform.tag, food.GetValue());
            }
        }
    }
}
