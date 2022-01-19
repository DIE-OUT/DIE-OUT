using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DieOut.UI.Elements {
    
    public class Switcher : SerializedMonoBehaviour {
         
        private ISwitchControl _switchControl;
        [OdinSerialize] [InlineProperty] [HideReferenceObjectPicker] [HideLabel] [TypeFilter("GetFilteredTypes")] [PropertyOrder(-100)] [HideInPlayMode]
        private ISwitchControl SwitchControl {
            get => _switchControl;
            set {
                _switchControl = value ?? new StringSwitchControl(null);
                _switchControl.SetDefaultOptions();
            }
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
            _switchControl.OnValueChanged += Refresh;
        }

        public void SetSwitchControl<T>(GenericSwitchControl<T> switchControl) {
            if(_switchControl != null)
                _switchControl.OnValueChanged -= Refresh;
            _switchControl = switchControl;
            _switchControl.OnValueChanged += Refresh;
            RefreshManually();
        }
        
        public object GetValue() {
            return _switchControl.GetValue();
        }
        
        public void Prev() {
            _switchControl.Prev();
        }
        
        public void Next() {
            _switchControl.Next();
        }
        
        private void Refresh(object value, string valueAsText) {
            _label.text = valueAsText;
        }

        public void RefreshManually() {
            _label.text = _switchControl.GetValueAsText();
        }
        
    }
    
}
