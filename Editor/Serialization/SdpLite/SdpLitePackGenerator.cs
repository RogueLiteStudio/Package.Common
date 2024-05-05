using CodeGen;
using System.Collections.Generic;
using System.Linq;

public struct SdpLitePackGenerator : ISdpLiteCodeGenerator
{
    public static void WritePackField(CSharpCodeWriter writer, SdpLiteFieldInfo field)
    {
        switch (field.FieldType)
        {
            case SdpLiteStructType.Enum:
                writer.WriteLine($"Pack(packer, {field.Index}, false, (int)value.{field.Info.Name});");
                break;
            case SdpLiteStructType.Integer:
            case SdpLiteStructType.Float:
            case SdpLiteStructType.String:
            case SdpLiteStructType.BuiltInStruct:
            case SdpLiteStructType.CustomStruct:
                writer.WriteLine($"Pack(packer, {field.Index}, false, value.{field.Info.Name});");
                break;
            case SdpLiteStructType.Vector:
                if (field.ExternType1 < SdpLiteStructType.String)
                {
                    //处理基础类型的隐式转换
                    writer.WriteLine($"Pack(packer, {field.Index}, false, value.{field.Info.Name}, SdpLitePacker.Pack);");
                }
                else
                {
                    writer.WriteLine($"Pack(packer, {field.Index}, false, value.{field.Info.Name}, Pack);");
                }
                break;
            case SdpLiteStructType.Map:
                string keyPack = "Pack";
                if (field.ExternType1 < SdpLiteStructType.String)
                    keyPack = "SdpLitePacker.Pack";
                string valuePack = "Pack";
                if (field.ExternType2 < SdpLiteStructType.String)
                    valuePack = "SdpLitePacker.Pack";
                writer.WriteLine($"Pack(packer, {field.Index}, false, value.{field.Info.Name}, {keyPack}, {valuePack});");
                break;
        }
    }

    public static void WritePack(CSharpCodeWriter writer, string nameSpace, SdpLiteStruct sdpStruct, IEnumerable<SdpLiteStruct> structs)
    {
        string typeName = GeneratorUtils.TypeToName(sdpStruct.Type, nameSpace);
        writer.WriteLine($"public static void Pack(SdpLite.Packer packer, uint tag, bool require, {typeName} value)");
        using (new CSharpCodeWriter.Scop(writer))
        {
            writer.WriteLine("var positoin0 = packer.Position;");
            writer.WriteLine("packer.PackHeader(tag, SdpLite.DataType.StructBegin);");
            writer.WriteLine("var prePositoin = packer.Position;");
            if (sdpStruct.BaseClass != null)
            {
                writer.WriteLine($"Pack(packer, 0, false, ({GeneratorUtils.TypeToName(sdpStruct.BaseClass.Type, nameSpace)})value);");
            }
            if (sdpStruct.Type.IsClass)
            {
                using(new CSharpCodeWriter.Scop(writer, "if(value != null)"))
                {
                    foreach (var field in sdpStruct.Fields)
                    {
                        if (field.FieldType == SdpLiteStructType.CustomStruct)
                        {
                            var s = structs.FirstOrDefault(it => it.Type == field.Info.FieldType);
                            if (s == null || s.IsEmpty())
                                continue;
                        }
                        WritePackField(writer, field);
                    }
                }
            }
            else
            {
                foreach (var field in sdpStruct.Fields)
                {
                    if (field.FieldType == SdpLiteStructType.CustomStruct)
                    {
                        var s = structs.FirstOrDefault(it => it.Type == field.Info.FieldType);
                        if (s == null || s.IsEmpty())
                            continue;
                    }
                    WritePackField(writer, field);
                }
            }
            writer.WriteLine("if(packer.Position == prePositoin && !require)");
            writer.WriteLine("    packer.Rewind(positoin0);");
            writer.WriteLine("else");
            writer.WriteLine("    packer.PackHeader(tag, SdpLite.DataType.StructEnd);");
        }
    }

    public static void WriteSerialize(CSharpCodeWriter writer, string nameSpace, SdpLiteStruct sdpStruct)
    {
        string typeName = GeneratorUtils.TypeToName(sdpStruct.Type, nameSpace);
        writer.WriteLine($"public static void Serialize({typeName} data, System.IO.MemoryStream memory)");
        using (new CSharpCodeWriter.Scop(writer))
        {
            writer.WriteLine("SdpLite.Packer packer = new SdpLite.Packer(memory);");
            writer.WriteLine("Pack(packer, 0, true, data);");
        }
    }

    public string GenerateCode(IEnumerable<SdpLiteStruct> structs, SdpLiteStructCatalog catalog)
    {
        CSharpCodeWriter writer = new CSharpCodeWriter();
        writer.WriteLine("//工具自动生成，切勿手动修改");
        using (new CSharpCodeWriter.NameSpaceScop(writer, catalog.NameSpace))
        {
            writer.WriteLine($"public partial class {catalog.ClassName}Pack : {catalog.PackBaseClassName}");
            using (new CSharpCodeWriter.Scop(writer))
            {
                foreach (var val in structs)
                {
                    WritePack(writer, catalog.NameSpace, val, structs);
                }
                foreach (var val in structs)
                {
                    if (val.GenSerializeFunction)
                    {
                        WriteSerialize(writer, catalog.NameSpace, val);
                    }
                }
            }
        }
        return writer.ToString();
    }
}
