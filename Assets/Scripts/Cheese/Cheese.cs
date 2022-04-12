using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour, IConsumable
{
    [SerializeField]
    private float _feedValue = .3f;
    public void Die()
    {
        gameObject.SetActive(false);
    }

    public float GetValue()
    {
        return _feedValue;
    }
}
