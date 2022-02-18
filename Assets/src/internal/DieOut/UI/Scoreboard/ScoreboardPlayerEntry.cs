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
        [SerializeField] private GameObject _firstPlaceIndicator;
        private bool _isFirstPlace;
        
        
        public void Init(Player player, bool isFirstPlace) {
            if(_player != null)
                throw new Exception("this scoreboard cant be initialized more than once");
            _player = player;
            _isFirstPlace = isFirstPlace;
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
            if(_firstPlaceIndicator != null)
                _firstPlaceIndicator.SetActive(_isFirstPlace);
        }
        
    }
    
}
