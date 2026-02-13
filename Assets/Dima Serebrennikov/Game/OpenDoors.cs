// OpenDoors.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\OpenDoors.csOpenDoors.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class OpenDoors : MonoBehaviour {
        [SerializeField] DoorOpener[] _doors;
        [SerializeField] Transform _target;
        [SerializeField] Transform _player;
        [SerializeField] float _distanceToOpenDoors;
        [SerializeField] MonoBehaviourSignal _signal;
        bool _isOpened;
        void Update() {
            if (Vector3.Distance(_player.position, _target.position) <= _distanceToOpenDoors && !_isOpened) {
                _isOpened = true;
                Open();
            }
        }
        public void Open() {
            for (int i = 0; i < _doors.Length; i++) {
                _doors[i].Open();
                _signal.Execute();
            }
        }
        public void Close() {
            for (int i = 0; i < _doors.Length; i++) {
                _doors[i].Close();
            }
        }
        void OnDrawGizmos() {
            if (_target == null) {
                return;
            }
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_target.position, _distanceToOpenDoors);
        }
    }
}
