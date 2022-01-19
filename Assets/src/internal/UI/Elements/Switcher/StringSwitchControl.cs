using System.Collections.Generic;

namespace DieOut.UI.Elements {
    
    public class StringSwitchControl : GenericSwitchControl<string> {
        
        public StringSwitchControl(List<string> options) : base(options) { }

        protected override List<string> GetDefaultOption() {
            return new List<string>() { "Option 1", "Option 2", "Option 3" };
        }
        
    }
    
}
