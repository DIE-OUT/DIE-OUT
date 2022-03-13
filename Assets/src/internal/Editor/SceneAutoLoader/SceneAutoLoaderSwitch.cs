using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;

namespace DieOut.Editor {
    
    public static class ToolbarStyles {
        public static readonly GUIStyle commandButtonStyle;
        public static readonly GUIStyle labelStyle;

        static ToolbarStyles() {
            commandButtonStyle = new GUIStyle("Command") {
                fontSize = 12,
                alignment = TextAnchor.MiddleCenter,
                imagePosition = ImagePosition.ImageAbove,
                fontStyle = FontStyle.Bold
            };

            labelStyle = new GUIStyle("label") {
                fontSize = 14,
                alignment = TextAnchor.MiddleCenter,
                imagePosition = ImagePosition.ImageAbove
            };
        }
    }
    
    [InitializeOnLoad]
    public static class SceneAutoLoaderSwitch {

        static SceneAutoLoaderSwitch() {
            ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGui);
        }

        private static void OnToolbarGui() {
            
            GUILayout.FlexibleSpace();
            
            GUILayout.Label("Auto Scene Loader: ", ToolbarStyles.labelStyle);
            
            if(SceneAutoLoader.LoadMasterOnPlay) {
                if(GUILayout.Button(new GUIContent("ON", "Toggles Auto Scene Loader"), ToolbarStyles.commandButtonStyle)) {
                    SceneAutoLoader.LoadMasterOnPlay = false;
                    Debug.Log("Auto Scene Loader is now disabled");
                }
            } else {
                if(GUILayout.Button(new GUIContent("OFF", "Toggles Auto Scene Loader"), ToolbarStyles.commandButtonStyle)) {
                    SceneAutoLoader.LoadMasterOnPlay = true;
                    Debug.Log("Auto Scene Loader is now enabled");
                }
            }

        }
        
    }
    
}
