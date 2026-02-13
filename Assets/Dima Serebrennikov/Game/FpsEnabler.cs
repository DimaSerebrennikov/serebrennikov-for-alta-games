// FpsEnabler.csC:\Users\DimaS\Serebrennikov for alta games\Assets\Dima Serebrennikov\Game\FpsEnabler.csFpsEnabler.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov {
    public class FpsEnabler : MonoBehaviour {
        void Awake() {
            Application.targetFrameRate = 60;
        }
    }
}
