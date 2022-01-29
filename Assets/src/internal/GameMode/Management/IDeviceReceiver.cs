using UnityEngine.InputSystem;

namespace DieOut.GameMode.Management {
    
    public interface IDeviceReceiver {
        
        public void SetDevices(InputDevice[] devices);
        
    }
    
}
