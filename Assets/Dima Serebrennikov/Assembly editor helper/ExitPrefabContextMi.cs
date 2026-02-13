// ExitPrefabContextMi.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\ExitPrefabContextMi.csExitPrefabContextMi.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
public static class ExitPrefabContextMi {
    [MenuItem("Serebrennikov/Exit Prefab Context")]
    public static void ExitPrefabContext() {
        if (PrefabStageUtility.GetCurrentPrefabStage() != null) {
            StageUtility.GoToMainStage();
        }
    }
}
