using Afired.GameManagement.GameModes;
using UnityEngine;

namespace DieOut.UI.QuickPlay {
    
    public class QuickMapSelectList : MonoBehaviour {
        
        [SerializeField] private GameObject _quickMapSelectHeaderPrefab;
        [SerializeField] private GameObject _quickMapSelectButtonPrefab;

        private void Awake() {

            foreach(GameMode gameMode in GameModeRegister.GameModes) {
                Instantiate(_quickMapSelectHeaderPrefab, transform).GetComponent<QuickMapSelectHeader>().Init(gameMode);
                foreach(Map map in gameMode.Maps) {
                    Instantiate(_quickMapSelectButtonPrefab, transform).GetComponent<QuickMapSelectButton>().Init(gameMode, map);
                }
            }
            
        }
        
    }
    
}
