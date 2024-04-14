using CodeGen;
using System.Collections.Generic;
using System.Linq;

public struct SdpLiteParamPackGenerator : ISdpLiteCodeGenerator
{
    public static void WritePackField(CSharpCodeWriter writer, SdpLiteFieldInfo field)
    {
        switch (field.FieldType)
        {
            case SdpLiteStructType.Enum:
                writer.WriteLine($"Pack(packer, {field.Index}, false, (int){SdpLiteGeneratorUtils.ToParamName(field)});");
                break;
            case SdpLiteStructType.Integer:
            case SdpLiteStructType.Float:
            case SdpLiteStructType.String:
            case SdpLiteStructType.BuiltInStruct:
            case SdpLiteStructType.CustomStruct:
                writer.WriteLine($"Pack(packer, {field.Index}, false, {SdpLiteGeneratorUtils.ToParamName(field)});");
                break;
            case SdpLiteStructType.Vector:
                writer.WriteLine($"Pack(packer, {field.Index}, false, {SdpLiteGeneratorUtils.ToParamName(field)}, Pack);");
                break;
            case SdpLiteStructType.Map:
                writer.WriteLine($"Pack(packer, {field.Index}, false, {SdpLiteGeneratorUtils.ToParamName(field)}, Pack, Pack);");
                break;
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
                foreach (var sdpStruct in structs)
                {
                    if (sdpStruct.IsEmpty() || sdpStruct.IsBuiltIn)
                        continue;
                    writer.WriteLine($"public static void {sdpStruct.Type.Name}(SdpLite.Packer packer, {SdpLiteGeneratorUtils.ToParamList(sdpStruct, true)})");
                    using (new CSharpCodeWriter.Scop(writer))
                    {
                        writer.WriteLine("var positoin0 = packer.Position;");
                        writer.WriteLine("packer.PackHeader(0, SdpLite.DataType.StructBegin);");
                        writer.WriteLine("var prePositoin = packer.Position;");
                        if (sdpStruct.BaseClass != null && !sdpStruct.BaseClass.IsEmpty())
                        {
                            writer.WriteLine($"{sdpStruct.BaseClass.Type.Name}({SdpLiteGeneratorUtils.ToParamList(sdpStruct.BaseClass, false)});");
                        }
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
                        writer.WriteLine("if(packer.Position == prePositoin)");
                        writer.WriteLine("    packer.Rewind(positoin0);");
                        writer.WriteLine("else");
                        writer.WriteLine("    packer.PackHeader(0, SdpLite.DataType.StructEnd);");
                    }
                }
            }
        }
        return writer.ToString();
    }
}

