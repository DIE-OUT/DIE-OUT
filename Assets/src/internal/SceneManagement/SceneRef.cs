using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Afired.SceneManagement {
    
    [Serializable]
    public class SceneRef {
        
        public string SceneName => _sceneName;
        [SerializeField] private Object _sceneAsset;
        [SerializeField] private string _sceneName = "";
        
        // makes it work with the existing Unity methods (LoadLevel/LoadScene)
        public static implicit operator string(SceneRef sceneRef) {
            return sceneRef.SceneName;
        }
        
    }
    
}