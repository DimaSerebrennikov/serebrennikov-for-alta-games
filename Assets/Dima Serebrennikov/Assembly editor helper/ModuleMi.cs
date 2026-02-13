// CreateModuleButton.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\CreateModuleButton.csCreateModuleButton.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
static class ModuleMi {
    [MenuItem("Assets/Create/Serebrennikov/Module", false, -1000)]
    [MenuItem("Assets/Serebrennikov/Module", false, 1)]
    static void Do() {
        string folderPath = TheUnityProjectWindow.GetSelectedFolderPath();
        ModuleEw.Open(folderPath, CreateDesign);
    }
    static void CreateDesign(string path, string assemblyName) {
        TheDocumentation.CreateMarkdown(path, "README", assemblyName);
        TheDocumentation.CreateCSharp(path);
    }
}
