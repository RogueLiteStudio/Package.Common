using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class EditorAssetUtil
{
    public static Texture2D GetAssetIcon(System.Type type)
    {
        return AssetPreview.GetMiniTypeThumbnail(type);
    }

    //查找指定目录下的指定类型的资源
    //相对于Unity的AssetDatabase.FindAssets，这个方法是直接查找文件，不需要先导入资源
    //因为没有直接加载资源，所以速度会比较快
    public static List<string> FindAsset<T>(string path, bool includeChildrenType) where T : Object
    {
        var files = Directory.GetFiles(path, "*.asset", SearchOption.AllDirectories);
        var result = new List<string>();
        var type = typeof(T);
        foreach (var file in files)
        {
            string assetPath = file.Replace("\\", "/");
            var assetType = AssetDatabase.GetMainAssetTypeAtPath(assetPath);
            if (assetType == type || (includeChildrenType && assetType.IsSubclassOf(type)))
            {
                result.Add(assetPath);
            }
        }
        return result;
    }
    public static List<string> FindAsset<T>(string path, string searchPattern = "*.asset", SearchOption searchOption = SearchOption.AllDirectories)
    {
        var files = Directory.GetFiles(path, searchPattern, searchOption);
        var result = new List<string>();
        var type = typeof(T);
        foreach (var file in files)
        {
            string assetPath = file.Replace("\\", "/");
            var assetType = AssetDatabase.GetMainAssetTypeAtPath(assetPath);
            if (type.IsAssignableFrom(assetType))
            {
                result.Add(assetPath);
            }
        }
        return result;
    }

    public static Dictionary<string, System.Type> FindAssetWithType<T>(string path, string searchPattern = "*.asset", SearchOption searchOption = SearchOption.AllDirectories)
    {
        var result = new Dictionary<string, System.Type>();
        var type = typeof(T);
        var files = Directory.GetFiles(path, searchPattern, searchOption);
        foreach (var file in files)
        {
            string assetPath = file.Replace("\\", "/");
            var assetType = AssetDatabase.GetMainAssetTypeAtPath(assetPath);
            if (assetType == type || type.IsAssignableFrom(assetType))
            {
                result.Add(assetPath, assetType);
            }
        }
        return result;
    }
}