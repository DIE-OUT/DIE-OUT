using System.Collections.Generic;
using System.Linq;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace DieOut.GameModes.Dornenkrone {
    
    public class Win : MonoBehaviour {
        
        private List<Movable> _players;
        [SerializeField] private SceneField _levelSelectScene;
        
        private void Awake() {
            _players = FindObjectsOfType<Movable>().ToList();
        }

        private void Update() {
            if (CheckHealth()) {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        private bool CheckHealth() {
            return _players.Any(player => player._health <= 0);
        }

        public void LoadLevelSelect() {
            UnityEngine.SceneManagement.SceneManager.LoadScene(_levelSelectScene.SceneName);
        }
        
    }
    
}
