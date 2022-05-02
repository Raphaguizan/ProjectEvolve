using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DNAs.Genes;
using Game.DNAs;

public class GeneManager : MonoBehaviour
{
    [Space, Header("GENES")]
    public float desire;
    public float gestationTime;
    public float valueAsFood;
    public float speed;
    public float size;
    public float sensorDist;
    public int sensorNum;
    public Vector2 IARandomTime;
    public Color color;

    public void InitializeGenes(DNA myDNA)
    {
        Gene desireG = myDNA.GetGeneOfType(GeneType.DESIRE);
        if (desireG == null)
            myDNA.SaveGene(new GeneFloat(GeneType.DESIRE, desire));
        else
            desire = desireG.GetValue<float>();


        Gene gestationG = myDNA.GetGeneOfType(GeneType.GESTATION_TIME);
        if (gestationG == null)
            myDNA.SaveGene(new GeneFloat(GeneType.GESTATION_TIME, gestationTime));
        else
            gestationTime = gestationG.GetValue<float>();


        Gene foodValueG = myDNA.GetGeneOfType(GeneType.FOOD_VALUE);
        if (foodValueG == null)
            myDNA.SaveGene(new GeneFloat(GeneType.FOOD_VALUE, valueAsFood));
        else
            valueAsFood = foodValueG.GetValue<float>();


        Gene speedG = myDNA.GetGeneOfType(GeneType.SPEED);
        if (speedG == null)
            myDNA.SaveGene(new GeneFloat(GeneType.SPEED, speed));
        else
            speed = speedG.GetValue<float>();


        Gene sizeG = myDNA.GetGeneOfType(GeneType.SIZE);
        if (sizeG == null)
            myDNA.SaveGene(new GeneFloat(GeneType.SIZE, size));
        else
            size = sizeG.GetValue<float>();


        Gene sensorDistG = myDNA.GetGeneOfType(GeneType.SENSOR_DIST);
        if (sensorDistG == null)
            myDNA.SaveGene(new GeneFloat(GeneType.SENSOR_DIST, sensorDist));
        else
            sensorDist = sensorDistG.GetValue<float>();


        Gene sensorNumG = myDNA.GetGeneOfType(GeneType.SENSOR_NUM);
        if (sensorNumG == null)
            myDNA.SaveGene(new GeneInt(GeneType.SENSOR_NUM, sensorNum));
        else
            sensorNum = sensorNumG.GetValue<int>();


        Gene IARandomTimeG = myDNA.GetGeneOfType(GeneType.IA_RANDOM_TIME);
        if (IARandomTimeG == null)
            myDNA.SaveGene(new GeneVector2(GeneType.IA_RANDOM_TIME, IARandomTime));
        else
            IARandomTime = IARandomTimeG.GetValue<Vector2>();


        Gene colorG = myDNA.GetGeneOfType(GeneType.COLOR);
        if (colorG == null)
            myDNA.SaveGene(new GeneColor(GeneType.COLOR, color));
        else
            color = colorG.GetValue<Color>();
    }
}
