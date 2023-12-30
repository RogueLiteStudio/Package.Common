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
}