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
        using (new CSharpCodeWriter.Scop(writer, $"public static class {typeof(TExecute).Name}Binder"))
        {
            foreach (var t in info.Types)
            {
                var name = t.Name;
                if (name.EndsWith("Command"))
                {
                    name = name.Substring(0, name.Length - 7);
                }
                string className = $"{name}Execute";
                writer.WriteLine($"CommandBinder.Bind<{GeneratorUtils.TypeToName(t)}, {className}>();");
            }
        }
    }

    private static string ToExecute(Type type, string nameSpace, string className, string baseClassName, string exeContextName)
    {
        var typeName = GeneratorUtils.TypeToName(type);
        CSharpCodeWriter writer = new CSharpCodeWriter();
        if (typeName.StartsWith(nameSpace))
        {
            typeName = typeName.Substring(nameSpace.Length + 1);
        }

        using(new CSharpCodeWriter.NameSpaceScop(writer, nameSpace))
        {
            using (new CSharpCodeWriter.Scop(writer, $"public class {className} : {baseClassName}<{typeName}>"))
            {
                using (new CSharpCodeWriter.Scop(writer, $"protected override void OnExecute({exeContextName} context, {typeName} command)"))
                {
                    writer.WriteLine($"//TODO: Implement {className}.OnExecute");
                }
            }
        }
        return writer.ToString();
    }
}
