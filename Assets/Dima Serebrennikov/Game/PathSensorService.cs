// PathSensorService.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\PathSensorService.csPathSensorService.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class PathSensorService {
    PathSensorComponent _c;
    Transform source;
    Transform target;
    public PathSensorService(PathSensorComponent c, Transform source, Transform target) {
        _c = c;
        this.source = source;
        this.target = target;
    }
    public bool HasAnyMatchOnPath(out RaycastHit firstHit) {
        firstHit = default;
        if (source == null || target == null) {
            return false;
        }
        Vector3 origin = source.position;
        Vector3 toTarget = target.position - origin;
        float distance = toTarget.magnitude;
        if (distance <= Mathf.Epsilon) {
            return false;
        }
        Vector3 direction = toTarget / distance;
        bool hit = Physics.SphereCast(origin, _c.Width, direction, out firstHit, distance, _c.Mask, _c.Triggers);
        if (_c.DrawDebug) {
            DrawDebugCast(origin, direction, distance, hit);
        }
        return hit;
    }
    public bool HasAnyMatchOnPath() {
        RaycastHit unusedHit;
        return HasAnyMatchOnPath(out unusedHit);
    }
    void DrawDebugCast(Vector3 origin, Vector3 direction, float distance, bool hit) {
        Color color = hit ? _c.DebugColorHit : _c.DebugColorMiss;
        Vector3 end = origin + direction * distance;
        Debug.DrawLine(origin, end, color);
        float marker = Mathf.Max(_c.Width, 0.01f);
        Debug.DrawLine(origin + Vector3.up * marker, origin - Vector3.up * marker, color);
        Debug.DrawLine(origin + Vector3.right * marker, origin - Vector3.right * marker, color);
        Debug.DrawLine(end + Vector3.up * marker, end - Vector3.up * marker, color);
        Debug.DrawLine(end + Vector3.right * marker, end - Vector3.right * marker, color);
    }
}
