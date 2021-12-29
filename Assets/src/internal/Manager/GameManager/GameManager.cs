using UnityEngine;

public delegate void OnGameStateChange(GameState newGameState, GameState prevGameState);

public class GameManager : MonoBehaviour {
    
    public static event OnGameStateChange OnGameStateChange;
    [SerializeField] private GameState _startingGameState;
    private static GameManager _instance;
    private GameState _gameState;
    
    
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
    
    private void Awake() {
        if(_instance != null) {
            Debug.LogWarning("only one GameManager can be active at once");
            return;
        }
        _instance = this;
        _gameState = _startingGameState;
    }
    
}
