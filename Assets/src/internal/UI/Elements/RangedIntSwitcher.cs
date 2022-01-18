using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using TMPro;

namespace DieOut.UI.Elements {
    
    public class RangedIntSwitcher : MonoBehaviour {
        
        [SerializeField] private TMP_Text _label;
        
        [SerializeField] private IntRange _range = new IntRange(-10, 10);
        public IntRange Range {
            get => _range;
            set {
                _range = value;
                Value = Value;
            }
        }
        [SerializeField] private int _value;
        private int Value {
            get => _value;
            set {
                if(value < _range.Min)
                    _value = _range.Min;
                else if(value > _range.Max)
                    _value = _range.Max;
                else
                    _value = value;
                Refresh();
            }
        }

        private void Awake() {
            Value = Value;
        }
        
        public void Next() {
            Value++;
        }
        
        public void Prev() {
            Value--;
        }
        
        private void Refresh() {
            _label.text = Value.ToString();
        }
        
        [InlineProperty]
        [Serializable]
        public struct IntRange {
            [SerializeField] public int Min;
            [SerializeField] public int Max;

            public IntRange(int min, int max) {
                Min = min;
                Max = max;
            }
            
        }
        
    }
    
}
