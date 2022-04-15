using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.CrowdManager;

public class ChartCreatures : MonoBehaviour
{
    public PoolingObj pool;

    [DebugGUIGraph(group: 1, r: 1, g: 1, b: 1, max: 50)]
    public float rats => pool.Count;

    [DebugGUIPrint]
    public float ratsAverage;

    private void Update()
    {
        if(ratsAverage != rats)
            ratsAverage = (ratsAverage + rats) / 2;
    }
}
