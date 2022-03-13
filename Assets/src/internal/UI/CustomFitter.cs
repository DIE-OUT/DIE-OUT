using System.Collections;
using UnityEngine;

namespace Afired.UI {
    
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    public class CustomFitter : MonoBehaviour {

        [SerializeField] private RectTransform _otherRectTransform;
        private RectTransform _thisRectTransform;

        [SerializeField] private Rect _rectOffset;
        
        private void Awake() {
            _thisRectTransform = GetComponent<RectTransform>();
        }
        
        [ExecuteAlways]
        private void Update() {
            if(_otherRectTransform == null) {
                Debug.Log("referenced rect transform cant be null");
                return;
            }
            if(_otherRectTransform == _thisRectTransform) {
                Debug.Log("referenced rect transform cant be its own");
                return;
            }

            _thisRectTransform.pivot = _otherRectTransform.pivot;
            _thisRectTransform.sizeDelta = _otherRectTransform.sizeDelta + _rectOffset.size;
            _thisRectTransform.anchoredPosition = _otherRectTransform.anchoredPosition;
        }
        
    }
    
}
