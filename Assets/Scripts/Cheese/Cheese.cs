using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.CrowdManager;

public class Cheese : MonoBehaviour, IConsumable
{
    [SerializeField]
    private float _feedValue = .3f;

    private PoolingObj _pool;
    private void Awake()
    {
        _pool = GetComponentInParent<PoolingObj>();
    }

    public void Die()
    {
        _pool.Remove(gameObject);
    }

    public float GetValue()
    {
        return _feedValue;
    }
}
