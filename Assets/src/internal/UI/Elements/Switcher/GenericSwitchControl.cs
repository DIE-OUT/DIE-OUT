using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace DieOut.UI.Elements {
    
    public class GenericSwitchControl<T> : ISwitchControl {
        
        public event OnValueChanged OnValueChanged;
        
        [OdinSerialize] [ListDrawerSettings(Expanded = true)] [DisableContextMenu]
        private List<T> _options;
        private int _currentIndex;
        private int CurrentIndex {
            get => _currentIndex;
            set {
                _currentIndex = value;
                ClampIndex();
                OnValueChanged?.Invoke(GetValue(), GetValueAsText());
            }
        }
        private Func<T, string> _getString;
        
        public void SetDefaultOptions() {
            _options = GetDefaultOption() ?? new List<T>() { default, default, default };
        }
        
        protected virtual List<T> GetDefaultOption() {
            return new List<T>() { default, default, default };
        }
        
        public GenericSwitchControl(List<T> options, Func<T, string> getString = null) {
            _getString = getString ?? (o => o.ToString());
            
            _options = options ?? new List<T>() { default, default, default };
        }
        
        public void Prev() {
            CurrentIndex--;
        }
        
        public void Next() {
            CurrentIndex++;
        }
        
        public void Select(object objectToSelect) {
            throw new NotImplementedException();
        }
        
        public void SelectIndex(int index) {
            CurrentIndex = index;
        }
        
        public object GetValue() {
            return _options[_currentIndex];
        }
        
        public string GetValueAsText() {
            return _options[_currentIndex].ToString();
        }

        private void ClampIndex() {
            _currentIndex = Mathf.Clamp(_currentIndex, 0, _options.Count - 1);
            Debug.Log("Clamped Index");
        }
        
    }
    
}
