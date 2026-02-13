using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Serebrennikov {
    public class PowerShooting : MonoBehaviour { /*clean*/
        [SerializeField] InputActionReference _castAction;
        [SerializeField] MonoBehaviourSignal _lostSignal;
        [SerializeField] MonoBehaviourSignalTransform _shotSignal;
        [SerializeField] PowerShootingContext _c;
        PowerShootingSystem _system;
        bool _isCasting;
        void Awake() {
            _system = new PowerShootingSystem(_c, _lostSignal.Execute, _shotSignal.Execute);
        }
        void OnEnable() {
            InputAction action = _castAction.action;
            action.started += _system.OnCastStarted;
            action.canceled += _system.OnCastCanceled;
            action.Enable();
        }
        void OnDisable() {
            InputAction action = _castAction.action;
            action.started -= _system.OnCastStarted;
            action.canceled -= _system.OnCastCanceled;
            action.Disable();
        }
        void Update() {
            _system.Update();
        }
    }
}
