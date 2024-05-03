using System.IO;

namespace TrueSync
{
    public static class ReadWriteExtern
    {
        public static TFloat ReadTFloat(this BinaryReader reader)
        {
            TFloat result;
            result._rawVal = reader.ReadInt64();
            return result;
        }

        public static void Write(this BinaryWriter writer, TFloat value)
        {
            writer.Write(value.RawValue);
        }
    }
}
