using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct AIConfig
{
    public float Speed;
    public float MinDistanceToTarget;
    public Transform[] Waipoints;
}
