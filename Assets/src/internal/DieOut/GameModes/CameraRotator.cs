using UnityEngine;

namespace DieOut.GameModes {
    
    public class CameraRotator : MonoBehaviour {

        [SerializeField] private Vector3 _rotationPoint = new Vector3(0, 0, 0);
        [SerializeField] private float _rotationSpeed = 1.0f;


        private void Update() {
            transform.RotateAround(_rotationPoint, Vector3.up, _rotationSpeed * Time.deltaTime);
        }

        private void OnDrawGizmosSelected() {
            Gizmos.DrawLine(transform.position, _rotationPoint);
            float radius = (transform.position.xz() - _rotationPoint.xz()).magnitude;

            CustomGizmos.DrawCircle(new Vector3(_rotationPoint.x, transform.position.y, _rotationPoint.z), Vector3.up, radius);
        }

    }
    
}
