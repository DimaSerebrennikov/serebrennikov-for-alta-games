using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
public static class TheAssembly {
    static internal void CreateFolderWithAssembly(string parentPath, string folderName, string assemblyName, out string folderPath) {
        if (CreateFolder(parentPath, folderName, out folderPath)) return;
        string asmdefPath = Path.Combine(folderPath, assemblyName + ".asmdef");
        if (!File.Exists(asmdefPath)) {
            string asmdefContent = $"{{\n  \"name\": \"{assemblyName}\"\n}}";
            File.WriteAllText(asmdefPath, asmdefContent);
            AssetDatabase.ImportAsset(asmdefPath);
        } else {
            EditorUtility.DisplayDialog("Warning", $"{assemblyName}.asmdef already exists.", "OK");
        }
        AssetDatabase.Refresh();
    }
    static internal bool CreateFolder(string parentPath, string folderName, out string folderPath) {
        folderPath = Path.Combine(parentPath, folderName);
        if (!AssetDatabase.IsValidFolder(folderPath)) {
            AssetDatabase.CreateFolder(parentPath, folderName);
        } else {
            EditorUtility.DisplayDialog("Warning", $"Folder '{folderName}' already exists.", "OK");
            return true;
        }
        return false;
    }
}
