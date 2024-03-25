using UnityEngine.UIElements;

namespace PropertyEditor
{
    public class TInputElement<T, TValue> : IPropertyElement where T : TextValueField<TValue>, new()
    {
        private readonly T inputField = new T();
        public VisualElement Element => inputField;
        public void Bind(string label, string toolTip, IPropertyEditorContext context)
        {
            inputField.label = label;
            inputField.tooltip = toolTip;
            inputField.RegisterValueChangedCallback((evt) => context.OnPropertyModify());
        }

        public object GetValue()
        {
            return inputField.value;
        }

        public void SetLabelActive(bool active)
        {
            inputField.labelElement.style.display = active ? DisplayStyle.Flex : DisplayStyle.None;
        }

        public void SetLabelMinWidth(float minWidth)
        {
            inputField.labelElement.style.minWidth = minWidth;
        }

        public void SetReadOnly(bool readOnly)
        {
            inputField.isReadOnly = readOnly;
        }

        public void SetValue(object value)
        {
            inputField.SetValueWithoutNotify((TValue)value);
        }
    }
}
