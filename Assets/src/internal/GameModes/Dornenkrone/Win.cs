using System.Collections.Generic;
using System.Linq;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace DieOut.GameModes.Dornenkrone {
    
    public class Win : MonoBehaviour {
        
        private List<Movable> _players;
        private Movable _anyPlayer;
        private Movable _deadPlayer;
        //[SerializeField] private SceneField _levelSelectScene;

        private void Update() {
            if (_players == null || _players.Count == 0) {
                _players = FindObjectsOfType<Movable>().ToList();
            }
            
            if (CheckHealth()) {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        private bool CheckHealth() {
            if (_players.Any(player => player.GetComponent<Health>()._health <= 0)) {
                foreach (Movable _player in _players) {
                    float health = _player.GetComponent<Health>()._health;
                    if (health <= 0) {
                        _deadPlayer = _player;
                    }
                }
                return true;
            }
            else {
                return false;
            }
        }

        /*public void LoadLevelSelect() {
            UnityEngine.SceneManagement.SceneManager.LoadScene(_levelSelectScene.SceneName);
        }*/
        
    }
    
}
