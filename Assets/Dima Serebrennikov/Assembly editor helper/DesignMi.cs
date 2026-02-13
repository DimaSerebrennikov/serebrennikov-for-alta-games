// CreateDocumentation.csC:\Feeble snow\Assets\Serebrennikov\Assembly editor helper\CreateDocumentation.csCreateDocumentation.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
static class DesignMi {
    [MenuItem("Assets/Serebrennikov/Design", false, 2)]
    [MenuItem("Assets/Create/Serebrennikov/Design", false, -999)]
    static void Do() {
        string folderPath = TheUnityProjectWindow.GetSelectedFolderPath();
        string lastFolderName = Path.GetFileName(folderPath);
        TheDocumentation.CreateMarkdown(folderPath, "Design", lastFolderName);
    }
}
