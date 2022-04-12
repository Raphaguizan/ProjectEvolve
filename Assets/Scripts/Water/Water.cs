using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour, IConsumable
{
    [SerializeField]
    private float _drinkValue = .5f;
    public void Die()
    {
    }

    public float GetValue()
    {
        return _drinkValue;
    }
}
