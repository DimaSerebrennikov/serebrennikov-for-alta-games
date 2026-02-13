// DocumentationCreator.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\DocumentationCreator.csDocumentationCreator.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
static class TheDocumentation {
    static internal void CreateMarkdown(string folderPath, string fileName, string assemblyName) {
        string path = Path.Combine(folderPath, $"{fileName}.md");
        if (!File.Exists(path)) {
            File.WriteAllText(path, $"# {assemblyName}");
            AssetDatabase.ImportAsset(path);
        } else {
            EditorUtility.DisplayDialog("Warning", $"{fileName}.md already exists.", "OK");
        }
        AssetDatabase.Refresh();
    }
    static internal void CreateCSharp(string folderPath) {
        string path = Path.Combine(folderPath, "NewScript.cs");
        if (!File.Exists(path)) {
            File.WriteAllText(path,
/**/ "using UnityEngine;\n" +
/**/ "public class NewScript : MonoBehaviour {}");
            AssetDatabase.ImportAsset(path);
        } else {
            EditorUtility.DisplayDialog("Warning", "NewScript.cs already exists.", "OK");
        }
        AssetDatabase.Refresh();
    }
}
