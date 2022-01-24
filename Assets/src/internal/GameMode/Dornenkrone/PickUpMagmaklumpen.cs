using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.GameMode.Dornenkrone {
    
    [RequireComponent(typeof(CharacterController))]
    public class PickUpMagmaklumpen : MonoBehaviour {

        [SerializeField] Magmaklumpen _magmaklumpen;
        private CharacterController _characterController;
        private InputTable _inputTable;

        private bool _magmaklumpenInRange = false;

        private void Awake() {
            
            _inputTable = new InputTable();

            _inputTable.CharacterControls.PickUp.performed += OnPickUp;
            _characterController = GetComponent<CharacterController>();
        }

        private void OnEnable() {
            _inputTable.Enable();
        }

        private void OnDisable() {
            _inputTable.Disable();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.GetComponent<Magmaklumpen>() != null) {
                _magmaklumpenInRange = true;
            }
        }
        
        private void OnTriggerExit(Collider other) {
            if (other.GetComponent<Magmaklumpen>() != null) {
                _magmaklumpenInRange = false;
            }
        }

        private void OnPickUp(InputAction.CallbackContext _) {
            if (_magmaklumpenInRange == true) {
                _magmaklumpen.transform.parent = _characterController.transform;
            }
        }
    }
}
