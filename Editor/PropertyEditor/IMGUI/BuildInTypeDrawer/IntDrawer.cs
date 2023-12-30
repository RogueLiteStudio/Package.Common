using UnityEditor;
namespace PropertyEditor
{
    public class IntDrawer : ValueDrawer<int>
    {
        protected override void DoDraw(object val, IPropertyEditorContext context)
        {
            Value = EditorGUILayout.IntField(Value);
        }
    }

}