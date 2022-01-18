using DieOut.GameMode;
using DieOut.Helper;
using UnityEngine;

public delegate void OnGameStateChange(GameState newGameState, GameState prevGameState);

public class GameManager : MonoBehaviour {
    
    public static event OnGameStateChange OnGameStateChange;
    private static SingletonInstance<GameManager> _instance;
    private GameState _gameState = GameState.StartUp;
    public static GameState GameState {
        get => _instance.Get()._gameState;
        set {
            if(value != GameState)
                OnGameStateChange?.Invoke(value, GameState);
            _instance.Get()._gameState = value;
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
        _instance.Init(this);
    }
    
}
