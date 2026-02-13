// SimplePopupExample.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\SimplePopupExample.csSimplePopupExample.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using PopupWindow = UnityEditor.PopupWindow;
public static class SimplePopupExample {
    //[MenuItem("Serebrennikov/Show popup example")]
    static void ShowPopup() {
        Rect rect = new(200, 200, 0, 0); // Position on screen
        PopupWindow.Show(rect, new MyPopupContent());
    }
    class MyPopupContent : PopupWindowContent {
        public override Vector2 GetWindowSize() {
            return new Vector2(200, 60); // Size of popup
        }
        public override void OnGUI(Rect rect) {
            GUILayout.Label("Hello!", EditorStyles.boldLabel);
            if (GUILayout.Button("Click Me")) {
                Debug.Log("Button clicked!");
                editorWindow.Close(); // Close popup
            }
        }
    }
}
