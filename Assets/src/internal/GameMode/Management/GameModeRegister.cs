using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.GameMode.Management {
    
    public class GameModeRegister : MonoBehaviour {

        [Required]
        [SerializeField] private GameModeRegisterSO _gameModeRegisterSo;

        public List<GameMode> GameModes => _gameModeRegisterSo.GameModes;

    }
    
}
