using System;
using Afired.GameManagement.Sessions;
using TMPro;
using UnityEngine;

namespace DieOut.UI.Scoreboard {
    
    public class ScoreboardPlayerEntry : MonoBehaviour {

        private Player _player;
        [SerializeField] private TMP_Text _playersIdentificationText;
        [SerializeField] private TMP_Text _playersScoreText;


        public void Init(Player player) {
            if(_player != null)
                throw new Exception("this scoreboard cant be initialized more than once");
            _player = player;
            Refresh();
        }

        private void Refresh() {
            if(_player is null)
                throw new Exception("scoreboard player entry is refreshed without a player assigned");
            _playersIdentificationText.text = _player.InputDevices[0].displayName;
            _playersScoreText.text = _player.Score.ToString();
        }
        
    }
    
}
