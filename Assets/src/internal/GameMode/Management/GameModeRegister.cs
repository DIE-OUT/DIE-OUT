using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace DieOut.GameMode.Management {
    
    public class GameModeRegister : SerializedMonoBehaviour {
        
        [OdinSerialize] public List<GameMode> GameModes { get; private set; } = new List<GameMode>();
        
    }
    
}
