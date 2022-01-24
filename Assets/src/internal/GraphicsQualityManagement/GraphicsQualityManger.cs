using System;
using DieOut.Helper;
using UnityEngine;

namespace DieOut.GraphicsQualityManagement {
    
    public class GraphicsQualityManger : MonoBehaviour {

        public static int CurrentGraphicsQualityLevelIndex => QualitySettings.GetQualityLevel();
        public static string GetGraphicsQualityLevelNameByIndex(int index) => QualitySettings.names[index];
        public static int GraphicsLevelCount => QualitySettings.names.Length;
        private static SingletonInstance<GraphicsQualityManger> _instance;
        
        
        private void Awake() {
            _instance.Init(this);
        }
        
        public static void SetGraphicsQualityLevel(int index) {
            QualitySettings.SetQualityLevel(index);
        }
        
    }
    
}
