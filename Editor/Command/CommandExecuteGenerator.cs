using CodeGen;
using System;
using System.Linq;

internal static class CommandExecuteGenerator
{
    public static void Gen<TExecuteContext, TExecute>(CommandGenerator.CommandInfo info, string path)
    {
        var exeContextName = GeneratorUtils.ToTypeName<TExecuteContext>();
        var existExecute = TypeCollector<TExecute>.Types.ToDictionary(it => it.Name);
        string baseClassName = $"T{typeof(TExecute).Name}";
        string nameSpace = typeof(TExecute).Namespace;
        if (exeContextName.StartsWith(nameSpace))
        {
            exeContextName = exeContextName.Substring(nameSpace.Length + 1);
        }
        foreach (var t in info.Types)
        {
            var typeName = GeneratorUtils.TypeToName(t);
            var name = t.Name;
            if (name.EndsWith("Command"))
            {
                name = name.Substring(0, name.Length - 7);
            }
            string className = $"{name}Execute";
            if (existExecute.ContainsKey(className))
                continue;
            string filePath = System.IO.Path.Combine(path, $"{name}Execute.cs");
            FileUtil.WriteFile(filePath, ToExecute(t, nameSpace, className, baseClassName, exeContextName));
        }

        string bindPath = System.IO.Path.Combine(path, $"{typeof(TExecute).Name}Binder.cs");
        CSharpCodeWriter writer = new CSharpCodeWriter();
        writer.WriteLine("using System.Collections.Generic;");
        string baseExecuteName = GeneratorUtils.ToTypeName<TExecute>();
        using (new CSharpCodeWriter.Scop(writer, $"public static class {typeof(TExecute).Name}Binder"))
        {
            using (new CSharpCodeWriter.Scop(writer, $"public static readonly Dictionary<int, {baseExecuteName}> executes = new Dictionary<int, {baseExecuteName}>()", true))
            {
                foreach (var t in info.Types)
                {
                    string typeName = GeneratorUtils.TypeToName(t);
                    string name = t.Name;
                    if (name.EndsWith("Command"))
                    {
                        name = name.Substring(0, name.Length - 7);
                    }
                    string className = $"{nameSpace}.{name}Execute";
                    writer.WriteLine($"{{CommandIdentity<{typeName}>.Id, new {className}() }},");
                }
            }
            using(new CSharpCodeWriter.Scop(writer, $"public static {baseExecuteName} GetExecuter(int commandId)"))
            {
                writer.WriteLine("executes.TryGetValue(commandId, out var execute);");
                writer.WriteLine("return execute;");
            }
        }
        FileUtil.WriteFile(bindPath, writer.ToString());
    }

    private static string ToExecute(Type type, string nameSpace, string className, string baseClassName, string exeContextName)
    {
        var typeName = GeneratorUtils.TypeToName(type);
        CSharpCodeWriter writer = new CSharpCodeWriter();
        if (typeName.StartsWith(nameSpace + "."))
        {
            typeName = typeName.Substring(nameSpace.Length + 2);
        }

        using(new CSharpCodeWriter.NameSpaceScop(writer, nameSpace))
        {
            using (new CSharpCodeWriter.Scop(writer, $"public class {className} : {baseClassName}<{typeName}>"))
            {
                using (new CSharpCodeWriter.Scop(writer, $"protected override void OnExecute({exeContextName} context, {typeName} command)"))
                {
                    writer.WriteLine("throw new System.NotImplementedException();");
                }
            }
        }
        return writer.ToString();
    }
}
