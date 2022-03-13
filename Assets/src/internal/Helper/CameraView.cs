using UnityEngine;

namespace Afired.Helper {
    
    public static class CameraExtension {
        
        
        public static Vector3 GetContactPosOfMousePosToPlane(this Camera camera, Vector2 mousePosition, Vector3 planeOrigin, Vector3 planeNormal) {
            Ray ray = camera.ScreenPointToRay(mousePosition);
            Vector3 mousePositionInWorld = ray.origin - ray.direction * Vector3.Dot(ray.origin - planeOrigin, planeNormal) / Vector3.Dot(ray.direction, planeNormal);
            return mousePositionInWorld;
        }
        
    }
    
}
