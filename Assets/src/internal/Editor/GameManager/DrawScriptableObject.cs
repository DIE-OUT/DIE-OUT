using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.Editor.GameManager {
    
    public class DrawScriptableObject<T> where T : ScriptableObject {
        
        [ShowIf("@_scriptableObject != null")] [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
        [SerializeField] private T _scriptableObject;
        private string _path;
        
        [ShowIf("@_scriptableObject == null")] [ReadOnly] [HideLabel] [ShowInInspector] [PropertyOrder(-1)] [InfoBox("Notify Conor plss")]
        private string _ = string.Empty;
        
        
        public DrawScriptableObject(string path) {
            _path = path;
        }

        public void FindTarget() {
            _scriptableObject = EditorSerialization.LoadAssetFromAssetBrowser<T>();
        }
        
    }
    
}
