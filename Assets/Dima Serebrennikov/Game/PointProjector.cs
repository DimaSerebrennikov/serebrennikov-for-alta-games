// PointProjector.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\PointProjector.csPointProjector.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    [ExecuteAlways]
    public class PointProjector : MonoBehaviour {
        [SerializeField] Transform _source;
        [SerializeField] Vector3 _directionWorldSpace = Vector3.down;
        [SerializeField] float _maxDistance = 100f;
        [SerializeField] LayerMask _mask = ~0;
        [SerializeField] Transform _target;
        [SerializeField] bool _alignToNormal;
        [SerializeField] float _surfaceOffset;
        void Update() {
            if (_directionWorldSpace.sqrMagnitude <= 0) return;
            Vector3 origin = _source.position;
            _directionWorldSpace.Normalize();
            Ray ray = new(origin, _directionWorldSpace);
            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _mask, QueryTriggerInteraction.Ignore)) {
                _target.position = hit.point + hit.normal * _surfaceOffset;
                if (_alignToNormal) {
                    _target.rotation = Quaternion.LookRotation(_target.forward, hit.normal);
                }
            }
        }
    }
}
