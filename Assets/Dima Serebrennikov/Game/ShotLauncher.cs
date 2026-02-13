// ShootingAnimation.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\ShootingAnimation.csShootingAnimation.cs
using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
namespace Serebrennikov {
    public class ShotLauncher : MonoBehaviour {
        [SerializeField] MonoBehaviourSignalTransform _signal;
        [SerializeField] Transform _target;
        [SerializeField] float _power = 1f;
        void Awake() {
            _signal.Wait(Shot);
        }
        public void Shot(Transform source) {
            Rigidbody rb = source.gameObject.AddComponent<Rigidbody>();
            Vector3 direction = _target.position - source.position;
            rb.AddForce(direction * _power, ForceMode.Impulse);
        }
    }
}
