using UnityEngine;
using TrueSync;

public static class TrueSyncConvertExtern
{
    public static Vector2 ToVec2(this TVector2 val)
    {
        return new Vector2((float)val.x, (float)val.y);
    }

    public static TVector2 ToTVec2(this Vector2 val)
    {
        return new TVector2(val.x, val.y);
    }

    public static Vector3 ToVec3(this TVector3 val)
    {
        return new Vector3((float)val.x, (float)val.y, (float)val.z);
    }

    public static TVector3 ToTVec3(this Vector3 val)
    {
        return new TVector3(val.x, val.y, val.z);
    }

    public static Quaternion ToQuate(this TQuaternion val)
    {
        return new Quaternion((float)val.x, (float)val.y, (float)val.z, (float)val.w);
    }

    public static TQuaternion ToTQuate(this Quaternion val)
    {
        return new TQuaternion(val.x, val.y, val.z, val.w);
    }
}
