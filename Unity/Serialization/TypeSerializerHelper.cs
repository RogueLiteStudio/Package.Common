using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
public static class TypeSerializerHelper
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Tools/生成GUID到剪切板")]
    static void GenGUID()
    {
        GUIUtility.systemCopyBuffer = string.Format("\"{0}\"", Guid.NewGuid().ToString());
    }
#endif

    private static Dictionary<string, Type> _typeGUIDs;
    public static Dictionary<string, Type> TypeGUIDs
    {
        get
        {
            if (_typeGUIDs == null)
            {
                _typeGUIDs = new Dictionary<string, Type>();
                foreach (var assemble in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (var type in assemble.GetTypes())
                    {
                        if (type.IsInterface || type.IsAbstract)
                            continue;
                        TypeIdentifyAttribute typeIdentify = type.GetCustomAttribute<TypeIdentifyAttribute>();
                        if (typeIdentify != null && !string.IsNullOrEmpty(typeIdentify.GUID))
                        {
                            if (_typeGUIDs.TryGetValue(typeIdentify.GUID, out Type exitType))
                            {
                                Debug.LogErrorFormat("类型 {0} 和 {1} 的GUID重复，将被跳过", type.FullName, exitType.FullName);
                                continue;
                            }
                            else
                            {
                                _typeGUIDs.Add(typeIdentify.GUID, type);
                            }
                        }
                    }
                }

            }
            return _typeGUIDs;
        }
    }
    public static SerializationData Serialize(object obj)
    {
        if (obj == null)
        {
            throw new Exception("序列化目标对象不能为null");
        }
        SerializationData elem = new SerializationData
        {
            Type = obj.GetType().FullName
        };
        TypeIdentifyAttribute typeIdentify = obj.GetType().GetCustomAttribute<TypeIdentifyAttribute>();
        if (typeIdentify != null)
        {
            elem.TypeGUID = typeIdentify.GUID;
        }
        //if (string.IsNullOrWhiteSpace(elem.TypeGUID))
        //{
        //    Debug.LogErrorFormat("序列化类型 {0} 缺少TypeIdentify 属性，类重名将会丢失数据", elem.Type);
        //}
#if UNITY_EDITOR
        elem.JsonDatas = UnityEditor.EditorJsonUtility.ToJson(obj);
#else
        elem.JsonDatas = UnityEngine.JsonUtility.ToJson(obj);
#endif

        return elem;
    }

    public static object Deserialize(SerializationData e)
    {
        Type type = null;
        if (string.IsNullOrEmpty(e.TypeGUID) || !TypeGUIDs.TryGetValue(e.TypeGUID, out type))
        {
            if (!string.IsNullOrEmpty(e.Type))
                type = Type.GetType(e.Type);
        }
        if (type == null)
        {
            Debug.LogErrorFormat("反序列化失败，缺少类型 {0}, json数据:\n {1}", e.Type, e.JsonDatas);
            return null;
        }

        var obj = Activator.CreateInstance(type);
#if UNITY_EDITOR
        UnityEditor.EditorJsonUtility.FromJsonOverwrite(e.JsonDatas, obj);
#else
		UnityEngine.JsonUtility.FromJsonOverwrite(e.JsonDatas, obj);
#endif

        return obj;
    }

}