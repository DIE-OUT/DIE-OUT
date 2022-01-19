using System;

namespace DieOut.UI.Elements {
    
    public class RangedIntSwitchControl : ISwitchControl {
        
        public event OnValueChanged OnValueChanged;
        private int _currentValue;
        private int CurrentValue {
            get => _currentValue;
            set {
                _currentValue = value;
                ClampCurrentValue();
                OnValueChanged?.Invoke(GetValue(), GetValueAsText());
            }
        }
        private Range<int> _range;
        
        
        public RangedIntSwitchControl(Range<int> range) {
            _range = range;
            _currentValue = range.Min;
        }

        public void SelectFirst() {
            CurrentValue = _range.Min;
        }
        
        public void SelectPrev() {
            CurrentValue--;
        }

        public void SelectNext() {
            CurrentValue++;
        }

        public void SelectLast() {
            CurrentValue = _range.Max;
        }
        
        public void Set(int value) {
            CurrentValue = value;
        }
        
        public object GetValue() {
            return CurrentValue;
        }

        public string GetValueAsText() {
            return CurrentValue.ToString();
        }
        
        public struct Range<T> where T : IComparable {
            public T Min;
            public T Max;

            public Range(T min, T max) {
                Min = min;
                Max = max;
            }
        }
        
        private void ClampCurrentValue() {
            if(_currentValue > _range.Max)
                _currentValue = _range.Max;
            if(_currentValue < _range.Min)
                _currentValue = _range.Min;
        }
        
    }
    
}
