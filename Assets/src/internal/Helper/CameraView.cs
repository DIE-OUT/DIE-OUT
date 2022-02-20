using UnityEngine;

namespace Afired.Helper {
    
    public static class CameraExtension {
        
        public static Vector3 GetDirection(this Camera camera, Vector2 mousePosition, Vector3 planeOrigin, Vector3 planeNormal) {
            Ray ray = camera.ScreenPointToRay(mousePosition);
            
            //raypoint - raydirection * dot(raypoint - planepoint, planenormal) / dot(raydirection, planenormal);
            Vector3 mousePositionInWorld = ray.origin - ray.direction * Vector3.Dot(ray.origin - planeOrigin, planeNormal) / Vector3.Dot(ray.direction, planeNormal);

            return mousePositionInWorld;
        }
        
    }
    
}
