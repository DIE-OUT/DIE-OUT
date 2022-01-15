using System;
using UnityEngine;

namespace DieOut.Helper {
    
    public struct SingletonInstance<T> where T : MonoBehaviour {

        private static T _instance;

        public void Init(T instance) {
            if(_instance != null)
                throw new Exception($"tried to initialize a singleton instance of '{typeof(T).Name}', but there is already an instance of this object registered");
            _instance = instance;
        }

        public T Get() {
            if(_instance == null)
                throw new Exception($"there is no instance of '{typeof(T).Name}' initialized");
            return _instance;
        }

    }
    
}
