using TrueSync;
using UnityEditor;
using UnityEngine;
public static class TrueSyncEditorGUILayout
{
    public static TFloat FloatField(TFloat value, params GUILayoutOption[] options)
    {
        return EditorGUILayout.FloatField((float)value, options);
    }

    public static TFloat FloatField(string label, TFloat value, params GUILayoutOption[] options)
    {
        return EditorGUILayout.FloatField(label, (float)value, options);
    }
    public static TFloat FloatField(GUIContent label, TFloat value, params GUILayoutOption[] options)
    {
        return EditorGUILayout.FloatField(label, (float)value, options);
    }

    public static TVector2 Vector2Field(TVector2 value, params GUILayoutOption[] options)
    {
        Vector2 result = EditorGUILayout.Vector2Field(GUIContent.none, value.ToVec2(), options);
        return result.ToTVec2();
    }

    public static TVector2 Vector2Field(string label, TVector2 value, params GUILayoutOption[] options)
    {
        Vector2 result = EditorGUILayout.Vector2Field(label, value.ToVec2(), options);
        return result.ToTVec2();
    }

    public static TVector2 Vector2Field(GUIContent label, TVector2 value, params GUILayoutOption[] options)
    {
        Vector2 result = EditorGUILayout.Vector2Field(label, value.ToVec2(), options);
        return result.ToTVec2();
    }

    public static TVector3 Vector3Field(TVector3 value, params GUILayoutOption[] options)
    {
        Vector3 result = EditorGUILayout.Vector3Field(GUIContent.none, value.ToVec3(), options);
        return result.ToTVec3();
    }

    public static TVector3 Vector3Field(string label, TVector3 value, params GUILayoutOption[] options)
    {
        Vector3 result = EditorGUILayout.Vector3Field(label, value.ToVec3(), options);
        return result.ToTVec3();
    }

    public static TVector3 Vector3Field(GUIContent label, TVector3 value, params GUILayoutOption[] options)
    {
        Vector3 result = EditorGUILayout.Vector3Field(label, value.ToVec3(), options);
        return result.ToTVec3();
    }
}
