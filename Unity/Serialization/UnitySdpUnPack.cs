public class UnitySdpUnPack : TrueSyncSdpUnPack
{
    public static void UnPack(SdpLite.Unpacker unpacker, SdpLite.DataType type, ref UnityEngine.Quaternion value)
    {
        if (type != SdpLite.DataType.StructBegin)
            SdpLite.Unpacker.ThrowIncompatibleType(type);
        value.x = default;
        value.y = default;
        value.z = default;
        value.w = default;
        do
        {
            var headerSize = unpacker.PeekHeader(out var header);
            unpacker.SkipBytes(headerSize);
            if (header.type == SdpLite.DataType.StructEnd)
            {
                break;
            }
            switch (header.tag)
            {
                case 1:
                    UnPack(unpacker, header.type, ref value.x);
                    break;
                case 2:
                    UnPack(unpacker, header.type, ref value.y);
                    break;
                case 3:
                    UnPack(unpacker, header.type, ref value.z);
                    break;
                case 4:
                    UnPack(unpacker, header.type, ref value.w);
                    break;
                default:
                    unpacker.SkipField(header.type);
                    break;
            }
        } while (true);
    }

    public static void UnPack(SdpLite.Unpacker unpacker, SdpLite.DataType type, ref UnityEngine.Vector3 value)
    {
        if (type != SdpLite.DataType.StructBegin)
            SdpLite.Unpacker.ThrowIncompatibleType(type);
        value.x = default;
        value.y = default;
        value.z = default;
        do
        {
            var headerSize = unpacker.PeekHeader(out var header);
            unpacker.SkipBytes(headerSize);
            if (header.type == SdpLite.DataType.StructEnd)
            {
                break;
            }
            switch (header.tag)
            {
                case 1:
                    UnPack(unpacker, header.type, ref value.x);
                    break;
                case 2:
                    UnPack(unpacker, header.type, ref value.y);
                    break;
                case 3:
                    UnPack(unpacker, header.type, ref value.z);
                    break;
                default:
                    unpacker.SkipField(header.type);
                    break;
            }
        } while (true);
    }
    public static void UnPack(SdpLite.Unpacker unpacker, SdpLite.DataType type, ref UnityEngine.Vector2 value)
    {
        if (type != SdpLite.DataType.StructBegin)
            SdpLite.Unpacker.ThrowIncompatibleType(type);
        value.x = default;
        value.y = default;
        do
        {
            var headerSize = unpacker.PeekHeader(out var header);
            unpacker.SkipBytes(headerSize);
            if (header.type == SdpLite.DataType.StructEnd)
            {
                break;
            }
            switch (header.tag)
            {
                case 1:
                    UnPack(unpacker, header.type, ref value.x);
                    break;
                case 2:
                    UnPack(unpacker, header.type, ref value.y);
                    break;
                default:
                    unpacker.SkipField(header.type);
                    break;
            }
        } while (true);
    }
    public static void UnPack(SdpLite.Unpacker unpacker, SdpLite.DataType type, ref UnityEngine.Vector3Int value)
    {
        if (type != SdpLite.DataType.StructBegin)
            SdpLite.Unpacker.ThrowIncompatibleType(type);
        value.x = default;
        value.y = default;
        value.z = default;
        do
        {
            var headerSize = unpacker.PeekHeader(out var header);
            unpacker.SkipBytes(headerSize);
            if (header.type == SdpLite.DataType.StructEnd)
            {
                break;
            }
            switch (header.tag)
            {
                case 1:
                    int x = 0;
                    UnPack(unpacker, header.type, ref x);
                    value.x = x;
                    break;
                case 2:
                    int y = 0;
                    UnPack(unpacker, header.type, ref y);
                    value.y = y;
                    break;
                case 3:
                    int z = 0;
                    UnPack(unpacker, header.type, ref z);
                    value.z = z;
                    break;
                default:
                    unpacker.SkipField(header.type);
                    break;
            }
        } while (true);
    }

    public static void UnPack(SdpLite.Unpacker unpacker, SdpLite.DataType type, ref UnityEngine.Vector2Int value)
    {
        if (type != SdpLite.DataType.StructBegin)
            SdpLite.Unpacker.ThrowIncompatibleType(type);
        value.x = default;
        value.y = default;
        do
        {
            var headerSize = unpacker.PeekHeader(out var header);
            unpacker.SkipBytes(headerSize);
            if (header.type == SdpLite.DataType.StructEnd)
            {
                break;
            }
            switch (header.tag)
            {
                case 1:
                    int x = 0;
                    UnPack(unpacker, header.type, ref x);
                    value.x = x;
                    break;
                case 2:
                    int y = 0;
                    UnPack(unpacker, header.type, ref y);
                    value.y = y;
                    break;
                default:
                    unpacker.SkipField(header.type);
                    break;
            }
        } while (true);
    }
}
