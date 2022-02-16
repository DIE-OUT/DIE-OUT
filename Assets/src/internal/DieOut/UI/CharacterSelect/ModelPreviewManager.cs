using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace DieOut.UI.CharacterSelect {
    
    public class ModelPreviewManager : SerializedMonoBehaviour {
        
        [SerializeField] private float _rotationSpeed = 10f;
        [SerializeField] private GameObject _previewModelGameObjectNone;
        [OdinSerialize] private Dictionary<PlayerColor, GameObject> _modelPreviewPrefabsGameObjects = new Dictionary<PlayerColor, GameObject>();
        
        private void Update() {
            transform.Rotate(Vector3.up, Time.deltaTime * _rotationSpeed);
        }

        public void Refresh(PlayerColor? playerColor) {
            GameObject previewModelPrefab;
            if(playerColor is null) {
                previewModelPrefab = _previewModelGameObjectNone;
            } else {
                _modelPreviewPrefabsGameObjects.TryGetValue((PlayerColor)playerColor, out previewModelPrefab);
            }
            
            _previewModelGameObjectNone.SetActive(false);
            foreach(GameObject modelPreviewGameObject in _modelPreviewPrefabsGameObjects.Values) {
                modelPreviewGameObject.SetActive(false);
            }
            
            if(previewModelPrefab != null)
                previewModelPrefab.SetActive(true);
        }
        
    }
    
}
