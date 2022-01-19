using System;
using System.Collections.Generic;

namespace DieOut.UI.Elements {
    
    public class EnumSwitcherControl : GenericSwitcherControl<Enum> {
        
        public EnumSwitcherControl(List<Enum> options) : base(options) { }
        
        public enum ExampleEnum {
            FirstExampleEnum,
            SecondExampleEnum,
            ThirdExampleEnum
        }
        
    }
    
}
