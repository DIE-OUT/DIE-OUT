using System.Collections;
using Afired.GameManagement.Sessions;
using UnityEngine;

namespace DieOut.GameModes {
    
    [RequireComponent(typeof(Health))]
    public class DornenkroneDeathEffect : MonoBehaviour {
        
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private float _dissolveSpeed = 1f;
        [SerializeField] private float _saturationSpeed = 1f;
        [SerializeField] private float _particleDelay = 1f;
        [SerializeField] private float _dissolveDelay = 1f;
        [SerializeField] private float _saturationDelay = 0.5f;
        private SkinnedMeshRenderer _skinnedMeshRenderer;
        private static readonly int _saturationID = Shader.PropertyToID("Saturation");
        private static readonly int _dissolveAmountID = Shader.PropertyToID("DissolveAmount");

        private void Awake() {
            GetComponent<Health>().OnDeath += OnDeath;
        }

        private void Start() {
            _skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        }

        private void OnDeath(Player player) {
            StartCoroutine(SpawnParticlesDelayed());
            StartCoroutine(ChangeSaturation());
            StartCoroutine(Dissolve());
        }

        private IEnumerator ChangeSaturation() {
            if(_skinnedMeshRenderer == null) {
                Debug.Log("no _skinnedMeshRenderer found");
                yield break;
            }
            
            Renderer renderer = _skinnedMeshRenderer.gameObject.GetComponent<Renderer>();
            
            if(renderer == null) {
                Debug.Log("no renderer found");
                yield break;
            }
            
            Debug.Log("changing saturation on " + renderer.material.name);
            
            yield return new WaitForSeconds(_saturationDelay);
            
            float saturation = 1;
            while(saturation > 0) {
                renderer.material.SetFloat(_saturationID, saturation);
                yield return null;
                saturation -= Time.deltaTime * _saturationSpeed;
            }
            renderer.material.SetFloat(_saturationID, 0);
        }

        private IEnumerator Dissolve() {
            if(_skinnedMeshRenderer == null) {
                Debug.Log("no _skinnedMeshRenderer found");
                yield break;
            }
            
            Renderer renderer = _skinnedMeshRenderer.gameObject.GetComponent<Renderer>();
            
            if(renderer == null) {
                Debug.Log("no renderer found");
                yield break;
            }
            
            yield return new WaitForSeconds(_dissolveDelay);
            
            float dissolveAmount = 0;
            while(dissolveAmount < 1) {
                renderer.material.SetFloat(_dissolveAmountID, dissolveAmount);
                yield return null;
                dissolveAmount += Time.deltaTime * _dissolveSpeed;
            }
            renderer.material.SetFloat(_dissolveAmountID, 1);
        }
        
        private IEnumerator SpawnParticlesDelayed() {
            
            if(_particleSystem == null) {
                Debug.Log("no particle system assigned");
                yield break;
            }
            
            yield return new WaitForSeconds(_particleDelay);
            _particleSystem.gameObject.SetActive(true);
        }
        
    }
    
}
