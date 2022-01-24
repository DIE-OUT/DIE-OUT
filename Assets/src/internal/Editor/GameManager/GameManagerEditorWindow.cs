using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace DieOut.Editor.GameManager {
    
    internal class GameManagerEditorWindow : OdinMenuEditorWindow {

        [HideLabel]
        [EnumToggleButtons]
        [ShowInInspector]
        private ManagerTab _currentManagerTab = ManagerTab.GameModes;
        private int _enumIndex;
        
        [MenuItem("DieOut/Game Manager")]
        public static void OpenWindow() {
            GetWindow<GameManagerEditorWindow>("Game Manager").Show();
        }

        protected override void OnGUI() {
            SirenixEditorGUI.Title("Game Manager", "Subtitle", TextAlignment.Center, true);
            EditorGUILayout.Space();
            switch(_currentManagerTab) {
                // all tabs that should draw a menu tree
                case ManagerTab.GameModes:
                    DrawEditor(_enumIndex);
                    break;
                default:
                    break;
            }
            base.OnGUI();
        }

        protected override void DrawEditors() {
            switch(_currentManagerTab) {
                case ManagerTab.GameModes:
                    break;
                case ManagerTab.SessionSettings:
                    DrawEditor(_enumIndex);
                    break;
                default:
                    break;
            }
        }

        protected override IEnumerable<object> GetTargets() {
            List<object> targets = new List<object>();
            targets.Add(base.GetTarget());

            _enumIndex = targets.Count - 1;
            
            return targets;
        }

        protected override void DrawMenu() {
            switch(_currentManagerTab) {
                // all tabs that should draw a menu tree
                case ManagerTab.GameModes:
                    base.DrawMenu();
                    break;
                default:
                    break;
            }
        }

        protected override OdinMenuTree BuildMenuTree() {
            OdinMenuTree tree = new OdinMenuTree();
            return tree;
        }
        
    }

    internal enum ManagerTab {
        GameModes,
        SessionSettings
    }
    
}
