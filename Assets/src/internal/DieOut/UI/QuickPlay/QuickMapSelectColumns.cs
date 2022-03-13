using Afired.GameManagement.GameModes;
using UnityEngine;

namespace DieOut.UI.QuickPlay {
    
    public class QuickMapSelectColumns : MonoBehaviour {
        
        [SerializeField] private GameObject _quickMapSelectListPrefab;
        
        private void Awake() {

            foreach(GameMode gameMode in GameModeRegister.GameModes) {
                Instantiate(_quickMapSelectListPrefab, transform).GetComponent<QuickMapSelectList>().Init(gameMode);
            }
            
        }
        
    }
    
}
