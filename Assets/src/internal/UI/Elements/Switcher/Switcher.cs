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
        
        private ISwitcherControl _switchControl;
        [OdinSerialize] [InlineProperty] [HideReferenceObjectPicker] [HideLabel] [TypeFilter("GetFilteredTypes")] [PropertyOrder(-100)]
        private ISwitcherControl SwitchControl {
            get => _switchControl;
            set {
                _switchControl = value ?? new StringSwitcherControl(null);
                _switchControl.SetDefaultOptions();
            }
        }
        [Title("References")]
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Button _prevButton;
        [SerializeField] private Button _nextButton;

        private IEnumerable<Type> GetFilteredTypes() {
            return typeof(ISwitcherControl).Assembly.GetTypes().
                Where(x => !x.IsAbstract).
                Where(x => !x.IsGenericTypeDefinition).
                Where(x => typeof(ISwitcherControl).IsAssignableFrom(x));
        }
        
        private void Awake() {
            _prevButton.onClick.AddListener(Prev);
            _nextButton.onClick.AddListener(Next);
            _switchControl.OnValueChanged += Refresh;
            Refresh();
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
        
        public void Refresh() {
            _label.text = _switchControl.GetValueAsText();
        }
        
    }
    
}
