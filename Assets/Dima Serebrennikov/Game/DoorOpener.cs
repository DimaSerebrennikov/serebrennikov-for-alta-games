using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class DoorOpener : MonoBehaviour {
    [SerializeField] float _openAngle = 90f; // Max angle in either direction
    [SerializeField] float _openSpeed = 180f; // Degrees per second
    [SerializeField] int direction = 1;

    float _currentAngle;
    float _targetAngle;

    bool _isMoving;

    void Update() {
        if (!_isMoving) {
            return;
        }
        float previousAngle = _currentAngle;
        _currentAngle = Mathf.MoveTowards(
            _currentAngle,
            _targetAngle,
            _openSpeed * Time.deltaTime
            );
        float delta = _currentAngle - previousAngle;
        transform.Rotate(0f, delta, 0f, Space.Self);
        if (Mathf.Approximately(_currentAngle, _targetAngle)) {
            _isMoving = false;
        }
    }

    // Opens in explicit direction (1 or -1)
    public void Open() {
        direction = Mathf.Clamp(direction, -1, 1);
        _targetAngle = _openAngle * direction;
        _isMoving = true;
    }

    public void Close() {
        _targetAngle = 0f;
        _isMoving = true;
    }

    public void Toggle() {
        if (Mathf.Approximately(_currentAngle, 0f)) {
            Open();
        } else {
            Close();
        }
    }
}
