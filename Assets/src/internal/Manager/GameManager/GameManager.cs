using UnityEngine;

public delegate void OnGameStateChange(GameState newGameState, GameState prevGameState);

public class GameManager : BaseManager {
    
    public static event OnGameStateChange OnGameStateChange;

    [SerializeField] private GameState _startingGameState;
    
    private static GameManager _instance;
    private GameState _gameState;

    public static GameState GameState {
        get => _instance._gameState;
        set {
            if(value != GameState)
                OnGameStateChange?.Invoke(value, GameState);
            _instance._gameState = value;
        }
    }

    protected override void OnAwake() {
        _instance = this;
        _gameState = _startingGameState;
    }

}
