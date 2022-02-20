using System;
using UnityEngine;

namespace Afired.Helper {
    
    /// <summary>
    /// helper struct for easy singleton pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SingletonInstance<T> where T : MonoBehaviour {

        private static T _instance;
        
        /// <summary>
        /// registers an instance as singleton
        /// </summary>
        /// <param name="instance">the instance to be registered</param>
        /// <exception cref="Exception"></exception>
        public void Init(T instance) {
            if(_instance != null)
                throw new Exception($"tried to initialize a singleton instance of '{typeof(T).Name}', but there is already an instance of this object registered");
            _instance = instance;
        }
        
        /// <summary>
        /// gets registered singleton instance
        /// </summary>
        /// <returns>singleton instance</returns>
        /// <exception cref="Exception">when no instance got registered yet</exception>
        public T Get() {
            if(_instance == null)
                throw new Exception($"there is no instance of '{typeof(T).Name}' initialized");
            return _instance;
        }
        
        /// <summary>
        /// checks if there has been registered a singleton instance
        /// </summary>
        public bool Exists => _instance != null;
        
    }
    
}
