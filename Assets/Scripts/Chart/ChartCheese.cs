using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.CrowdManager;

public class ChartCheese : MonoBehaviour
{
    public PoolingObj pool;

    [DebugGUIGraph(group: 1, r: 1, g: 1, b: 0, max: 50)]
    public float cheese => pool.Count;

    [DebugGUIPrint]
    public float CheeseAverage;

    private void Update()
    {
        if(cheese != CheeseAverage)
            CheeseAverage = (CheeseAverage + cheese)/2;
    }
}
