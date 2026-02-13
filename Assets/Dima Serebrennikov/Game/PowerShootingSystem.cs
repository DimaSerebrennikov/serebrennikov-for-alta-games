// PowerShootingSystem.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\PowerShootingSystem.csPowerShootingSystem.cs
using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;
namespace Serebrennikov {
    public class PowerShootingSystem {
        [CanBeNull] Transform _currentShot;
        PowerShootingContext _c;
        bool _isCasting;
        Action _lostSignal;
        Action<Transform> _shotSignal;
        float _scalingSpeed => _c._scalingSpeed;
        float _pumpingRatio => _c._pumpingRatio;
        float _minSizeParent => _c._minSizeParent;
        Transform _parent => _c._parent;
        Transform _shotPrefab => _c._shotPrefab;
        Transform _ptToCreateShot => _c._ptToCreateShot;
        public PowerShootingSystem(PowerShootingContext c, Action lostSignal, Action<Transform> shotSignal) {
            _c = c;
            _lostSignal = lostSignal;
            _shotSignal = shotSignal;
        }
        public void OnCastStarted(InputAction.CallbackContext context) {
            if (_isCasting) {
                return;
            }
            _currentShot = Object.Instantiate(_shotPrefab, _ptToCreateShot.position, Quaternion.identity);
            _currentShot.localScale = Vector3.zero;
            _isCasting = true;
        }
        public void OnCastCanceled(InputAction.CallbackContext context) {
            if (!_isCasting) {
                return;
            }
            _isCasting = false;
            if (_currentShot != null) {
                _shotSignal(_currentShot);
                _currentShot = null;
            }
        }
        public void Update() {
            if (_currentShot == null) {
                return;
            }
            float scalingSpeed = _scalingSpeed * Time.deltaTime;
            _parent.localScale -= Vector3.one * (scalingSpeed * _pumpingRatio);
            _currentShot.localScale += Vector3.one * scalingSpeed;
            if (_parent.localScale.z <= _minSizeParent) {
                _lostSignal();
            }
        }
    }
}
