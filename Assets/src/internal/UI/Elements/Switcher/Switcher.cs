using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DieOut.UI.Elements {
    
    public class Switcher : MonoBehaviour {
        
        private ISwitchControl _switchControl;
        private ISwitchControl SwitchControl {
            get => _switchControl ?? throw new Exception("There is no switch control assigned");
            set => _switchControl = value;
        }
        [Title("References")]
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Button _prevButton;
        [SerializeField] private Button _nextButton;
        
        private IEnumerable<Type> GetFilteredTypes() {
            return typeof(ISwitchControl).Assembly.GetTypes().
                Where(x => !x.IsAbstract).
                Where(x => !x.IsGenericTypeDefinition).
                Where(x => typeof(ISwitchControl).IsAssignableFrom(x));
        }
        
        private void Awake() {
            _prevButton.onClick.AddListener(Prev);
            _nextButton.onClick.AddListener(Next);
        }

        public void AssignSwitchControl(ISwitchControl switchControl) {
            if(!(_switchControl is null))
                SwitchControl.OnValueChanged -= UpdateLabel;
            SwitchControl = switchControl;
            if(!(switchControl is null)) {
                SwitchControl.OnValueChanged += UpdateLabel;
                UpdateLabel();
            }
        }
        
        public void Prev() {
            SwitchControl.SelectPrev();
        }
        
        public void Next() {
            SwitchControl.SelectNext();
        }
        
        private void UpdateLabel(object value, string valueAsText) {
            _label.text = valueAsText;
        }
        
        public void UpdateLabel() {
            _label.text = SwitchControl.GetValueAsText();
        }
        
    }
    
}
