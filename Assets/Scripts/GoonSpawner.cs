using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GoonSpawner : MonoBehaviour
{
    public GameObject goon;
    private TargetBehavior targetBehavior;
    public enum GoonType { Hat, Heli, Para};
    public GoonType goonType;

    GoonBuilder goonBuilder;

    void Start()
    {
        targetBehavior = goon.GetComponent<TargetBehavior>();

        switch (goonType)
        {
            case GoonType.Heli:
                goonBuilder = new HeliGoon(goon);
                InvokeRepeating("MakeGoon", 1.0f, 1f);
                break;
            case GoonType.Hat:
                goonBuilder = new HatGoon(goon);
                InvokeRepeating("MakeGoon", 1.0f, 0.5f);
                break;
            case GoonType.Para:
                goonBuilder = new ParaGoon(goon);
                InvokeRepeating("MakeGoon", 1.0f, 0.75f);
                break;
        }
    }

    void Update()
    {
        
    }


    void MakeGoon()
    {
        goonBuilder.ConstructGoon(transform.position);
    }
}
