using Afired.GameManagement.GameModes;
using UnityEngine;

namespace DieOut.UI.QuickPlay {
    
    public class QuickMapSelectList : MonoBehaviour {
        
        [SerializeField] private GameObject _quickMapSelectHeaderPrefab;
        [SerializeField] private GameObject _quickMapSelectButtonPrefab;

        public void Init(GameMode gameMode) {
            Instantiate(_quickMapSelectHeaderPrefab, transform).GetComponent<QuickMapSelectHeader>().Init(gameMode);
            foreach(Map map in gameMode.Maps) {
                Instantiate(_quickMapSelectButtonPrefab, transform).GetComponent<QuickMapSelectButton>().Init(gameMode, map);
            }
        }
        
    }
    
}
