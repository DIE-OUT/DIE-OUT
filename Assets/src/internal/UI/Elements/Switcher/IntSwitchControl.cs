using System;
using System.Collections.Generic;

namespace DieOut.UI.Elements {
    
    [Serializable]
    public class IntSwitchControl : GenericSwitchControl<int> {
        
        public IntSwitchControl(List<int> options) : base(options) { }

        protected override List<int> GetDefaultOption() {
            return new List<int>() { 0, 1, 2 };
        }
        
    }
    
}
