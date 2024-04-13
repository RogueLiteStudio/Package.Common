public class UnitySdpPack : SdpLitePacker
{
    public static void Pack(SdpLite.Packer packer, uint tag, bool require, UnityEngine.Quaternion value)
    {
        var positoin0 = packer.Position;
        packer.PackHeader(tag, SdpLite.DataType.StructBegin);
        var prePositoin = packer.Position;
        Pack(packer, 1, false, value.x);
        Pack(packer, 2, false, value.y);
        Pack(packer, 3, false, value.z);
        Pack(packer, 4, false, value.w);
        if (packer.Position == prePositoin && !require)
            packer.Rewind(positoin0);
        else
            packer.PackHeader(tag, SdpLite.DataType.StructEnd);
    }

    public static void Pack(SdpLite.Packer packer, uint tag, bool require, UnityEngine.Vector3 value)
    {
        var positoin0 = packer.Position;
        packer.PackHeader(tag, SdpLite.DataType.StructBegin);
        var prePositoin = packer.Position;
        Pack(packer, 1, false, value.x);
        Pack(packer, 2, false, value.y);
        Pack(packer, 3, false, value.z);
        if (packer.Position == prePositoin && !require)
            packer.Rewind(positoin0);
        else
            packer.PackHeader(tag, SdpLite.DataType.StructEnd);
    }
    public static void Pack(SdpLite.Packer packer, uint tag, bool require, UnityEngine.Vector2 value)
    {
        var positoin0 = packer.Position;
        packer.PackHeader(tag, SdpLite.DataType.StructBegin);
        var prePositoin = packer.Position;
        Pack(packer, 1, false, value.x);
        Pack(packer, 2, false, value.y);
        if (packer.Position == prePositoin && !require)
            packer.Rewind(positoin0);
        else
            packer.PackHeader(tag, SdpLite.DataType.StructEnd);
    }
    public static void Pack(SdpLite.Packer packer, uint tag, bool require, UnityEngine.Vector3Int value)
    {
        var positoin0 = packer.Position;
        packer.PackHeader(tag, SdpLite.DataType.StructBegin);
        var prePositoin = packer.Position;
        Pack(packer, 1, false, value.x);
        Pack(packer, 2, false, value.y);
        Pack(packer, 3, false, value.z);
        if (packer.Position == prePositoin && !require)
            packer.Rewind(positoin0);
        else
            packer.PackHeader(tag, SdpLite.DataType.StructEnd);
    }

    public static void Pack(SdpLite.Packer packer, uint tag, bool require, UnityEngine.Vector2Int value)
    {
        var positoin0 = packer.Position;
        packer.PackHeader(tag, SdpLite.DataType.StructBegin);
        var prePositoin = packer.Position;
        Pack(packer, 1, false, value.x);
        Pack(packer, 2, false, value.y);
        if (packer.Position == prePositoin && !require)
            packer.Rewind(positoin0);
        else
            packer.PackHeader(tag, SdpLite.DataType.StructEnd);
    }
}
