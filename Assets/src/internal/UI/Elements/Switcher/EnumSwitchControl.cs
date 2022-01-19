using System;
using System.Collections.Generic;

namespace DieOut.UI.Elements {
    
    public class EnumSwitchControl<T> : SwitchControl<T> where T: Enum {

        public EnumSwitchControl() : base(new List<T>(EnumHelper.GetAllEnumValuesOfType<T>())) { }
        
        public EnumSwitchControl(List<T> options) : base(options) { }
        
    }

}
