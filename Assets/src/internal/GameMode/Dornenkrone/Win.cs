using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DieOut.GameMode.Interactions;
using DieOut.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

// die ganze Klasse wird probably nochmal anders geschrieben werden
namespace DieOut.GameMode.Dornenkrone {
    public class Win : MonoBehaviour {
        // ! statt [SerializeField] sollten alle Objects in der Szene mit dem type of Movable automatisch gefunden und in die Liste gefügt werden
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
