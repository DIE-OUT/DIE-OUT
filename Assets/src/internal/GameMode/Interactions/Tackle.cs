using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine;

namespace DieOut.GameMode.Interactions {
    
    [RequireComponent(typeof(Collider))]
    public class Tackle : MonoBehaviour {
        
        [SerializeField] private DeviceTypes _deviceTypes;
        private InputTable _inputTable;
        
        [SerializeField] private Movable _movable;
        private List<Tackleable> _otherPlayers = new List<Tackleable>();
        [SerializeField] private List<Tackleable> _tackleablesToIgnore;
        
        [SerializeField] private float _cooldown = 3f;
        private bool _onCooldown;

        private void Awake() {
            _inputTable = new InputTable();
            
            if(_deviceTypes == DeviceTypes.Gamepad)
                _inputTable.devices = new[] { Gamepad.all[0] };
            else if(_deviceTypes == DeviceTypes.Keyboard)
                _inputTable.devices = new InputDevice[] { Keyboard.current, Mouse.current };
            
            _inputTable.CharacterControls.Tackle.performed += OnTackle;
        }

        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }

        private void OnTriggerEnter(Collider other) {
            Tackleable tackleableComponent = other.gameObject.GetComponent<Tackleable>();
            
            if(tackleableComponent != null && !_tackleablesToIgnore.Contains(tackleableComponent)) {
                _otherPlayers.Add(tackleableComponent);
            }
        }

        private void OnTriggerExit(Collider other) {
            Tackleable tackleableComponent = other.gameObject.GetComponent<Tackleable>();
            
            if(tackleableComponent != null && !_tackleablesToIgnore.Contains(tackleableComponent)) {
                _otherPlayers.Remove(tackleableComponent);
            }
        }

        private IEnumerator TackleCooldown() {
            yield return new WaitForSeconds(_cooldown);
            Debug.Log("cooldown finished");
            _onCooldown = false;
        }

        private void OnTackle(InputAction.CallbackContext _) {
            // dont do anything if tackle is on cooldown
            if(_onCooldown) {
                Debug.Log("tackle has cooldown");
                return;
            }
            
            // sort list according to distance from Player, exclude the once that have tackle immunity and then take first element in list
            Tackleable target = _otherPlayers
                .OrderBy(x => Vector2.Distance(this.transform.parent.position, x.transform.position)).
                FirstOrDefault(tackleable => !tackleable.tackleImmunity);
            
            // dont do anything if there is no target to tackle
            if(target == null) {
                Debug.Log("no tackelable target is in range");
                return;
            }
            
            // falls irgendwann mal was anderes als Player getackled werden soll, könnte hier auch nur eine Position übergeben werden
            target.TriggerTackle(_movable);

            if (_movable != null) {
                // ! Sollte so weit mit dem Tackle kommen, dass er mit seinem Ziel collided
                _movable.AddVelocity((target.transform.position - transform.position).normalized / 10);
                
                // für Tackle in eine Richtung
                //_movable.AddVelocity(Vector3.forward.normalized / 10);
            }

            _onCooldown = true;
            StartCoroutine(TackleCooldown());
        }
        
    }
    
}
