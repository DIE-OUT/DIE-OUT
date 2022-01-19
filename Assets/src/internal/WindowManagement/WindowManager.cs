using System.ComponentModel;
using DieOut.Helper;
using UnityEngine;

namespace DieOut.WindowManagement {
    
    public class WindowManager : MonoBehaviour {
        
        public static WindowMode CurrentWindowMode { get; private set; }
        [SerializeField] private WindowMode _startingWindowMode = WindowMode.WindowedFullScreen;
        private static SingletonInstance<WindowManager> _instance;
        
        
        private void Awake() {
            _instance.Init(this);
            SetWindowMode(_startingWindowMode);
        }
        
        public static void SetWindowMode(WindowMode windowMode) {
            CurrentWindowMode = windowMode;
            switch(windowMode) {
                case WindowMode.WindowedFullScreen:
                    Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, FullScreenMode.FullScreenWindow);
                    break;
                case WindowMode.ExclusiveFullScreen:
                    Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, FullScreenMode.ExclusiveFullScreen);
                    break;
                case WindowMode.Window:
                    Screen.SetResolution(Display.main.systemWidth / 2, Display.main.systemHeight / 2, false);
                    break;
                default:
                    throw new InvalidEnumArgumentException(windowMode.ToString());
            }
        }
        
    }
    
}
