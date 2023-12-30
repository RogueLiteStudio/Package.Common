using UnityEditor;

namespace PropertyEditor
{
    public class BoolDrwer : ValueDrawer<bool>
    {
        protected override void DoDraw(object val, IPropertyEditorContext context)
        {
            Value = EditorGUILayout.Toggle((bool)val);
        }
    }

}