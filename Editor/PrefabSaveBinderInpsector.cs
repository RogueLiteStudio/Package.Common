﻿using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PrefabSaveBinder))]
public class PrefabSaveBinderInpsector : Editor
{
    static string DefautPath = "";
    public static string SaveFolder 
    {
        get
        {
            if (string.IsNullOrEmpty(DefautPath))
            {
                DefautPath = EditorPrefs.GetString("PrefabSaveBinderInpsector_SaveFolder", "Assets/");
            }
            return DefautPath;
        }
        set
        {
            DefautPath = value;
            EditorPrefs.SetString("PrefabSaveBinderInpsector_SaveFolder", value);
        }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("保存"))
        {
            PrefabSaveBinder binder = target as PrefabSaveBinder;
            string path = null;
            if (binder.Prefab)
            {
                path = AssetDatabase.GetAssetPath(binder.Prefab);
                if (string.IsNullOrEmpty(path))
                {
                    EditorUtility.DisplayDialog("提示", "关联的GameObject不是有效的Prefab", "确定");
                    return;
                }
            }
            else
            {
                path = EditorUtility.OpenFolderPanel("选择保存的文件夹", SaveFolder, "");
                if (string.IsNullOrEmpty(path))
                {
                    return;
                }
                int index = path.IndexOf("Assets/");
                if (index < 0)
                {
                    EditorUtility.DisplayDialog("提示", "请选择Assets目录下的文件夹", "确定");
                    return;
                }
                path = path.Substring(index);
                path = path.Replace('\\', '/');
                if (!path.EndsWith('/'))
                {
                    path += '/';
                }
                SaveFolder = path;
                path += binder.name + ".prefab";
            }
            var flag = binder.hideFlags;
            try
            {
                binder.hideFlags = HideFlags.DontSave;
                PrefabUtility.SaveAsPrefabAsset(binder.gameObject, path);
            }
            catch (System.Exception ex)
            {
                Debug.LogException(ex);
            }
            binder.hideFlags = flag;
        }
    }
}