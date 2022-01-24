using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace DieOut.Editor {
	
    /// <summary>
    /// Based on an idea on this thread:
    /// http://forum.unity3d.com/threads/157502-Executing-first-scene-in-build-settings-when-pressing-play-button-in-editor
    /// </summary>
    [InitializeOnLoad]
    public static class SceneAutoLoader {
	    
	    private const string MASTER_SCENE_FILE_PATH = "Assets/Scenes/StartUp.unity";
	    private const string EDITOR_PREF_PREVIOUS_SCENE = "SceneAutoLoader.PreviousScene";
	    private static bool _loadMasterOnPlay = true;
	    private static string PreviousScene {
		    get => EditorPrefs.GetString(EDITOR_PREF_PREVIOUS_SCENE, EditorSceneManager.GetActiveScene().path);
		    set => EditorPrefs.SetString(EDITOR_PREF_PREVIOUS_SCENE, value);
	    }
	    
		// Static constructor binds a playmode-changed callback.
		// [InitializeOnLoad] above makes sure this gets executed.
		static SceneAutoLoader() {
		  EditorApplication.playModeStateChanged += OnPlayModeChanged;
		}
		
		[MenuItem("File/Scene Autoload/Load Master On Play", true)]
		private static bool ShowLoadMasterOnPlay() {
		  return !_loadMasterOnPlay;
		}
		[MenuItem("File/Scene Autoload/Load Master On Play")]
		private static void EnableLoadMasterOnPlay() {
		  _loadMasterOnPlay = true;
		}
		
		[MenuItem("File/Scene Autoload/Don't Load Master On Play", true)]
		private static bool ShowDontLoadMasterOnPlay() {
		  return _loadMasterOnPlay;
		}
		[MenuItem("File/Scene Autoload/Don't Load Master On Play")]
		private static void DisableLoadMasterOnPlay() {
		  _loadMasterOnPlay = false;
		}
		
		// Play mode change callback handles the scene load/reload.
		private static void OnPlayModeChanged(PlayModeStateChange state) {
			if(!_loadMasterOnPlay)
				return;
			
			if(!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode) {
				// User pressed play -- autoload master scene.
				
				PreviousScene = EditorSceneManager.GetActiveScene().path;
				if(EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {
					try {
					    EditorSceneManager.OpenScene(MASTER_SCENE_FILE_PATH);
					} catch {
						Debug.LogError($"error: scene not found: {MASTER_SCENE_FILE_PATH}");
						EditorApplication.isPlaying = false;
					}
				} else {
					// User cancelled the save operation -- cancel play as well.
					EditorApplication.isPlaying = false;
				}
			}
			
			// isPlaying check required because cannot OpenScene while playing
			if(!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode) {
				// User pressed stop -- reload previous scene.
				try {
					EditorSceneManager.OpenScene(PreviousScene);
				} catch { 
					Debug.LogError($"error: scene not found: {PreviousScene}");
				}
				
			}
			
		}
		
    }
	
}
