using DieOut.GameMode;
using UnityEngine;

public delegate void OnGameStateChange(GameState newGameState, GameState prevGameState);

public class GameManager : MonoBehaviour {
    
    public static event OnGameStateChange OnGameStateChange;
    private static GameManager _instance;
    private GameState _gameState = GameState.StartUp;
    
    public static GameState GameState {
        get {
            if(_instance == null) {
                Debug.LogWarning("there is no GameManager instance initialized");
                return default;
            }
            return _instance._gameState;
        }
        set {
            if(_instance == null) {
                Debug.LogWarning("there is no GameManager instance initialized");
                return;
            }
            if(value != GameState)
                OnGameStateChange?.Invoke(value, GameState);
            _instance._gameState = value;
        }
    }
    
    /// <summary>
    /// the current game mode, returns null if not in a game
    /// </summary>
    public static GameMode? CurrentGameMode {
        get;
        private set;
    } = null;
    
    private void Awake() {
        if(_instance != null) {
            Debug.LogWarning("only one GameManager can be active at once");
            return;
        }
        _instance = this;
    }
    
}
