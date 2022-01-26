﻿using System.Collections.Generic;
using DieOut.Helper;
using UnityEngine;

namespace DieOut.GameMode.Management {
    
    public class GameModeRegister : MonoBehaviour {
        
        private static SingletonInstance<GameModeRegister> _instance;
        public static GameMode[] GameModes => _instance.Get()._gameModes;
        [SerializeField] private GameMode[] _gameModes;
        
        
        private void Awake() {
            _instance.Init(this);
        }
        
    }
    
}
