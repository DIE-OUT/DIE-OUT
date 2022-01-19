using System.ComponentModel;
using UnityEngine;

namespace DieOut.WindowManagement {
    
    public static class WindowManager {
        
        public static void SetWindowMode(WindowMode windowMode) {
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
