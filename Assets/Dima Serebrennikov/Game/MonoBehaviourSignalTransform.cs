// MonoBehaviourSignalTransform.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\MonoBehaviourSignalTransform.csMonoBehaviourSignalTransform.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class MonoBehaviourSignalTransform : MonoBehaviour {
        Action<Transform> _on = a => {};
        public void Execute(Transform a) {
            _on(a);
        }
        public IDisposable Wait(Action<Transform> on) {
            _on += on;
            return new Disposer(() => _on -= on);
        }
    }
}
