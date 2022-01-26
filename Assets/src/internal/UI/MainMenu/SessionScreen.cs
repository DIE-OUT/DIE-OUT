using System;
using DieOut.GameMode.Management;
using DieOut.Sessions;
using DieOut.UI.Elements;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace DieOut.UI.MainMenu {
    
    public class SessionScreen : MonoBehaviour {
        
        [SerializeField] [ReadOnly] private SessionBuilder _sessionBuilder;
        [Required] [SerializeField] private SessionSettingsSO _sessionSettingsSo;
        [Required] [SerializeField] private Switcher _playerCountSwitcher;
        [Required] [SerializeField] private Switcher _maxRoundsSwitcher;
        [Required] [SerializeField] private Switcher _winningScoreSwitcher;
        
        private void Awake() {
            _sessionBuilder = new SessionBuilder();
            _sessionBuilder.MaxRounds = _sessionSettingsSo.MaxRounds.Default;
            _sessionBuilder.WinningScore = _sessionSettingsSo.WinningScore.Default;
            _sessionBuilder.ActivatedGameModes.AddRange(GameModeRegister.GameModes);
            
            ISwitchControl maxRounds = new RangedIntSwitchControl(new RangedIntSwitchControl.Range<int>(_sessionSettingsSo.MaxRounds.Min, _sessionSettingsSo.MaxRounds.Max), _sessionSettingsSo.MaxRounds.Default);
            maxRounds.OnValueChanged += (value, valueAsText) => _sessionBuilder.MaxRounds = (int) value;
            _maxRoundsSwitcher.AssignControl(maxRounds);
            
            ISwitchControl winningScoreSwitchControl = new RangedIntSwitchControl(new RangedIntSwitchControl.Range<int>(_sessionSettingsSo.WinningScore.Min, _sessionSettingsSo.WinningScore.Max), _sessionSettingsSo.WinningScore.Default);
            winningScoreSwitchControl.OnValueChanged += (value, valueAsText) => _sessionBuilder.WinningScore = (int) value;
            _winningScoreSwitcher.AssignControl(winningScoreSwitchControl);
        }

        public void TryToStartSession() {
            Session newSession = _sessionBuilder.Create();
            if(newSession == null)
                return;
            
            Sessions.Sessions.SetNew(newSession);
            Sessions.Sessions.Current.GoNext();
        }
        
    }
    
}
