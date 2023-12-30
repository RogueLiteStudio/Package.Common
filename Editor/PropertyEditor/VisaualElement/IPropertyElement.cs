using UnityEngine.UIElements;

namespace PropertyEditor
{
    public interface IPropertyElement
    {
        VisualElement Build(string label, object val, IPropertyEditorContext context);
        void Refresh();
    }
}
