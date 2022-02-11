using System.ComponentModel;
using Afired.Helper;
using UnityEngine;
using UnityEngine.Audio;

namespace Afired.AudioManagement {
    
    public class AudioManager : MonoBehaviour {
        
        [SerializeField] private AudioMixer _audioMixer;
        private static SingletonInstance<AudioManager> _instance;
        private const string MASTER_VOLUME = "MasterVolume";
        private const string EFFECTS_VOLUME = "EffectsVolume";
        private const string MUSIC_VOLUME = "MusicVolume";
        private const string AMBIENT_VOLUME = "AmbientVolume";
        
        private void Awake() {
            _instance.Init(this);
        }
        
        public static void SetVolume(AudioChannel audioChannel, float percentile) {
            _instance.Get()._audioMixer.SetFloat(GetAudioChannelsVolumeAsString(audioChannel), ConvertPercentileToDecibel(percentile));
        }
        
        private static string GetAudioChannelsVolumeAsString(AudioChannel audioChannel) {
            return audioChannel switch {
                AudioChannel.Master => MASTER_VOLUME,
                AudioChannel.Music => MUSIC_VOLUME,
                AudioChannel.Effects => EFFECTS_VOLUME,
                AudioChannel.Ambient => AMBIENT_VOLUME,
                _ => throw new InvalidEnumArgumentException(audioChannel.ToString())
            };
        }
        
        private static float ConvertPercentileToDecibel(float percentile) {
            return (percentile - 0.5f) * 10;
        }
        
    }
    
}
