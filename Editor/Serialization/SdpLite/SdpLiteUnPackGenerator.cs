using CodeGen;
using System.Collections.Generic;
using System.Linq;

public struct SdpLiteUnPackGenerator : ISdpLiteCodeGenerator
{
    public static void WriteUnPack(CSharpCodeWriter writer, string nameSpace, SdpLiteStruct sdpStruct, IEnumerable<SdpLiteStruct> structs)
    {
        string typeName = GeneratorUtils.TypeToName(sdpStruct.Type, nameSpace);
        writer.WriteLine($"public static void UnPack(SdpLite.Unpacker unpacker, SdpLite.DataType type, ref {typeName} value)");
        using (new CSharpCodeWriter.Scop(writer))
        {
            writer.WriteLine("if(type != SdpLite.DataType.StructBegin)");
            writer.WriteLine("    SdpLite.Unpacker.ThrowIncompatibleType(type);");
            if (sdpStruct.Type.IsClass && !sdpStruct.Type.IsAbstract)
            {
                writer.WriteLine("if(value == null)");
                writer.WriteLine($"    value = new {typeName}();");
            }

            //写入0值，有些字段有默认值，如果序列化时为0，则反序列化因为没有处理该字段则会保持默认值
            foreach (var field in sdpStruct.Fields)
            {
                if (field.FieldType > SdpLiteStructType.Float)
                    continue;
                writer.WriteLine($"value.{field.Info.Name} = default;");
            }
            using (new CSharpCodeWriter.DoWhileScop(writer))
            {

                writer.WriteLine("var headerSize = unpacker.PeekHeader(out var header);");
                writer.WriteLine($" unpacker.SkipBytes(headerSize);");
                writer.WriteLine("if(header.type == SdpLite.DataType.StructEnd)");
                using (new CSharpCodeWriter.Scop(writer))
                {
                    writer.WriteLine("break;");
                }
                writer.WriteLine("switch(header.tag)");
                using (new CSharpCodeWriter.Scop(writer))
                {
                    //TODO：字段列表
                    if (sdpStruct.BaseClass != null)
                    {
                        writer.WriteLine($"case 0:");
                        writer.WriteLine($"    {GeneratorUtils.TypeToName(sdpStruct.BaseClass.Type, nameSpace)} baseClass = value;");
                        writer.WriteLine($"    UnPack(unpacker, SdpLite.DataType.StructBegin, ref baseClass);");
                        writer.WriteLine($"    break;");
                    }
                    foreach (var field in sdpStruct.Fields)
                    {
                        if (field.FieldType == SdpLiteStructType.CustomStruct)
                        {
                            var s = structs.FirstOrDefault(it => it.Type == field.Info.FieldType);
                            if (s == null || s.IsEmpty())
                                continue;
                        }
                        writer.WriteLine($"case {field.Index}:");
                        switch (field.FieldType)
                        {
                            case SdpLiteStructType.Enum:
                                writer.WriteLine($"    int tmp_{field.Info.Name} = (int)value.{field.Info.Name};");
                                writer.WriteLine($"    UnPack(unpacker, header.type, ref tmp_{field.Info.Name});");
                                writer.WriteLine($"    value.{field.Info.Name} = ({GeneratorUtils.TypeToName(field.Info.FieldType, nameSpace)})tmp_{field.Info.Name};");
                                break;
                            case SdpLiteStructType.Integer:
                            case SdpLiteStructType.Float:
                            case SdpLiteStructType.String:
                                writer.WriteLine($"    UnPack(unpacker, header.type, ref value.{field.Info.Name});");
                                break;
                            case SdpLiteStructType.Vector:
                                writer.WriteLine($"    UnPack(unpacker, header.type, ref value.{field.Info.Name}, UnPack);");
                                break;
                            case SdpLiteStructType.Map:
                                writer.WriteLine($"    UnPack(unpacker, header.type, ref value.{field.Info.Name}, UnPack, UnPack);");
                                break;
                            case SdpLiteStructType.CustomStruct:
                            case SdpLiteStructType.BuiltInStruct:
                                writer.WriteLine($"    UnPack(unpacker, header.type, ref value.{field.Info.Name});");
                                break;
                        }
                        writer.WriteLine("    break;");
                    }
                    writer.WriteLine("default:");
                    writer.WriteLine("    unpacker.SkipField(header.type);");
                    writer.WriteLine("    break;");
                }
            }

        }
    }

    public static void WriteDeSerialize(CSharpCodeWriter writer, string nameSpace, SdpLiteStruct sdpStruct)
    {
        string typeName = GeneratorUtils.TypeToName(sdpStruct.Type, nameSpace);
        writer.WriteLine($"public static void DeSerialize({typeName} result, byte[] data)");

        using (new CSharpCodeWriter.Scop(writer))
        {
            writer.WriteLine("SdpLite.Unpacker unpacker = new SdpLite.Unpacker(data);");
            writer.WriteLine("var header = unpacker.UnpackHeader();");
            writer.WriteLine("UnPack(unpacker, header.type, ref result);");
        }
    }

    public string GenerateCode(IEnumerable<SdpLiteStruct> structs, SdpLiteStructCatalog catalog)
    {
        CSharpCodeWriter writer = new CSharpCodeWriter();
        writer.WriteLine("//工具自动生成，切勿手动修改");
        using (new CSharpCodeWriter.NameSpaceScop(writer, catalog.NameSpace))
        {
            writer.WriteLine($"public partial class {catalog.ClassName}UnPack : {catalog.UnPackBaseClassName}");
            using (new CSharpCodeWriter.Scop(writer))
            {
                foreach (var val in structs)
                {
                    WriteUnPack(writer, catalog.NameSpace, val, structs);
                }
                foreach (var val in structs)
                {
                    if (val.GenSerializeFunction)
                    {
                        WriteDeSerialize(writer, catalog.NameSpace, val);
                    }
                }
            }
        }
        return writer.ToString();
    }
}
