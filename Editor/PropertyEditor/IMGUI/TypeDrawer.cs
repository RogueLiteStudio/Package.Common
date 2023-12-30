using UnityEngine;
namespace PropertyEditor
{
    public abstract class TypeDrawer<T> : IDrawer
    {
        public abstract bool Draw(GUIContent content, object val, IPropertyEditorContext context);
        public abstract object GetValue();
    }

}