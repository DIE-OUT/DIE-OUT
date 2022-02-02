using Afired.GameManagement;
using Afired.GameManagement.Sessions;
using UnityEngine;

namespace DieOut.GameModes {
    
    public delegate void OnDeath(Player player);
    
    public class Health : MonoBehaviour, IPlayerReceiver {

        public event OnDeath OnDeath;
        [SerializeField] private float _health = 100;
        private Player _player;
        public bool IsDead { get; private set; }
        
        
        public void TriggerDamage(float damage) {
            _health -= damage;
            if(_health <= 0 && !IsDead) {
                OnDeath?.Invoke(_player);
                IsDead = true;
            }
        }

        public void SetPlayer(Player player) {
            _player = player;
        }
        
    }
    
}
