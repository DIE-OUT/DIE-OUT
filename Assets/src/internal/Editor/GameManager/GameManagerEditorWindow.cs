using System.Collections.Generic;
using Afired.GameManagement.GameModes;
using Afired.GameManagement.Sessions;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace DieOut.Editor.GameManager {
    
    internal class GameManagerEditorWindow : OdinMenuEditorWindow {
        
        [OnValueChanged("OnTabChange")]
        [HideLabel]
        [EnumToggleButtons]
        [ShowInInspector]
        private ManagerTab _currentManagerTab = ManagerTab.GameModes;
        private int _enumIndex;
        
        private readonly DrawScriptableObjectTree<GameMode> _drawGameModes = new DrawScriptableObjectTree<GameMode>(GAME_MODE_PATH);
        private const string GAME_MODE_PATH = "Assets/ScriptableObjects/GameModes";
        private readonly DrawScriptableObject<SessionSettings> _drawSessionSettings = new DrawScriptableObject<SessionSettings>("global");

        private bool _menuTreeIsDirty = false;
        
        [MenuItem("DieOut/Game Manager")]
        public static void OpenWindow() {
            GetWindow<GameManagerEditorWindow>("Game Manager").Show();
        }

        protected override void Initialize() {
            //_drawGameModes.SetPath(GAME_MODE_PATH);
            _drawSessionSettings.FindTarget();
        }

        private void OnTabChange() {
            _menuTreeIsDirty = true;
        }

        protected override void OnGUI() {

            if(_menuTreeIsDirty && Event.current.type == EventType.Layout) {
                ForceMenuTreeRebuild();
                _menuTreeIsDirty = false;
            }
            
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
                    _drawGameModes.SetSelected(MenuTree.Selection.SelectedValue);
                    break;
                case ManagerTab.SessionSettings:
                    DrawEditor(_enumIndex);
                    break;
                default:
                    break;
            }
            
            DrawEditor((int) _currentManagerTab);
        }

        protected override IEnumerable<object> GetTargets() {
            List<object> targets = new List<object>();
            
            targets.Add(_drawGameModes);
            targets.Add(_drawSessionSettings);
            
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

            switch(_currentManagerTab) {
                case ManagerTab.GameModes:
                    tree.AddAllAssetsAtPath("Game Modes", GAME_MODE_PATH, typeof(GameMode));
                    break;
                default:
                    break;
            }
            
            return tree;
        }
        
    }

    internal enum ManagerTab {
        GameModes,
        SessionSettings
    }
    
}
