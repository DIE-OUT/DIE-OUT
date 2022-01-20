using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

namespace DieOut.GameMode.Interactions {
    [RequireComponent(typeof(Collider))]
    public class Tackle : MonoBehaviour {
        private Tackleable _tackleable;
        private PlayerController _playerController;

        private InputTable _inputTable;

        [SerializeField] private float cooldown;
        [SerializeField] private float stunDuration;
        [SerializeField] private float immunity;

        private bool _inTackleRange;
        private bool _inCooldown = false;
        [SerializeField] private int damage;

        private List<GameObject> _otherPlayers = new List<GameObject>();

        private void Awake() {
            _inputTable = new InputTable();

            _inputTable.CharacterControls.Tackle.performed += Tackling;
        }
        
        void Start() {
            _tackleable = FindObjectOfType<Tackleable>();
            _playerController = FindObjectOfType<PlayerController>();
        }

        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                Debug.Log("in tackle range");
                _inTackleRange = true;
                _otherPlayers.Add(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.CompareTag("Player")) {
                _otherPlayers.Remove(other.gameObject);
                if (_otherPlayers.Count == 0) {
                    Debug.Log("not in tackle range");
                    _inTackleRange = false;
                }
            }
        }

        IEnumerator TackleCooldown() {
            yield return new WaitForSeconds(cooldown);
            Debug.Log("cooldown finished");
            _inCooldown = false;
        }

        IEnumerator TackleStunDuration() {
            yield return new WaitForSeconds(stunDuration);
            Debug.Log("tackle stopped");
            _otherPlayers[0].GetComponent<PlayerController>()._movementSpeed = 5;
            _otherPlayers[0].GetComponent<PlayerController>()._jumpForce = 15;
        }

        IEnumerator TackleImmunity() {
            yield return new WaitForSeconds(stunDuration + immunity);
            Debug.Log("tackle immunity OFF");
            _otherPlayers[0].GetComponent<Tackleable>().tackleImmunity = false;
        }

        private void TackleDamage(int dmg) {
            damage = dmg;
            _otherPlayers[0].GetComponent<Tackleable>().health -= damage;
        }

        private void Tackling(InputAction.CallbackContext _) {
            // sort List according to distance from Player, then take only first element in List
            _otherPlayers = _otherPlayers.OrderBy(
                x => Vector2.Distance(this.transform.parent.position,x.transform.position)
            ).ToList();
            
            if (_inTackleRange == true && _inCooldown == false && _otherPlayers[0].GetComponent<Tackleable>().tackleImmunity == false) {
                Debug.Log("tackling");

                // displacement fuktioniert nicht for some reason :(
                
                    /*Vector3 a = transform.parent.position;
                    Vector3 b = x.transform.position;
                    Debug.Log(transform.parent.position.x);
                    //transform.parent.position= Vector3.MoveTowards(a, b, 1);
                    a = Vector3.back;
                    b.x -= 1;*/

                transform.parent.position = _otherPlayers[0].transform.position;

                _otherPlayers[0].GetComponent<PlayerController>()._movementSpeed = 0;
                _otherPlayers[0].GetComponent<PlayerController>()._jumpForce = 0;
                
                TackleDamage(damage);
                _inCooldown = true;
                Debug.Log("in cooldown");
                StartCoroutine(TackleCooldown());
                _otherPlayers[0].GetComponent<Tackleable>().tackleImmunity = true;
                Debug.Log("tackle immunity ON");
                StartCoroutine(TackleImmunity());
                StartCoroutine(TackleStunDuration());
            }
        }
    }
}