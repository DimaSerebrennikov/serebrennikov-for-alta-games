// PowerShootingContext.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\PowerShootingContext.csPowerShootingContext.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class PowerShootingContext : MonoBehaviour {
        public Transform _parent;
        public Transform _shotPrefab;
        public Transform _ptToCreateShot;
        public float _scalingSpeed;
        public float _pumpingRatio = 0.5f;
        public float _minSizeParent = 0.1f;
    }
}
