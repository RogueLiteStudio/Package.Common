using UnityEditor;
using UnityEngine;

namespace PropertyEditor
{
    public class Vector3Drawer : ValueDrawer<Vector3>
    {
        protected override void DoDraw(object val, IPropertyEditorContext context)
        {
            Value = EditorGUILayout.Vector3Field("",(Vector3)val);
        }
    }
    public class TVector3Drawer : ValueDrawer<TrueSync.TVector3>
    {
        protected override void DoDraw(object val, IPropertyEditorContext context)
        {
            Value = EditorGUILayout.Vector3Field("", ((TrueSync.TVector3)val).ToVec3()).ToTVec3();
        }
    }
}
