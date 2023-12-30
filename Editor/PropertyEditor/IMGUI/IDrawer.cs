using UnityEngine;

namespace PropertyEditor
{
    public interface IDrawer
    {
        bool Draw(GUIContent content, object val, IPropertyEditorContext context);
        object GetValue();
    }
}