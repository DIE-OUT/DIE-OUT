using System;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityAsync;
using UnityEngine;

namespace Afired.GameManagement.GameModes {
    
    [RequireComponent(typeof(Animation))]
    public class Countdown : SerializedMonoBehaviour {
        
        private Animation _animation;
        private static Countdown _instance;

        private void Awake() {
            _animation = GetComponent<Animation>();
            _instance = this;
        }
        
        [Button]
        public static async Task Run() {
            if(_instance == null) throw new Exception("game mode countdown not loaded!");
            if(_instance._animation.clip != null) {
                _instance._animation.Play();
                await Await.Seconds(_instance._animation.clip.length);
            }
        }
        
    }
    
}
