using System.Threading.Tasks;
using Afired.GameManagement.Sessions;
using Sirenix.OdinInspector;
using UnityAsync;
using UnityEngine;

namespace Afired.GameManagement.GameModes {
    
    [RequireComponent(typeof(Animation))]
    public class Countdown : SerializedMonoBehaviour {
        
        private Animation _animation;

        private void Awake() {
            _animation = GetComponent<Animation>();
            Session.Current.GameModeInstance.OnGameModePrepare += Run;
        }
        
        [Button]
        public async Task Run() {
            if(_animation.clip != null) {
                _animation.Play();
                await Await.Seconds(_animation.clip.length);
            }
        }
        
    }
    
}
