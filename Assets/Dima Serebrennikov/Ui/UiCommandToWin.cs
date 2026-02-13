using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class UiCommandToWin : MonoBehaviour {
        [SerializeField] MonoBehaviourSignal _lostSignal;
        [SerializeField] UiContext _context;
        [SerializeField] float _targetTime = 1f;
        [SerializeField] Color _targetColor;
        float _time;
        void Awake() {
            _lostSignal.Wait(Run);
        }
        void Run() {
            UiContext context = Instantiate(_context);
            context.Background.color = Color.clear;
            context.SelectionPart.SetActive(false);
            IDisposable d = null;
            d = Loop.Update(() => {
                if (_targetTime <= 0f) {
                    _time = 1f;
                } else {
                    _time += Time.deltaTime / _targetTime;
                }
                context.Background.color = Color.Lerp(Color.clear, _targetColor, _time);
                if (_time >= 1) {
                    Time.timeScale = 0f;
                    context.SelectionPart.SetActive(true);
                    d?.Dispose();
                }
            });
        }
    }
}
