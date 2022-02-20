using UnityEngine;

public static class CustomGizmos {
    
    /// <summary>
    /// draws a circle in editor
    /// </summary>
    public static void DrawCircle(Vector3 center, Vector3 planeNormal, float radius) {
        planeNormal = planeNormal.normalized;
        float detail = radius * 5;                                      // corners of the circle
        Vector3 startRotation = planeNormal.Perpendicular() * radius;   // first point of the circle
        Vector3 lastPosition = center + startRotation;
        float angle = 0;
        while (angle <= 360) {
            angle += 360 / detail;
            Vector3 nextPosition = center + Quaternion.AngleAxis(angle, planeNormal) * startRotation;
            Gizmos.DrawLine(lastPosition, nextPosition);
            
            lastPosition = nextPosition;
        }
    }
    
}
