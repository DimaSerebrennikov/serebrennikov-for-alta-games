using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class Loop {
        static LoopMb _mono;
        public Loop(LoopMb mono) {
            _mono = mono;
        }
        public static IDisposable Update(ITick onTick) {
            return _mono.RegisterTick(onTick);
        }
        public static IDisposable FixedUpdate(IFixedTick onTick) {
            return _mono.RegisterFixedTick(onTick);
        }
        public static IDisposable Update(Action on) {
            return _mono.RegisterTick(new Action_Update(on));
        }
        public static IDisposable FixedUpdate(Action on) {
            return _mono.RegisterFixedTick(new Action_FixedUpdate(on));
        }
        public static void Refresh() {
            _mono.Refresh();
        }
    }
    public class Action_FixedUpdate : IFixedTick {
        readonly Action _callback;
        public Action_FixedUpdate(Action callback) {
            _callback = callback;
        }
        public void FixedUpate() {
            _callback();
        }
    }
    public class Action_Update : ITick {
        public Action callback { get; }
        public Action_Update(Action callback) {
            this.callback = callback;
        }
        public void Update() {
            callback();
        }
    }
    public readonly struct OneUpdate<T> : IDisposable {
        readonly List<T> _list;
        readonly T _target;
        public OneUpdate(List<T> list, T target) {
            _list = list;
            _target = target;
        }
        public void Dispose() {
            _list.Remove(_target);
        }
    }
}
