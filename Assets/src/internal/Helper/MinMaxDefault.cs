using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace DieOut.Helper {
    
    [Serializable]
    [InlineProperty(LabelWidth = 50)]
    public struct MinMaxDefault<T> {
        
        [OdinSerialize] [HorizontalGroup] public T Min { get; private set; }
        [OdinSerialize] [HorizontalGroup] public T Default { get; private set; }
        [OdinSerialize] [HorizontalGroup] public T Max { get; private set; }
        
    }
    
}
