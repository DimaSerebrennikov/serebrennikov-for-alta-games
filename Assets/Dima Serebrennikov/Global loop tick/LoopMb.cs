using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class LoopMb : MonoBehaviour {
        public IUpdater model { get; set; }
        public IDisposable RegisterTick(ITick onTick) {
            return model.RegisterTick(onTick);
        }
        public IDisposable RegisterFixedTick(IFixedTick onTick) {
            return model.RegisterFixedTick(onTick);
        }
        public void Refresh() {
            model.Refresh();
        }
        void Update() {
            model.Update();
        }
        void FixedUpdate() {
            model.FixedUpate();
        }
    }
}
