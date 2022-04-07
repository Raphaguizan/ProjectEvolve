using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Creature;

[RequireComponent(typeof(Movement))]
public class ManualController : MonoBehaviour
{
    private Movement mov;

    private void Start()
    {
        mov = GetComponent<Movement>();
    }
    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if (hori != 0 || vert != 0)
        {
            mov.Move(new Vector2(hori, vert));
        }
        else
        {
            mov.Move(Vector2.zero);
        }
    }
}
