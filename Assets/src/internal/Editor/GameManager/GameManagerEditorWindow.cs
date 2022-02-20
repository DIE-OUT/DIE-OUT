using System.Collections.Generic;
using Afired.GameManagement.Characters;
using Afired.GameManagement.GameModes;
using Afired.GameManagement.Sessions;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace DieOut.Editor.GameManager {
    
    internal class GameManagerEditorWindow : OdinMenuEditorWindow {
        
        [OnValueChanged("OnTabChange")] [HideLabel] [EnumToggleButtons]
        [ShowInInspector] private ManagerTab _currentManagerTab = ManagerTab.GameModes;
        private int _enumIndex;
        
        private const string GAME_MODES_PATH = "Assets/ScriptableObjects/GameModes";
        private readonly DrawScriptableObjectTree<GameMode> _drawGameModes = new DrawScriptableObjectTree<GameMode>(GAME_MODES_PATH);
        private const string CHARACTERS_PATH = "Assets/ScriptableObjects/Characters";
        private readonly DrawScriptableObjectTree<Character> _drawCharacters = new DrawScriptableObjectTree<Character>(CHARACTERS_PATH);
        private readonly DrawScriptableObject<SessionSettings> _drawSessionSettings = new DrawScriptableObject<SessionSettings>("global");

        private bool _menuTreeIsDirty = false;
        
        [MenuItem("DieOut/Game Manager")]
        public static void OpenWindow() {
            GetWindow<GameManagerEditorWindow>("Game Manager").Show();
        }

        protected override void Initialize() {
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
            
            SirenixEditorGUI.Title("Game Manager", _currentManagerTab.ToString(), TextAlignment.Center, true);
            EditorGUILayout.Space();
            switch(_currentManagerTab) {
                // all tabs that should draw a menu tree
                case ManagerTab.GameModes:
                    DrawEditor(_enumIndex);
                    break;
                case ManagerTab.Characters:
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
                case ManagerTab.Characters:
                    _drawCharacters.SetSelected(MenuTree.Selection.SelectedValue);
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
            targets.Add(_drawCharacters);
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
                case ManagerTab.Characters:
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
                    tree.AddAllAssetsAtPath("Game Modes", GAME_MODES_PATH, typeof(GameMode));
                    break;
                case ManagerTab.Characters:
                    tree.AddAllAssetsAtPath("Characters", CHARACTERS_PATH, typeof(Character));
                    break;
                default:
                    break;
            }
            
            return tree;
        }
        
    }
    
    internal enum ManagerTab {
        GameModes,
        Characters,
        SessionSettings
    }
    
}
