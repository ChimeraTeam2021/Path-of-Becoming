using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PazzleControl : MonoBehaviour
{
    [SerializeField]
    private RectTransform[] hexagon;
    private Animator anim;
    
    public static bool youWin;

    private void Start()
    {
        youWin = false;
        anim = GetComponent<Animator>();

        hexagon[0].rotation = new Quaternion(0f, 0f, 60f,0);
        hexagon[1].rotation = new Quaternion(0f, 0f, 180f, 0);
        hexagon[2].rotation = new Quaternion(0f, 0f, 120f, 0);
        hexagon[3].rotation = new Quaternion(0f, 0f, -60f, 0);
        hexagon[4].rotation = new Quaternion(0f, 0f, -180f, 0);
        hexagon[5].rotation = new Quaternion(0f, 0f, -120f, 0);
        hexagon[6].rotation = new Quaternion(0f, 0f, 60f, 0);

    }

    private void Update()
    {
        if (hexagon[0].rotation.z >= -0.0001 && hexagon[0].rotation.z <= 0.0001 &&
            hexagon[1].rotation.z >= -0.0001 && hexagon[0].rotation.z <= 0.0001 &&
            hexagon[2].rotation.z >= -0.0001 && hexagon[0].rotation.z <= 0.0001 &&
            hexagon[3].rotation.z >= -0.0001 && hexagon[0].rotation.z <= 0.0001 &&
            hexagon[4].rotation.z >= -0.0001 && hexagon[0].rotation.z <= 0.0001 &&
            hexagon[5].rotation.z >= -0.0001 && hexagon[0].rotation.z <= 0.0001 &&
            hexagon[6].rotation.z >= -0.0001 && hexagon[0].rotation.z <= 0.0001)
        {
            youWin = true;

            anim.SetBool("win", true);
        }
    }
}
