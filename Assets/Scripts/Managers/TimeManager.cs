using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField, Range(.5f, 11f)]
    private float timeScale = 1f;
    private void OnValidate()
    {
        Time.timeScale = timeScale;
    }
}
