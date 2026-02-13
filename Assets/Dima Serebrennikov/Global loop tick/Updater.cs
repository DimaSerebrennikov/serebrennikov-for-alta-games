// Ticker.csC:\v1\Backup\Halette\Assets\Serebrennikov\Ticker.csTicker.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class Updater : IUpdater {
        public List<ITick> tickList { get; set; } = new();
        public List<IFixedTick> fixList { get; set; } = new();
        public IDisposable RegisterTick(ITick onTick) {
            tickList.Add(onTick);
            return new OneUpdate<ITick>(tickList, onTick);
        }
        public IDisposable RegisterFixedTick(IFixedTick onTick) {
            fixList.Add(onTick);
            return new OneUpdate<IFixedTick>(fixList, onTick);
        }
        public void Refresh() {
            tickList = new List<ITick>();
            fixList = new List<IFixedTick>();
        }
        public void FixedUpate() {
            for (int i = 0; i < fixList.Count; i++) {
                fixList[i].FixedUpate();
            }
        }
        public void Update() {
            for (int i = 0; i < tickList.Count; i++) {
                tickList[i].Update();
            }
        }
    }
}
