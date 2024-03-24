using UnityEngine.UIElements;

namespace PropertyEditor
{
    public interface IPropertyElement
    {
        VisualElement Element { get; }
        void Bind(string label, IPropertyEditorContext context);
        void SetValue(object value);
        object GetValue();
        void SetLabelMinWidth(float minWidth);
        void SetLabelActive(bool active);
        void SetReadOnly(bool readOnly);
    }
}
