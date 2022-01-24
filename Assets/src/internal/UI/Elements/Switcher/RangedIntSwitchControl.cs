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
        private Func<int, string> _getString;
        
        
        public RangedIntSwitchControl(Range<int> range, int startingValue, Func<int, string> getString = null) {
            _getString = getString ?? (o => o.ToString());
            _range = range;
            CurrentValue = startingValue;
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
            return _getString(CurrentValue);
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
