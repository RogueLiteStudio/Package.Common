using CodeGen;
using System;
using System.IO;
using System.Reflection;
using System.Text;

internal static class CommandExternGenerator
{
    public static void GenExtern(string exportPath, CommandGenerator.CommandInfo info)
    {
        //生成ID文件
        string idFile = Path.Combine(exportPath, $"{info.ContextName}Ids.cs");
        CSharpCodeWriter writer = new CSharpCodeWriter();
        using (new CSharpCodeWriter.Scop(writer, $"public static partial class {info.ContextName}Extern"))
        {
            using (new CSharpCodeWriter.Scop(writer, "public static void Init()"))
            {
                int idx = 1;
                foreach (var type in info.Types)
                {
                    writer.WriteLine($"CommandIdentity<{GeneratorUtils.TypeToName(type)}>.Id = {idx++};");
                }

            }
        }

        FileUtil.WriteFile(idFile, writer.ToString());

        string externFile = Path.Combine(exportPath, $"{info.ContextName}Extern.cs");
        writer = new CSharpCodeWriter();
        using (new CSharpCodeWriter.Scop(writer, $"public static partial class {info.ContextName}Extern"))
        {
            foreach (var type in info.Types)
            {
                if (type.GetCustomAttribute<NoneExternAttribute>() != null)
                    continue;
                WriteExtern(writer, type);
            }
        }
        FileUtil.WriteFile(externFile, writer.ToString());
    }

    private static void WriteExtern(CSharpCodeWriter writer, Type type)
    {
        string name = type.Name;
        if (name.EndsWith("Command"))
        {
            name = name.Substring(0, name.Length - 7);
        }
        string typeName = GeneratorUtils.TypeToName(type);
        string paramList = ToParamList(type);
        if (string.IsNullOrEmpty(paramList))
        {
            paramList = "this ICommandReceiver receiver";
        }
        else
        {
            paramList = $"this ICommandReceiver receiver{paramList}";
        }
        using (new CSharpCodeWriter.Scop(writer, $"public static void Add{name}({paramList})"))
        {
            writer.WriteLine($"var cmd = receiver.CreateCommand<{typeName}>();");
            writer.WriteLine("if(cmd == null) return;");
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var f in fields)
            {
                writer.WriteLine($"cmd.{f.Name} = new{f.Name};");
            }
        }
    }

    private static string ToParamList(Type type)
    {
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        if (fields.Length == 0)
            return string.Empty;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < fields.Length; ++i)
        {
            var field = fields[i];
            sb.Append(", ");
            sb.Append($"{GeneratorUtils.TypeToName(field.FieldType)} new{field.Name}");
        }
        return sb.ToString();
    }
}