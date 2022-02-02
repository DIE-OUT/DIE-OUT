using Afired.SceneManagement;
using UnityEngine;
using TMPro;

namespace DieOut.UI.LoadingScreen {

    public class LoadingProgressText : MonoBehaviour {

        [SerializeField] private string _prefix;
        [SerializeField] private string _suffix = "%";
        [SerializeField] private TMP_Text _text;
        private float _lerpedLoadingProgress = 0f;

        
        private void Update() {
            _lerpedLoadingProgress = Mathf.Lerp(_lerpedLoadingProgress, Mathf.Clamp01(SceneManager.LoadingProgress + 0.1f), 0.1f); //is not accurate because it doesn't scale with time - but whatever, its not displaying the real current progress, so it doesn't matter
            _text.text = _prefix + Mathf.RoundToInt(_lerpedLoadingProgress * 100) + _suffix;
        }
        
    }
    
}
