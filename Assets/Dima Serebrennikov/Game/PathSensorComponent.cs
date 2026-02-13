using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class PathSensorComponent : MonoBehaviour {
    [Min(0.0f)] public float Width = 0.25f;
    public LayerMask Mask = ~0;
    public QueryTriggerInteraction Triggers = QueryTriggerInteraction.Ignore;
    public bool DrawDebug = true;
    public Color DebugColorHit = Color.green;
    public Color DebugColorMiss = Color.red;
}