using TrueSync;
public class TrueSyncSdpUnPack : SdpLiteUnPacker
{
    public static void UnPack(SdpLite.Unpacker unpacker, SdpLite.DataType type, ref TFloat value)
    {
        unpacker.Unpack(type, out value._serializedValue);
    }
    public static void UnPack(SdpLite.Unpacker unpacker, SdpLite.DataType type, ref TQuaternion value)
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

    public static void UnPack(SdpLite.Unpacker unpacker, SdpLite.DataType type, ref TVector4 value)
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
    public static void UnPack(SdpLite.Unpacker unpacker, SdpLite.DataType type, ref TVector3 value)
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
    public static void UnPack(SdpLite.Unpacker unpacker, SdpLite.DataType type, ref TVector2 value)
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
    public static void UnPack(SdpLite.Unpacker unpacker, SdpLite.DataType type, ref TVector3Int value)
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

    public static void UnPack(SdpLite.Unpacker unpacker, SdpLite.DataType type, ref TVector2Int value)
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
}
