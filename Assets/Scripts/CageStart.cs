﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageStart : MonoBehaviour
{
    public GameObject Pazzle;

    public void OnMouseDown()
    {
        Pazzle.SetActive(true);
    }
}
