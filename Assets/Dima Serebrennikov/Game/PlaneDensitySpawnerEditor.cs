#if UNITY_EDITOR
// PlaneDensitySpawnerEditor.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\PlaneDensitySpawnerEditor.csPlaneDensitySpawnerEditor.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
namespace Serebrennikov {
    [CustomEditor(typeof(PlaneDensitySpawner))]
    public sealed class PlaneDensitySpawnerEditor : Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();
            PlaneDensitySpawner spawner = (PlaneDensitySpawner)target;
            GUILayout.Space(10);
            if (GUILayout.Button("Generate")) {
                spawner.Generate();
            }
            if (GUILayout.Button("Clear")) {
                spawner.Clear();
            }
        }
    }
}
#endif
