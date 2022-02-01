using System;
using Afired.Helper;

namespace Afired.UI.Elements {
    
    public class EnumSwitchControl<T> : SwitchControl<T> where T: Enum {
        
        public EnumSwitchControl(T startingEnum) : base(EnumHelper.GetAllEnumValuesOfType<T>(), startingEnum) { }
        
        //public EnumSwitchControl(IEnumerable<T> options) : base(options) { }
        
    }
    
}
