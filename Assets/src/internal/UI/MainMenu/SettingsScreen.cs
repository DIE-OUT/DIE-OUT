using DieOut.AudioManagement;
using DieOut.GraphicsQualityManagement;
using DieOut.UI.Elements;
using DieOut.WindowManagement;
using UnityEngine;

namespace DieOut.UI.MainMenu {
    
    public class SettingsScreen : MonoBehaviour {
        
        [Header("UI References")]
        [SerializeField] private Switcher _masterAudioSwitcher;
        [SerializeField] private Switcher _windowModeSwitcher;
        [SerializeField] private Switcher _graphicsQualityLevelSwitcher;
        
        
        private void Awake() {
            ISwitchControl masterAudioSwitchControl = new RangedIntSwitchControl(new RangedIntSwitchControl.Range<int>(0, 10), 10);
            masterAudioSwitchControl.OnValueChanged += (value, _) => AudioManager.SetVolume(AudioChannel.Master, (int) value * 0.1f);
            _masterAudioSwitcher.AssignControl(masterAudioSwitchControl);
            
            ISwitchControl windowModeSwitchControl = new EnumSwitchControl<WindowMode>(WindowManager.CurrentWindowMode);
            windowModeSwitchControl.OnValueChanged += (value, _) => WindowManager.SetWindowMode((WindowMode) value);
            _windowModeSwitcher.AssignControl(windowModeSwitchControl);
            
            ISwitchControl graphicsQualityLevelSwitchControl = new EnumSwitchControl<GraphicsQualityLevel>(GraphicsQualityManger.CurrenGraphicsQualityLevel);
            graphicsQualityLevelSwitchControl.OnValueChanged += (value, _) => WindowManager.SetWindowMode((WindowMode) value);
            _graphicsQualityLevelSwitcher.AssignControl(graphicsQualityLevelSwitchControl);
        }
        
    }
    
}
