using System.Collections.Generic;

namespace DieOut.UI.Elements {
    
    public class StringSwitcherControl : GenericSwitcherControl<string> {
        
        public StringSwitcherControl(List<string> options) : base(options) { }

        protected override List<string> GetDefaultOption() {
            return new List<string>() { "Option 1", "Option 2", "Option 3" };
        }
        
    }
    
}
