using System.Collections;
using System.Collections.Generic;
using DieOut.GameModes.Interactions;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using Afired.GameManagement.GameModes;

namespace DieOut.GameModes.Dornenkrone {
    public class PickUpSpeed : MonoBehaviour {
        
        private SpeedPickUp _speedPickUp;
        [SerializeField] private float _speedDuration = 5;
        private int _amountOfCollectedSpeedPickUps = 0;

        private void OnTriggerEnter(Collider other) {
            _speedPickUp = other.GetComponent<SpeedPickUp>();

            if (_speedPickUp != null) {
                _amountOfCollectedSpeedPickUps += 1;
                StartCoroutine(SpeedDuration());
                Destroy(_speedPickUp.gameObject);
            }
        }

        private IEnumerator SpeedDuration() {
            GetComponent<PlayerControls>()._movementSpeed = 10;
            yield return new WaitForSeconds(_speedDuration);
            _amountOfCollectedSpeedPickUps -= 1;
            
            if (_amountOfCollectedSpeedPickUps == 0) {
                GetComponent<PlayerControls>()._movementSpeed -= 4;
            }
        }
    }
}