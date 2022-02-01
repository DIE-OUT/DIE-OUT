using Afired.AudioManagement;
using Afired.QualityManagement;
using DieOut.UI.Elements;
using Afired.WindowManagement;
using UnityEngine;

namespace DieOut.UI.MainMenu {
    
    public class SettingsScreen : MonoBehaviour {
        
        [Header("UI References")]
        [SerializeField] private Switcher _masterAudioSwitcher;
        [SerializeField] private Switcher _musicAudioSwitcher;
        [SerializeField] private Switcher _effectsAudioSwitcher;
        [SerializeField] private Switcher _windowModeSwitcher;
        [SerializeField] private Switcher _graphicsQualityLevelSwitcher;
        
        
        private void Awake() {
            ISwitchControl masterAudioSwitchControl = new RangedIntSwitchControl(new RangedIntSwitchControl.Range<int>(0, 10), 10);
            masterAudioSwitchControl.OnValueChanged += (value, _) => AudioManager.SetVolume(AudioChannel.Master, (int) value * 0.1f);
            _masterAudioSwitcher.AssignControl(masterAudioSwitchControl);
            
            ISwitchControl musicAudioSwitchControl = new RangedIntSwitchControl(new RangedIntSwitchControl.Range<int>(0, 10), 10);
            musicAudioSwitchControl.OnValueChanged += (value, _) => AudioManager.SetVolume(AudioChannel.Music, (int) value * 0.1f);
            _musicAudioSwitcher.AssignControl(musicAudioSwitchControl);
            
            ISwitchControl effectsAudioSwitchControl = new RangedIntSwitchControl(new RangedIntSwitchControl.Range<int>(0, 10), 10);
            effectsAudioSwitchControl.OnValueChanged += (value, _) => AudioManager.SetVolume(AudioChannel.Effects, (int) value * 0.1f);
            _effectsAudioSwitcher.AssignControl(effectsAudioSwitchControl);
            
            ISwitchControl windowModeSwitchControl = new EnumSwitchControl<WindowMode>(WindowManager.CurrentWindowMode);
            windowModeSwitchControl.OnValueChanged += (value, _) => WindowManager.SetWindowMode((WindowMode) value);
            _windowModeSwitcher.AssignControl(windowModeSwitchControl);
            
            ISwitchControl graphicsQualityLevelSwitchControl = new RangedIntSwitchControl(new RangedIntSwitchControl.Range<int>(0, GraphicsQualityManger.GraphicsLevelCount - 1), GraphicsQualityManger.CurrentGraphicsQualityLevelIndex, GraphicsQualityManger.GetGraphicsQualityLevelNameByIndex);
            graphicsQualityLevelSwitchControl.OnValueChanged += (value, _) => GraphicsQualityManger.SetGraphicsQualityLevel((int) value);
            _graphicsQualityLevelSwitcher.AssignControl(graphicsQualityLevelSwitchControl);
        }
        
    }
    
}
