using Afired.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace DieOut.UI.LoadingScreen {

    public class LoadingProgressbar : MonoBehaviour {
        
        [SerializeField] private Image _progressbarFill;
        private float _lerpedLoadingProgress = 0f;

        
        private void Update() {
            _lerpedLoadingProgress = Mathf.Lerp(_lerpedLoadingProgress, Mathf.Clamp01(SceneManager.LoadingProgress + 0.1f), 0.1f); //is not accurate because it doesn't scale with time - but whatever, its not displaying the real current progress, so it doesn't matter
            //_progressbarFill.transform.localPosition = new Vector3(-1000 + _lerpedLoadingProgress * 1000, _progressbarFill.transform.localPosition.y, _progressbarFill.transform.localPosition.z);
            _progressbarFill.fillAmount = _lerpedLoadingProgress;
        }
        
    }
    
}
