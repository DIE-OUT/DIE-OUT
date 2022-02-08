using System.Collections.Generic;
using Afired.GameManagement.GameModes;
using Afired.GameManagement.Sessions;
using Afired.UI.Elements;
using DieOut.UI.CharacterSelect;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.UI.MainMenu {
    
    public class SessionSettingsScreen : MonoBehaviour {
        
        [SerializeField] [ReadOnly] public SessionBuilder SessionBuilder { get; private set; }
        [Required] [SerializeField] private SessionSettings _sessionSettings;
        [Required] [SerializeField] private Switcher _maxRoundsSwitcher;
        [Required] [SerializeField] private Switcher _winningScoreSwitcher;
        
        private void Awake() {
            SessionBuilder = new SessionBuilder();
            SessionBuilder.MaxRounds = _sessionSettings.MaxRounds.Default;
            SessionBuilder.WinningScore = _sessionSettings.WinningScore.Default;
            SessionBuilder.ActivatedGameModes.AddRange(GameModeRegister.GameModes);
            
            ISwitchControl maxRounds = new RangedIntSwitchControl(new RangedIntSwitchControl.Range<int>(_sessionSettings.MaxRounds.Min, _sessionSettings.MaxRounds.Max), _sessionSettings.MaxRounds.Default);
            maxRounds.OnValueChanged += (value, valueAsText) => SessionBuilder.MaxRounds = (int) value;
            _maxRoundsSwitcher.AssignControl(maxRounds);
            
            ISwitchControl winningScoreSwitchControl = new RangedIntSwitchControl(new RangedIntSwitchControl.Range<int>(_sessionSettings.WinningScore.Min, _sessionSettings.WinningScore.Max), _sessionSettings.WinningScore.Default);
            winningScoreSwitchControl.OnValueChanged += (value, valueAsText) => SessionBuilder.WinningScore = (int) value;
            _winningScoreSwitcher.AssignControl(winningScoreSwitchControl);
        }
        
    }
    
}
