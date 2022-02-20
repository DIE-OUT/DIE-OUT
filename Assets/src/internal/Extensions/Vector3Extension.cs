using UnityEngine;

public static class Vector3Extension {

    /// <summary>
    /// Returns a Vector2 which consist of the x and y values of the given Vector3.
    /// </summary>
    public static Vector2 xy(this Vector3 vector3) {
        return new Vector2(vector3.x, vector3.y);
    }
    
    /// <summary>
    /// Returns a Vector2 which consist of the x and z values of the given Vector3.
    /// </summary>
    public static Vector2 xz(this Vector3 vector3) {
        return new Vector2(vector3.x, vector3.z);
    }
    
    /// <summary>
    /// Returns a Vector2 which consist of the y and z values of the given Vector3.
    /// </summary>
    public static Vector2 yz(this Vector3 vector3) {
        return new Vector2(vector3.y, vector3.z);
    }
    
    /// <summary>
    /// Returns a Vector3 which is perpendicular to the given Vector3.
    /// </summary>
    public static Vector3 Perpendicular(this Vector3 vector3) {
        return vector3.z < vector3.x ?
            new Vector3(vector3.y, -vector3.x, 0) :
            new Vector3(0, -vector3.z, vector3.y).normalized;
    }
    
}
