using UnityEditor;
using UnityEngine;

namespace Afired.SceneManagement.Editor {
    
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SceneRef))]
    public class SceneRefPropertyDrawer : PropertyDrawer {
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        
            EditorGUI.BeginProperty(position, GUIContent.none, property);
            SerializedProperty sceneAsset = property.FindPropertyRelative("_sceneAsset");
            SerializedProperty sceneName = property.FindPropertyRelative("_sceneName");
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            if(sceneAsset != null) {
                sceneAsset.objectReferenceValue = EditorGUI.ObjectField(position, sceneAsset.objectReferenceValue, typeof(SceneAsset), false);
                if(sceneAsset.objectReferenceValue != null) {
                    sceneName.stringValue = (sceneAsset.objectReferenceValue as SceneAsset)!.name;
                }
            }
            EditorGUI.EndProperty();
        
        }
    
    }
    #endif
    
}
