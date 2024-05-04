using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class SearchableGUILayout
{

    public static int PopInt(int selectKey, IEnumerable<KeyValuePair<int, string>> list, params GUILayoutOption[] options)
    {
        var position = EditorGUILayout.GetControlRect(false, 18f, EditorStyles.popup, options);
        return SearchableGUI.PopInt(position, selectKey, list);
    }

    public static int PopInt(string lable, int selectKey, IEnumerable<KeyValuePair<int, string>> list, params GUILayoutOption[] options)
    {
        using(new GUILayout.HorizontalScope())
        {
            GUILayout.Label(lable);
            var position = EditorGUILayout.GetControlRect(false, 18f, EditorStyles.popup, options);
            return SearchableGUI.PopInt(position, selectKey, list);
        }
    }

    public static string PopString(string selectKey, IEnumerable<KeyValuePair<string, string>> list, params GUILayoutOption[] options)
    {
        var position = EditorGUILayout.GetControlRect(false, 18f, EditorStyles.popup, options);
        return SearchableGUI.PopString(position, selectKey, list);
    }

    public static string PopString(string lable, string selectKey, IEnumerable<KeyValuePair<string, string>> list, params GUILayoutOption[] options)
    {
        using (new GUILayout.HorizontalScope())
        {
            GUILayout.Label(lable);
            var position = EditorGUILayout.GetControlRect(false, 18f, EditorStyles.popup, options);
            return SearchableGUI.PopString(position, selectKey, list);
        }
    }

    public static T PopEnum<T>(T selectKey, params GUILayoutOption[] options) where T : System.Enum
    {
        var position = EditorGUILayout.GetControlRect(false, 18f, EditorStyles.popup, options);
        return SearchableGUI.PopEnum(position, selectKey);
    }

    public static T PopEnum<T>(string lable, T selectKey, params GUILayoutOption[] options) where T : System.Enum
    {
        using (new GUILayout.HorizontalScope())
        {
            GUILayout.Label(lable);
            var position = EditorGUILayout.GetControlRect(false, 18f, EditorStyles.popup, options);
            return SearchableGUI.PopEnum(position, selectKey);
        }
        }
}