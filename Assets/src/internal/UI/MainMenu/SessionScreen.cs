using DieOut.GameModes.Management;
using DieOut.Sessions;
using DieOut.UI.Elements;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace DieOut.UI.MainMenu {
    
    public class SessionScreen : MonoBehaviour {
        
        [SerializeField] [ReadOnly] private SessionBuilder _sessionBuilder;
        [Required] [SerializeField] private SessionSettings _sessionSettings;
        [Required] [SerializeField] private Switcher _maxRoundsSwitcher;
        [Required] [SerializeField] private Switcher _winningScoreSwitcher;
        
        private void Awake() {
            _sessionBuilder = new SessionBuilder();
            _sessionBuilder.MaxRounds = _sessionSettings.MaxRounds.Default;
            _sessionBuilder.WinningScore = _sessionSettings.WinningScore.Default;
            _sessionBuilder.ActivatedGameModes.AddRange(GameModeRegister.GameModes);
            
            ISwitchControl maxRounds = new RangedIntSwitchControl(new RangedIntSwitchControl.Range<int>(_sessionSettings.MaxRounds.Min, _sessionSettings.MaxRounds.Max), _sessionSettings.MaxRounds.Default);
            maxRounds.OnValueChanged += (value, valueAsText) => _sessionBuilder.MaxRounds = (int) value;
            _maxRoundsSwitcher.AssignControl(maxRounds);
            
            ISwitchControl winningScoreSwitchControl = new RangedIntSwitchControl(new RangedIntSwitchControl.Range<int>(_sessionSettings.WinningScore.Min, _sessionSettings.WinningScore.Max), _sessionSettings.WinningScore.Default);
            winningScoreSwitchControl.OnValueChanged += (value, valueAsText) => _sessionBuilder.WinningScore = (int) value;
            _winningScoreSwitcher.AssignControl(winningScoreSwitchControl);
        }

        public void TryToStartSession() {
            Session newSession = _sessionBuilder.Create();
            if(newSession == null)
                return;
            
            Session.SetNew(newSession);
            Session.Current.GoNext();
        }
        
    }
    
}
