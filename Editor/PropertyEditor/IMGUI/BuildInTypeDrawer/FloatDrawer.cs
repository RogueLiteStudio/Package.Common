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

}