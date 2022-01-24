using Sirenix.OdinInspector;
using UnityEngine;

namespace DieOut.Editor.GameManager {
    
    public class DrawScriptableObject<T> where T : ScriptableObject {
        
        [Title("Test")]
        [ShowIf("@_myObject != null")]
        [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
        public T _scriptableObject;

        public void FindScriptableObject() {
            
        }
        
    }
    
}
