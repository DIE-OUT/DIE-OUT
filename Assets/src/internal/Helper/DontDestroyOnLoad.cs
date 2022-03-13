using UnityEngine;

namespace Afired.Helper {
    
    public class DontDestroyOnLoad : MonoBehaviour {
        
        private void Awake() {
            DontDestroyOnLoad(gameObject);
        }
        
    }
    
}
