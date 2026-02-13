// SceneRestartImage.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\SceneRestartImage.csSceneRestartImage.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
namespace Serebrennikov {
    public sealed class SceneRestartImage : MonoBehaviour, IPointerClickHandler {
        public void OnPointerClick(PointerEventData eventData) {
            RestartActiveScene();
        }
        static void RestartActiveScene() // Reloads currently active scene
        {
            Scene activeScene = SceneManager.GetActiveScene();
            Loop.Refresh(); /*for now it's like this)*/
            TheUnityObject.Refresh();
            Time.timeScale = 1f;
            SceneManager.LoadScene(activeScene.buildIndex);
        }
    }
}
