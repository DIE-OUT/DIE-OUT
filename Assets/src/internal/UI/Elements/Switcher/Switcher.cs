using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DieOut.UI.Elements {
    
    public class Switcher : SerializedMonoBehaviour {
        
        private SwitcherType _type;
        [OdinSerialize] [PropertyOrder(-100)] [HideInPlayMode]
        public SwitcherType Type {
            get => _type;
            set {
                _type = value;
                _switchControl = ConvertSwitcherTypeToISwitcherControl(value);
            }
        }
        [OdinSerialize] [InlineProperty] [HideReferenceObjectPicker] [HideLabel]
        private ISwitcherControl _switchControl;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Button _prevButton;
        [SerializeField] private Button _nextButton;
        
        
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
        
        private ISwitcherControl ConvertSwitcherTypeToISwitcherControl(SwitcherType switcherType) {
            switch(switcherType) {
                case SwitcherType.Int:
                    return new IntSwitcherControl(new List<int>() { 0, 1, 2 });
                case SwitcherType.String:
                    return new StringSwitcherControl(new List<string>() { "Option 1", "Option 2", "Option 3" });
                case SwitcherType.Enum:
                    return new EnumSwitcherControl(new List<Enum>() { EnumSwitcherControl.ExampleEnum.FirstExampleEnum, EnumSwitcherControl.ExampleEnum.SecondExampleEnum, EnumSwitcherControl.ExampleEnum.ThirdExampleEnum } );
                default:
                    return null;
            }
        }
        
    }
    
}
