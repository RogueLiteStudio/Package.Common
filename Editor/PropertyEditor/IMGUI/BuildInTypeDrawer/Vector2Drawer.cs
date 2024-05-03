using UnityEditor;
using UnityEngine;
namespace PropertyEditor
{
    public class Vector2Drawer : ValueDrawer<Vector2>
    {
        protected override void DoDraw(object val, IPropertyEditorContext context)
        {
            Value = EditorGUILayout.Vector2Field("", (Vector2)val);
        }
    }

    public class TVector2Drawer : ValueDrawer<TrueSync.TVector2>
    {
        protected override void DoDraw(object val, IPropertyEditorContext context)
        {
            Value = EditorGUILayout.Vector2Field("", ((TrueSync.TVector2)val).ToVec2()).ToTVec2();
        }
    }
}