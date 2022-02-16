using System.Collections.Generic;
using Afired.GameManagement.Characters;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace DieOut.UI.CharacterSelect {
    
    public class ModelPreviewManager : SerializedMonoBehaviour {
        
        [SerializeField] private float _rotationSpeed = 10f;
        [SerializeField] private GameObject _previewModelGameObjectNone;
//        [OdinSerialize] private Dictionary<PlayerColor, GameObject> _modelPreviewPrefabsGameObjects = new Dictionary<PlayerColor, GameObject>();
        
        private void Update() {
            transform.Rotate(Vector3.up, Time.deltaTime * _rotationSpeed);
        }

        public void Refresh(Character character) {
            GameObject previewModelPrefab;
            if(character is null) {
                previewModelPrefab = _previewModelGameObjectNone;
            } else {
                //_modelPreviewPrefabsGameObjects.TryGetValue((Character)character, out previewModelPrefab);
                previewModelPrefab = null;
                //todo: spawn actual model
            }
            
            _previewModelGameObjectNone.SetActive(false);
//            foreach(GameObject modelPreviewGameObject in _modelPreviewPrefabsGameObjects.Values) {
//                modelPreviewGameObject.SetActive(false);
//            }
            
            if(previewModelPrefab != null)
                previewModelPrefab.SetActive(true);
        }
        
    }
    
}
