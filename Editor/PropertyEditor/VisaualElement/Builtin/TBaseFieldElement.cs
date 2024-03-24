using UnityEngine.UIElements;

namespace PropertyEditor
{
    public class TBaseFieldElement<T, TValue> : IPropertyElement where T : BaseField<TValue>, new()
    {
        private readonly T field = new T();
        public VisualElement Element => field;

        public void Bind(string label, IPropertyEditorContext context)
        {
            field.label = label;
            field.RegisterValueChangedCallback((evt) => context.OnPropertyModify());
        }

        public object GetValue()
        {
            return field.value;
        }

        public void SetLabelActive(bool active)
        {
            field.labelElement.style.display = active ? DisplayStyle.Flex : DisplayStyle.None;
        }

        public void SetLabelMinWidth(float minWidth)
        {
            field.labelElement.style.minWidth = minWidth;
        }

        public void SetReadOnly(bool readOnly)
        {
            field.SetEnabled(!readOnly);
        }

        public void SetValue(object value)
        {
            field.value = (TValue)value;
        }
    }
}
