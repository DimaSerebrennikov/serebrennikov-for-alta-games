// ControllerToUi.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\ControllerToUi.csControllerToUi.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class ControllerToUi : MonoBehaviour {
        [SerializeField] MonoBehaviourSignal _lostSignal;
        [SerializeField] GameObject _loosingScreenPrefab;
        void Awake() {
            _lostSignal.Wait(Run); /*higher than game logic, but whatever, it means nothing for a simple solution.*/
        }
        void Run() {
            Time.timeScale = 0f;
            Instantiate(_loosingScreenPrefab);
        }
    }
}
