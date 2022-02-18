using UnityEngine;
using UnityEngine.UI;

namespace DieOut.UI.Scoreboard {
    
    [RequireComponent(typeof(Image))]
    public class ScoreboardPlayerPlacementIndicator : MonoBehaviour {
        
        [SerializeField] private Sprite[] _placementIcons;
        private Image _image;
        
        
        private void Awake() {
            _image = GetComponent<Image>();
        }

        public void SetPlacement(int placement) {
            if(placement < _placementIcons.Length)
                _image.sprite = _placementIcons[placement];
            else
                _image.enabled = false;
        }
        
    }
    
}
