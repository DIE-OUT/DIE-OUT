using UnityEngine.InputSystem;

namespace Afired.GameManagement.GameModes {
    
    /// <summary>
    /// interface for custom injection of input devices
    /// </summary>
    public interface IDeviceReceiver {
        
        public void ReceiveDevices(InputDevice[] devices);
        
    }
    
}
