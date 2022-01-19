using System;
using System.Collections.Generic;

namespace DieOut.UI.Elements {
    
    public class EnumSwitcherControl : GenericSwitcherControl<Enum> {
        
        public EnumSwitcherControl(List<Enum> options) : base(options) { }

        protected override List<Enum> GetDefaultOption() {
            return new List<Enum>() { ExampleEnum.FirstExampleEnum, ExampleEnum.SecondExampleEnum, ExampleEnum.ThirdExampleEnum };
        }

        public enum ExampleEnum {
            FirstExampleEnum,
            SecondExampleEnum,
            ThirdExampleEnum
        }
        
    }
    
}
