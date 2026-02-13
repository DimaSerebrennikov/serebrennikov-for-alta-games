// ObstaclesContiner.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\ObstaclesContiner.csObstaclesContiner.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class ObstaclesContainer : MonoBehaviour {
        [SerializeField] List<MeshRenderer> _list = new();
        [SerializeField] ObstacleSystem _asset;
        void Awake() {
            _asset = TheUnityObject.InstanceFromAsset(_asset);
            _asset.List = _list;
        }
    }
}
