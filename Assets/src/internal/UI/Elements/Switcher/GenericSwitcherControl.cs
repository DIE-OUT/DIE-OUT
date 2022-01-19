using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Unity.Mathematics;
using UnityEngine;

namespace DieOut.UI.Elements {
    
    public class GenericSwitcherControl<T> : ISwitcherControl {
        
        public event OnValueChanged OnValueChanged;
        private List<T> _options;
        [OdinSerialize] [ListDrawerSettings(Expanded = true)] [DisableContextMenu]
        public List<T> Options {
            get => _options;
            set {
                _options = value;
                ClampIndex();
                OnValueChanged?.Invoke();
            }
        }
        private int _currentIndex;
        private int CurrentIndex {
            get => _currentIndex;
            set {
                _currentIndex = value;
                ClampIndex();
                OnValueChanged?.Invoke();
            }
        }
        private Func<T, string> _getString;
        
        public GenericSwitcherControl(List<T> options, Func<T, string> getString = null) {
            _getString = getString ?? (o => o.ToString());
            
            Options = options;
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
            return Options[_currentIndex];
        }
        
        public string GetValueAsText() {
            return Options[_currentIndex].ToString();
        }

        private void ClampIndex() {
            _currentIndex = Mathf.Clamp(_currentIndex, 0, Options.Count - 1);
            Debug.Log("Clamped Index");
        }
        
    }
    
}
