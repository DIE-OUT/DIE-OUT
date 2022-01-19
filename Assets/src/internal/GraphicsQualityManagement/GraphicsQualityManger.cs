using System;
using DieOut.Helper;
using UnityEngine;

namespace DieOut.GraphicsQualityManagement {
    
    public class GraphicsQualityManger : MonoBehaviour {

        public static GraphicsQualityLevel CurrenGraphicsQualityLevel => (GraphicsQualityLevel) QualitySettings.GetQualityLevel();
        private static SingletonInstance<GraphicsQualityManger> _instance;
        
        
        private void Awake() {
            _instance.Init(this);
        }
        
        public static void SetGraphicsQualityLevel(GraphicsQualityLevel graphicsQualityLevel) {
            QualitySettings.SetQualityLevel((int) graphicsQualityLevel);
        }
        
    }
    
}
