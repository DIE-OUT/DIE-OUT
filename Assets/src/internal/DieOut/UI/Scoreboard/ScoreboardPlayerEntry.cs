using System;
using Afired.GameManagement.Sessions;
using TMPro;
using UnityEngine;

namespace DieOut.UI.Scoreboard {
    
    public class ScoreboardPlayerEntry : MonoBehaviour {
        
        private Player _player;
        [SerializeField] private TMP_Text _playersIdentificationText;
        [SerializeField] private TMP_Text _playersScoreText;
        [SerializeField] private ScoreboardScoreIconList _scoreboardScoreIconList;
        [SerializeField] private ScoreboardPlayerPlacementIndicator _scoreboardPlayerPlacementIndicator;
        private int _placement;
        
        
        public void Init(Player player, int placement) {
            if(_player != null)
                throw new Exception("this scoreboard cant be initialized more than once");
            _player = player;
            _placement = placement;
            player.OnScoreChanged += Refresh;
            Refresh();
        }
        
        private void Refresh() {
            if(_player is null)
                throw new Exception("scoreboard player entry is refreshed without a player assigned");
            _playersIdentificationText.text = _player.DisplayName;
            if(_playersScoreText != null)
                _playersScoreText.text = _player.Score.ToString();
            if(_scoreboardScoreIconList != null)
                _scoreboardScoreIconList.SetScore(_player.Score);
            if(_scoreboardPlayerPlacementIndicator != null)
                _scoreboardPlayerPlacementIndicator.SetPlacement(_placement);
        }
        
    }
    
}
