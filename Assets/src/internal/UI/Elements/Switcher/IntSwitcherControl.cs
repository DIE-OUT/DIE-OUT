using System;
using System.Collections.Generic;

namespace DieOut.UI.Elements {
    
    [Serializable]
    public class IntSwitcherControl : GenericSwitcherControl<int> {
        
        public IntSwitcherControl(List<int> options) : base(options) { }
        
    }
    
}
