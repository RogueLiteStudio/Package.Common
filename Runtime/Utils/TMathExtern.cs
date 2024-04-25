
using TrueSync;

public static class TMathExtern
{
    //顺时针旋转
    public static TVector2 Rotate(this TVector2 v, TFloat drgress)
    {
        TFloat radians = -drgress * TMath.Deg2Rad;
        var ca = TMath.Cos(radians);
        var sa = TMath.Sin(radians);
        return new TVector2(ca * v.x - sa * v.y, sa * v.x + ca * v.y);
    }

    public static TVector2 ToV2(this TVector3 v)
    {
        return new TVector2(v.x, v.z);
    }

    public static TVector3 ToV3(this TVector2 v)
    {
        return new TVector3(v.x, 0, v.y);
    }
}