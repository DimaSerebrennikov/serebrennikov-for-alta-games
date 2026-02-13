using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;
namespace Serebrennikov {
    public class ObstacleSystemService {
        static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");
        Action<Vector3> _onBurst = a => {};
        ObstacleSystemComponent _component;
        public ObstacleSystemService(ObstacleSystemComponent component, Action<Vector3> onBurst) {
            _component = component;
            _onBurst = onBurst;
        }
        public List<MeshRenderer> List { get; set; } = new();
        public bool SetInFireWithRadius(Transform source, float scale) {
            for (int i = List.Count - 1; i >= 0; i--) {
                MeshRenderer mesh = List[i];
                if (mesh.transform == source) {
                    List.RemoveAt(i);
                    CheckInRadius(mesh, scale);
                    return true;
                }
            }
            return false;
        }
        void CheckInRadius(MeshRenderer centerObject, float scale) {
            SetInFireSingle(centerObject);
            for (int i = List.Count - 1; i >= 0; i--) {
                MeshRenderer mesh = List[i];
                if (Vector3.Distance(mesh.transform.position, centerObject.transform.position) < _component.TargetDistance * scale) {
                    SetInFireSingle(mesh);
                    List.RemoveAt(i);
                }
            }
        }
        public void SetInFireSingle(MeshRenderer element) {
            MeshRenderer mesh = element;
            MaterialPropertyBlock block = new();
            mesh.GetPropertyBlock(block);
            IDisposable d = null;
            float time = 0f;
            d = Loop.Update(() => {
                if (_component.TargetTime <= 0) {
                    time = 1f;
                } else {
                    time += Time.deltaTime / _component.TargetTime;
                }
                block.SetColor(BaseColorId, Color.Lerp(Color.yellow, Color.red, time));
                mesh.SetPropertyBlock(block);
                if (time >= 1f) {
                    _onBurst(mesh.transform.position);
                    Object.Destroy(mesh.gameObject);
                    d?.Dispose();
                }
            });
        }
    }
}