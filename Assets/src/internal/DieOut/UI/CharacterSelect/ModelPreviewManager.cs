using Afired.GameManagement.Characters;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.UI.CharacterSelect {
    
    public class ModelPreviewManager : SerializedMonoBehaviour {
        
        [SerializeField] private float _rotationSpeed = 10f;
        [SerializeField] private GameObject _previewModelGameObjectNone;
        private GameObject _proceduralSpawnedPreviewModel;
        
        private void Update() {
            transform.Rotate(Vector3.up, Time.deltaTime * _rotationSpeed);
        }

        public void Refresh(Character character) {
            if(_proceduralSpawnedPreviewModel != null)
                Destroy(_proceduralSpawnedPreviewModel);
            _previewModelGameObjectNone.SetActive(false);
            
            if(character is null) {
                _previewModelGameObjectNone.SetActive(true);
            } else {
                _proceduralSpawnedPreviewModel = Instantiate(character.Model, transform);
            }
        }
        
    }
    
}
