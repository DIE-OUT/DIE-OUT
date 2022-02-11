using System;
using Afired.GameManagement;
using Afired.GameManagement.Sessions;
using DieOut.GameModes.Interactions;
using UnityEngine;
using UnityEngine.UI;

namespace DieOut.GameModes {
    
    public delegate void OnDeath(Player player);
    
    public class Health : MonoBehaviour, IPlayerReceiver {

        public event OnDeath OnDeath;
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private PlayerControls _playerControls;
        private float _health = 100;
        private Player _player;
        public bool IsDead { get; private set; }

        public Slider _healthbar;

        private void Awake() {
            _health = _maxHealth;
        }

        private void Start() {
            _healthbar.value = CalculateHealth();
        }

        private void Update() {
            _healthbar.value = CalculateHealth();
        }

        private float CalculateHealth() {
            return _health / _maxHealth;
        }
        
        public void TriggerDamage(float damage) {
            _health -= damage;
            if(_health <= 0 && !IsDead) {
                OnDeath?.Invoke(_player);
                IsDead = true;
                if(_playerControls != null)
                    _playerControls.HasControl = false;
            }
        }

        public void SetPlayer(Player player) {
            _player = player;
        }
        
    }
    
}
