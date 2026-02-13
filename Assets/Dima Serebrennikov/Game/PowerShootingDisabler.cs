// PowerShootingDisabler.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\PowerShootingDisabler.csPowerShootingDisabler.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class PowerShootingDisabler : MonoBehaviour {
        [SerializeField] PowerShooting _system;
        [SerializeField] MonoBehaviourSignal _lostSignal;
        [SerializeField] MonoBehaviourSignal _startJumping;
        void Awake() {
            _lostSignal.Wait(DisableSystem);
            _startJumping.Wait(DisableSystem);
        }
        void DisableSystem() {
            _system.enabled = false;
        }
    }
}
