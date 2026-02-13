// PlaneDensitySpawner.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\PlaneDensitySpawner.csPlaneDensitySpawner.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace Serebrennikov {
    public sealed class PlaneDensitySpawner : MonoBehaviour { /*editor only, I should convert it in inspector script to avoid preprocessors*/
        #if UNITY_EDITOR
        [SerializeField] float width = 10f;
        [SerializeField] float depth = 10f;
        [SerializeField] float density = 1f;
        [SerializeField] GameObject[] _prefabs;
        [SerializeField] Transform parent;
        [SerializeField] float _scale = 1f;
        [SerializeField] bool drawGizmos = true;
        [SerializeField] Quaternion _startRotation;
        public void Generate() {
            if (_prefabs.Length == 0) return;
            float area = width * depth;
            int objectCount = Mathf.RoundToInt(area * density);
            Transform targetParent = parent != null ? parent : transform;
            for (int index = 0; index < objectCount; index++) {
                Vector3 position = GetRandomPointOnPlane();
                int randomIndex = Random.Range(0, _prefabs.Length);
                GameObject prefab = _prefabs[randomIndex];
                GameObject instance;
                if (!Application.isPlaying) {
                    instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab, targetParent);
                    instance.transform.position = position;
                } else {
                    instance = Instantiate(prefab, position, Quaternion.identity, targetParent);
                }
                instance.transform.rotation = _startRotation;
                instance.transform.localScale = Vector3.one * _scale;
            }
        }
        public void Clear() {
            Transform targetParent = parent != null ? parent : transform;
            int childCount = targetParent.childCount;
            for (int index = childCount - 1; index >= 0; index--) {
                DestroyImmediate(targetParent.GetChild(index).gameObject);
            }
        }
        Vector3 GetRandomPointOnPlane() {
            float halfWidth = width * 0.5f;
            float halfDepth = depth * 0.5f;
            float offsetWidth = Random.Range(-halfWidth, halfWidth);
            float offsetDepth = Random.Range(-halfDepth, halfDepth);
            Vector3 localOffset = new(offsetWidth, 0f, offsetDepth);
            return transform.position + localOffset;
        }
        void OnDrawGizmos() {
            if (!drawGizmos) {
                return;
            }
            Gizmos.color = Color.green;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, Vector3.one);
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(width, 0f, depth));
        }
        #endif
    }
}
