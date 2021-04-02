using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveMask : MonoBehaviour
{
    SpriteRenderer render;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            render.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            render.enabled = true;
        }
    }
}
