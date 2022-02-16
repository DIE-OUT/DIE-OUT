using System;

namespace Afired.GameManagement.Characters {
    
    [AttributeUsage(AttributeTargets.Field)]
    public class NeedsComponentInChildren : Attribute {
        
        public Type[] Types;
        
        public NeedsComponentInChildren(params Type[] type) {
            Types = type;
        }
        
    }
    
}
