using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Afired.UI.Elements {
    
    public class SwitchControl<T> : ISwitchControl {
        
        public event OnValueChanged OnValueChanged;
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
        
        public SwitchControl([NotNull] IEnumerable<T> options, T startingValue, Func<T, string> getString = null) {
            _getString = getString ?? (o => o.ToString());
            _options = new List<T>(options);
            Select(startingValue);
        }
        
        public void SelectFirst() {
            CurrentIndex = 0;
        }
        
        public void SelectPrev() {
            CurrentIndex--;
        }
        
        public void SelectNext() {
            CurrentIndex++;
        }
        
        public void SelectLast() {
            CurrentIndex = _options.Count - 1;
        }
        
        public void Select(T option) {
            CurrentIndex = _options.FindIndex(0, _options.Count, t => t.Equals(option));
        }
        
        public void SelectAt(int index) {
            CurrentIndex = index;
        }
        
        public object GetValue() {
            return _options[CurrentIndex];
        }
        
        public string GetValueAsText() {
            return _getString(_options[CurrentIndex]);
        }

        private void ClampIndex() {
            _currentIndex = Mathf.Clamp(_currentIndex, 0, _options.Count - 1);
        }
        
    }
    
}
