// PathSensor.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\PathSensor.csPathSensor.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class PathSensor : MonoBehaviour { /*clean*/
    [SerializeField] Transform source;
    [SerializeField] Transform target;
    [SerializeField] PathSensorComponent _component;
    PathSensorService _service;
    void Awake() {
        _service = new PathSensorService(_component, source, target);
    }
    public bool HasAnyMatchOnPath(out RaycastHit firstHit) {
        return _service.HasAnyMatchOnPath(out firstHit);
    }
    public bool HasAnyMatchOnPath() {
        return _service.HasAnyMatchOnPath();
    }
}
