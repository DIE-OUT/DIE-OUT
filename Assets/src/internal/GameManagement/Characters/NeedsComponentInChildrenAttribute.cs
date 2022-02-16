using System;

namespace Afired.GameManagement.Characters {
    
    public class NeedsComponentInChildren : Attribute {
        
        public Type[] Types;
        
        public NeedsComponentInChildren(params Type[] type) {
            Types = type;
        }
        
    }
    
}
