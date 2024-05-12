using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CodeGen
{
    public static class GeneratorUtils
    {
        static Dictionary<Type, string> BuiltInType = new Dictionary<Type, string>
        {
            {typeof(long), "long" },
            {typeof(ulong), "ulong" },
            {typeof(int), "int" },
            {typeof(uint), "uint" },
            {typeof(short), "short" },
            {typeof(ushort), "ushort" },
            {typeof(byte), "byte" },
            {typeof(sbyte), "sbyte" },
            {typeof(bool), "bool" },
            {typeof(float), "float" },
            {typeof(double), "double" },
            {typeof(string), "string" },
        };
        public static string TypeToName(Type type, string nameSpace = null)
        {
            if (BuiltInType.TryGetValue(type, out string name))
                return FixedByNameSpace(name, nameSpace);
            if (type.IsGenericType)
            {
                var paramTypes = type.GenericTypeArguments;
                StringBuilder sb = new StringBuilder();
                string fullName = type.FullName;
                sb.Append(fullName.Substring(0, fullName.IndexOf('`')));
                sb.Append('<');
                for (int i=0; i<paramTypes.Length; ++i)
                {
                    if (i > 1)
                        sb.Append(',');
                    sb.Append(TypeToName(paramTypes[i]));
                }
                sb.Append('>');
                return sb.ToString();
            }
            return FixedByNameSpace(type.FullName, nameSpace);
        }

        public static string FixedByNameSpace(string typeName, string nameSpace)
        {
            if (!string.IsNullOrEmpty(nameSpace))
            {
                if (typeName.Length > nameSpace.Length && typeName.StartsWith(typeName))
                {
                    if (typeName[nameSpace.Length] == '.')
                        return typeName.Substring(nameSpace.Length + 1);
                }
            }
            return typeName;
        }

        public static string ToTypeName<T>()
        {
            return TypeToName(typeof(T));   
        }

        //写入文件，如果写入的内容和已经存在的一致就不再写入，防止文件被修改导致Unity重新编译
        public static void WriteToFile(string filePath, string context)
        {
            if (File.Exists(filePath))
            {
                string existContext = File.ReadAllText(filePath, Encoding.UTF8);
                if (existContext == context)
                    return;
            }
            else
            {
                string dir = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
            }
            File.WriteAllText(filePath, context, Encoding.UTF8);
        }

        public static void WriteReset(CSharpCodeWriter writer, List<FieldInfo> fields, System.Func<System.Type, string, string> customReset)
        {
            foreach (var field in fields)
            {
                if (customReset != null)
                {
                    string v = customReset(field.FieldType, field.Name);
                    if (!string.IsNullOrEmpty(v))
                    {
                        writer.WriteLine(v);
                        continue;
                    }
                }

                if (field.GetCustomAttribute<ResetToNullAttribute>() == null
                    && !field.FieldType.IsSubclassOf(typeof(UnityEngine.Object)))
                {
                    if (WriteReset(writer, field, "Clear"))
                        continue;
                    if (WriteReset(writer, field, "Reset()"))
                        continue;
                }
                if (field.FieldType == typeof(UnityEngine.Quaternion))
                {
                    writer.WriteLine($"value.{field.Name} = UnityEngine.Quaternion.identity;");
                    continue;
                }
                writer.WriteLine($"value.{field.Name} = default;");
            }
        }

        public static bool WriteReset(CSharpCodeWriter writer, FieldInfo field, string funcName)
        {
            var method = field.FieldType.GetMethod(funcName);
            if (method != null && method.IsPublic && !method.IsStatic && method.GetParameters().Length == 0)
            {
                if (field.FieldType.IsValueType)
                {
                    writer.WriteLine($"value.{field.Name}.{funcName}();");
                }
                else
                {
                    writer.WriteLine($"value.{field.Name}?.{funcName}();");
                }
                return true;
            }
            return false;
        }
    }
}