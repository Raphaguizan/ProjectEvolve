using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.CrowdManager;

public class ChartPredator : MonoBehaviour
{
    public PoolingObj pool;

    [DebugGUIGraph(group: 1, r: 1, g: 0, b: 0, min: 0, max: 100)]
    public float predator => pool.Count;

    [DebugGUIPrint]
    public float predatorAverage;

    private void Update()
    {
        if(predatorAverage != predator)
            predatorAverage = (predatorAverage + predator) / 2;
    }
}
