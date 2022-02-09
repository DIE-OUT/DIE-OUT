using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Afired.UI {
    
    [RequireComponent(typeof(EventSystem))]
    public class SelectUIElementOnEnable : MonoBehaviour {
        
        [SerializeField] private GameObject _uiElement;
        private EventSystem _eventSystem;


        private void Awake() {
            _eventSystem = GetComponent<EventSystem>();
        }
        
        private void OnEnable() {
            _eventSystem.SetSelectedGameObject(_uiElement);
            _uiElement.GetComponent<Selectable>().OnSelect(new BaseEventData(_eventSystem));
        }
        
    }
    
}
