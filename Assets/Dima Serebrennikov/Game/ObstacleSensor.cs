// ObstacleSensor.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\ObstacleSensor.csObstacleSensor.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class ObstacleSensor : MonoBehaviour {
        [SerializeField] ParticleSystem _vfx;
        [SerializeField] ObstacleSystem _systemAsset;
        void Awake() {
            _systemAsset = TheUnityObject.InstanceFromAsset(_systemAsset);
        }
        void OnCollisionEnter(Collision other) {
            if (_systemAsset.SetInFireWithRadius(other.transform, transform.localScale.x)) {
                Instantiate(_vfx, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
