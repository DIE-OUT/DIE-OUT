﻿using System;
using System.Collections.Generic;

namespace DieOut.UI.Elements {
    
    public class EnumSwitchControl<T> : SwitchControl<T> where T: Enum {
        
        public EnumSwitchControl() : base(EnumHelper.GetAllEnumValuesOfType<T>()) { }
        
        public EnumSwitchControl(IEnumerable<T> options) : base(options) { }
        
    }
    
}
