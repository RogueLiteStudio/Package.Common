using UnityEditor;
namespace PropertyEditor
{
    public class FloatDrawer : ValueDrawer<float>
    {
        protected override void DoDraw(object val, IPropertyEditorContext context)
        {
            Value = EditorGUILayout.FloatField(Value);
        }
    }
    public class TFloatDrawer : ValueDrawer<TrueSync.TFloat>
    {
        protected override void DoDraw(object val, IPropertyEditorContext context)
        {
            Value = EditorGUILayout.FloatField((float)Value);
        }
    }
}