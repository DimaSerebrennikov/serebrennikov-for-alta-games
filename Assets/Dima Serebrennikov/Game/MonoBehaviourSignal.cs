using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class MonoBehaviourSignal : MonoBehaviour {
        Action _on = () => {};
        public void Execute() {
            _on();
        }
        public IDisposable Wait(Action on) {
            _on += on;
            return new Disposer(() => _on -= on);
        }
    }
}