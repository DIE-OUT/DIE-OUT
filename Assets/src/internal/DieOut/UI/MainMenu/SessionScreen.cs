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
    
    public class SessionScreen : MonoBehaviour {

        [SerializeField] private PlayerManager _playerManager;
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
            _sessionBuilder.Players = CreatePlayers();
            
            Session newSession = _sessionBuilder.Create();
            if(newSession == null)
                return;
            
            Session.SetNew(newSession);
            #pragma warning disable CS4014
            Session.Current.LoadRandomGameMode();
            #pragma warning restore CS4014
        }
        
        private Player[] CreatePlayers() {
            
            List<Player> players = new List<Player>();
            
            if(Keyboard.current != null && Mouse.current != null)
                players.Add(new Player(new InputDevice[] { Keyboard.current, Mouse.current }));
            
            for(int i = 0; i < Gamepad.all.Count; i++) {
                players.Add(new Player(new InputDevice[] { Gamepad.all[0] }));
            }
            
            return players.ToArray();
        }
        
    }
    
}
