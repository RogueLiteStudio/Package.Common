using UnityEngine;

public static class UnityMathExtern
{
    //顺时针旋转
    public static Vector2 Rotate(this Vector2 v, float drgress)
    {
        float radians = -drgress * Mathf.Deg2Rad;
        var ca = Mathf.Cos(radians);
        var sa = Mathf.Sin(radians);
        return new Vector2(ca * v.x - sa * v.y, sa * v.x + ca * v.y);
    }

    public static Vector2 ToV2(this Vector3 v)
    {
        return new Vector2(v.x, v.z);
    }

    public static Vector3 ToV3(this Vector2 v)
    {
        return new Vector3(v.x, 0, v.y);
    }
}
