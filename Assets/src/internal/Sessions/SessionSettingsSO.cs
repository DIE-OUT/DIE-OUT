﻿using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace DieOut.Sessions {
    
    public class SessionSettingsSO : SerializedScriptableObject {
        
        [OdinSerialize] [LabelWidth(150)] public MinMaxDefault<int> MaxRounds { get; private set; }
        [OdinSerialize] [LabelWidth(150)] public MinMaxDefault<int> WinningScore { get; private set; }
        
    }
    
}
