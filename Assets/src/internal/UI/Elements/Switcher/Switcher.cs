using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Afired.UI.Elements {
    
    public class Switcher : MonoBehaviour {
        
        private ISwitchControl _control;
        private ISwitchControl Control {
            get => _control ?? throw new Exception("There is no switch control assigned");
            set => _control = value;
        }
        [Title("References")]
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Button _prevButton;
        [SerializeField] private Button _nextButton;
        
        
        private void Awake() {
            _prevButton.onClick.AddListener(SelectPrev);
            _nextButton.onClick.AddListener(SelectNext);
        }
        
        public bool HasControl() {
            return !(_control is null);
        }
        
        public void AssignControl(ISwitchControl switchControl) {
            if(!(_control is null))
                Control.OnValueChanged -= UpdateLabel;
            Control = switchControl;
            if(!(switchControl is null)) {
                Control.OnValueChanged += UpdateLabel;
                UpdateLabel();
            }
        }
        
        public void SelectPrev() {
            Control.SelectPrev();
        }
        
        public void SelectNext() {
            Control.SelectNext();
        }
        
        private void UpdateLabel(object value, string valueAsText) {
            _label.text = valueAsText;
        }
        
        public void UpdateLabel() {
            _label.text = Control.GetValueAsText();
        }
        
    }
    
}
