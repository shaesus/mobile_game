using UnityEngine;

public static class TransformExtensions
{
    public static void SetXPos(this Transform transform, float x)
    {
        transform.position = new Vector3(x, transform.position.y,
            transform.position.z);
    }

    public static void SetYPos(this Transform transform, float y)
    {
        transform.position = new Vector3(transform.position.x, y,
            transform.position.z);
    }

    public static void SetZPos(this Transform transform, float z)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}
