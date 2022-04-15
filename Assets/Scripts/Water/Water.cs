using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour, IConsumable
{
    [SerializeField]
    private float _drinkValue = .1f;
    public void Die()
    {
    }

    public float GetValue()
    {
        return _drinkValue * Time.deltaTime;
    }
}
