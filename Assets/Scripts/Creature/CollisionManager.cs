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
            if (food != null )
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
                if (other.CoupleDesire > .5f)
                {
                    Debug.Log("Reproduction Between "+gameObject.name+" and "+ other.gameObject.name);
                    lifeManagement.Reproduce(other);
                }
            }
        }
    }
}
