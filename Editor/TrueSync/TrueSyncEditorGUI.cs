using TrueSync;
using UnityEditor;
using UnityEngine;

public static class TrueSyncEditorGUI
{
    public static TFloat FloatField(Rect position, TFloat value)
    {
        return EditorGUI.FloatField(position, (float)value);
    }
    public static TFloat FloatField(Rect position, string label, TFloat value)
    {
        return EditorGUI.FloatField(position, label, (float)value);
    }
    public static TFloat FloatField(Rect position, GUIContent label, TFloat value)
    {
        return EditorGUI.FloatField(position, label, (float)value);
    }

    public static TVector2 Vector2Field(Rect position, TVector2 value)
    {
        Vector2 result = EditorGUI.Vector2Field(position, GUIContent.none, value.ToVec2());
        return result.ToTVec2();
    }
    public static TVector2 Vector2Field(Rect position, string label, TVector2 value)
    {
        Vector2 result = EditorGUI.Vector2Field(position, label, value.ToVec2());
        return result.ToTVec2();
    }
    public static TVector2 Vector2Field(Rect position, GUIContent label, TVector2 value)
    {
        Vector2 result = EditorGUI.Vector2Field(position, label, value.ToVec2());
        return result.ToTVec2();
    }

    public static TVector3 Vector3Field(Rect position, TVector3 value)
    {
        Vector3 result = EditorGUI.Vector3Field(position, GUIContent.none, value.ToVec3());
        return result.ToTVec3();
    }

    public static TVector3 Vector3Field(Rect position, string label, TVector3 value)
    {
        Vector3 result = EditorGUI.Vector3Field(position, label, value.ToVec3());
        return result.ToTVec3();
    }
    public static TVector3 Vector3Field(Rect position, GUIContent label, TVector3 value)
    {
        Vector3 result = EditorGUI.Vector3Field(position, label, value.ToVec3());
        return result.ToTVec3();
    }
}
