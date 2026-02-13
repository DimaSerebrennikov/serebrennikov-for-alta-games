// OpenDoorsEditor.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\OpenDoorsEditor.csOpenDoorsEditor.cs
#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
namespace Serebrennikov {
    [CustomEditor(typeof(OpenDoors))]
    public class OpenDoorsEditor : Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();
            OpenDoors targetComponent = (OpenDoors)target;
            EditorGUILayout.Space();
            if (GUILayout.Button("Open Doors")) {
                targetComponent.Open();
            }
            if (GUILayout.Button("Close Doors")) {
                targetComponent.Close();
            }
        }
    }
}
#endif
