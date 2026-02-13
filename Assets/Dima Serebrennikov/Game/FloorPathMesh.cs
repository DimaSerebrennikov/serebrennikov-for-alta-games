// FloorPathMesh.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\FloorPathMesh.csFloorPathMesh.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[ExecuteAlways]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class FloorPathMesh : MonoBehaviour {
    [SerializeField] Transform _source;
    [SerializeField] Transform _target;
    [SerializeField] LayerMask _floorMask = ~0;
    [SerializeField] float _rayHeight = 5f;
    [SerializeField] float _surfaceOffset = 0.01f;
    [SerializeField] bool _useFootprintWidth = true;
    [SerializeField] float _fallbackWidth = 1f;
    MeshFilter _meshFilter;
    Mesh _mesh;
    void Awake() {
        _meshFilter = GetComponent<MeshFilter>();
        _mesh = new Mesh();
        _mesh.name = "FloorPathMesh";
        _meshFilter.sharedMesh = _mesh;
    }
    void LateUpdate() {
        if (_source == null || _target == null || !TryProjectToFloor(_source.position, out Vector3 startPoint, out Vector3 startNormal) || !TryProjectToFloor(_target.position, out Vector3 endPoint, out Vector3 endNormal)) {
            ClearMesh();
            return;
        }
        Vector3 floorNormal = startNormal + endNormal;
        if (floorNormal.sqrMagnitude < 0.0001f) {
            floorNormal = Vector3.up;
        } else {
            floorNormal.Normalize();
        }
        Vector3 forward = endPoint - startPoint;
        forward = Vector3.ProjectOnPlane(forward, floorNormal);
        float forwardLength = forward.magnitude;
        if (forwardLength < 0.001f) {
            ClearMesh();
            return;
        }
        forward /= forwardLength;
        float width = GetSourceWidthOnGround();
        float halfWidth = width * 0.5f;
        Vector3 right = Vector3.Cross(floorNormal, forward).normalized;
        Vector3 offset = floorNormal * _surfaceOffset;
        Vector3 v0 = startPoint - right * halfWidth + offset;
        Vector3 v1 = startPoint + right * halfWidth + offset;
        Vector3 v2 = endPoint - right * halfWidth + offset;
        Vector3 v3 = endPoint + right * halfWidth + offset;
        UpdateQuad(v0, v1, v2, v3, floorNormal, forwardLength, width);
    }
    bool TryProjectToFloor(Vector3 worldPosition, out Vector3 hitPoint, out Vector3 hitNormal) {
        Ray ray = new(worldPosition + Vector3.up * _rayHeight, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, _rayHeight * 2f, _floorMask, QueryTriggerInteraction.Ignore)) {
            hitPoint = hit.point;
            hitNormal = hit.normal;
            return true;
        }
        hitPoint = worldPosition;
        hitNormal = Vector3.up;
        return false;
    }
    float GetSourceWidthOnGround() {
        if (_source == null || !TryGetWorldBounds(_source, out Bounds bounds)) {
            return _fallbackWidth;
        }
        if (_useFootprintWidth) {
            return Mathf.Max(bounds.size.x, bounds.size.z);
        }
        return bounds.size.x;
    }
    bool TryGetWorldBounds(Transform targetTransform, out Bounds bounds) {
        Collider col = targetTransform.GetComponent<Collider>();
        if (col != null) {
            bounds = col.bounds;
            return true;
        }
        Renderer rend = targetTransform.GetComponent<Renderer>();
        if (rend != null) {
            bounds = rend.bounds;
            return true;
        }
        bounds = new Bounds(targetTransform.position, Vector3.zero);
        return false;
    }
    void UpdateQuad(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3, Vector3 normal, float length, float width) {
        Vector3[] vertices = new Vector3[4];
        vertices[0] = transform.InverseTransformPoint(v0);
        vertices[1] = transform.InverseTransformPoint(v1);
        vertices[2] = transform.InverseTransformPoint(v2);
        vertices[3] = transform.InverseTransformPoint(v3);
        int[] triangles = new int[6] {
            0,
            2,
            1,
            1,
            2,
            3
        };
        Vector3[] normals = new Vector3[4];
        Vector3 localNormal = transform.InverseTransformDirection(normal);
        normals[0] = localNormal;
        normals[1] = localNormal;
        normals[2] = localNormal;
        normals[3] = localNormal;
        Vector2[] uv = new Vector2[4];
        uv[0] = new Vector2(0f, 0f);
        uv[1] = new Vector2(1f, 0f);
        uv[2] = new Vector2(0f, length / Mathf.Max(0.0001f, width));
        uv[3] = new Vector2(1f, length / Mathf.Max(0.0001f, width));
        _mesh.Clear();
        _mesh.vertices = vertices;
        _mesh.triangles = triangles;
        _mesh.normals = normals;
        _mesh.uv = uv;
        _mesh.RecalculateBounds();
    }
    void ClearMesh() {
        if (_mesh == null) {
            return;
        }
        _mesh.Clear();
    }
}
