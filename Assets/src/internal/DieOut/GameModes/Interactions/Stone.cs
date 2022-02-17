using System.Collections;
using System.Collections.Generic;
using DieOut.GameModes.Interactions;
using UnityEngine;
using DieOut.GameModes.Dornenkrone;

namespace DieOut.GameModes.Interactions {
    public class Stone : Throwable {
        
        private Tackleable _tackleable;
        private Magmaklumpen _magmaklumpen;
        
        // Wenn man einen Enemy mit Stein hitted, geht dessen Magmaklumpen auf den Werfer über bzw lässt dieser seinen Stein fallen
        private void OnCollisionEnter(Collision collision) {
            _enemyPlayer = collision.gameObject.GetComponent<Movable>();

            if (_enemyPlayer != null && !_attachedToPlayer) {
                _tackleable = _enemyPlayer.GetComponent<Tackleable>();
                    
                if (!_tackleable._ccImmunity) {
                    _tackleable.TriggerCC_Immunity();
                    _tackleable.TriggerThrowableStun();
                    _magmaklumpen = _enemyPlayer.GetComponentInChildren<Magmaklumpen>();

                    if (_magmaklumpen != null) {
                        _itemPosition = _player.GetComponentInChildren<ItemPosition>();
                        _magmaklumpen.transform.parent = _itemPosition.transform;
                        _magmaklumpen.transform.position = _itemPosition.transform.position;
                    }
                }

                _throwable = _enemyPlayer.GetComponentInChildren<Throwable>();

                if (_throwable != null) {
                    _throwable._attachedToPlayer = false;
                }
                    
                Destroy(this.gameObject);
            }
        }
    }
}
