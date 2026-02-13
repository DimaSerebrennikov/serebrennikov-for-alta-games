// ObstacleSystem.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\ObstacleSystem.csObstacleSystem.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class ObstacleSystem : MonoBehaviour { /*clean*/
        [SerializeField] ParticleSystem _vfx;
        static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");
        [SerializeField] ObstacleSystemComponent _c;
        ObstacleSystemService _service;
        void Awake() {
            _service = new ObstacleSystemService(_c, a => Instantiate(_vfx, a, Quaternion.identity));
        }
        public bool SetInFireWithRadius(Transform source, float scale) {
            return _service.SetInFireWithRadius(source, scale);
        }
        public List<MeshRenderer> List { get => _service.List; set => _service.List = value; }
    }
}
