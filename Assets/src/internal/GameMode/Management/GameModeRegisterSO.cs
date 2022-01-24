using System.Collections.Generic;
using UnityEngine;

namespace DieOut.GameMode.Management {
    
    [CreateAssetMenu]
    public class GameModeRegisterSO : ScriptableObject {

        [SerializeField] public List<GameMode> GameModes;

    }
    
}
