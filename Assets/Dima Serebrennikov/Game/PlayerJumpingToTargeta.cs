// PlayerJumpingToTarget.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\PlayerJumpingToTarget.csPlayerJumpingToTarget.cs
using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;
namespace Serebrennikov {
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerJumpingToTarget : MonoBehaviour {
        [SerializeField] PathSensor _sensor;
        [SerializeField] Transform _target;
        [SerializeField] float _jumpHeight = 1.0f;
        [SerializeField] float _forwardSpeed = 4.0f;
        [SerializeField] float _groundProbe = 0.08f;
        [SerializeField] LayerMask _groundMask = ~0;
        [SerializeField] MonoBehaviourSignal _signal;
        Rigidbody _rigidbody;
        bool _isGoingToTarget;
        [CanBeNull] IDisposable _d;
        void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
        void Update() {
            if (!_sensor.HasAnyMatchOnPath() && !_isGoingToTarget) {
                _signal.Execute();
                _isGoingToTarget = true;
                _d = Loop.FixedUpdate(() => {
                    if (!IsGrounded()) return;
                    JumpForward();
                });
            }
        }
        void OnDisable() {
            _d?.Dispose();
        }
        void JumpForward() {
            Vector3 toTarget = _target.position - _rigidbody.position;
            toTarget.y = 0f;
            if (toTarget.sqrMagnitude < 0.0001f) {
                _rigidbody.linearVelocity = Vector3.zero;
                return;
            }
            Vector3 forwardDirection = toTarget.normalized;
            float jumpUpSpeed = Mathf.Sqrt(2f * Physics.gravity.magnitude * _jumpHeight);
            Vector3 velocity = _rigidbody.linearVelocity;
            velocity.x = forwardDirection.x * _forwardSpeed;
            velocity.z = forwardDirection.z * _forwardSpeed;
            velocity.y = jumpUpSpeed;
            _rigidbody.linearVelocity = velocity;
        }
        bool IsGrounded() {
            Bounds bounds = GetWorldBounds();
            Vector3 origin = bounds.center;
            float radius = Mathf.Max(0.02f, Mathf.Min(bounds.extents.x, bounds.extents.z) * 0.5f);
            float castDistance = bounds.extents.y + _groundProbe;
            return Physics.SphereCast(origin, radius, Vector3.down, out _, castDistance, _groundMask, QueryTriggerInteraction.Ignore);
        }
        Bounds GetWorldBounds() {
            Collider collider = GetComponent<Collider>();
            if (collider != null) return collider.bounds;
            Renderer renderer = GetComponentInChildren<Renderer>();
            if (renderer != null) return renderer.bounds;
            return new Bounds(transform.position, Vector3.one);
        }
    }
}
