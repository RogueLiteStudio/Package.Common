using System;
using UnityEngine.UIElements;

namespace PropertyEditor
{
    public class TCompositeElement<T, TValueType, TField, TFieldValue> : IPropertyElement where T : BaseCompositeField<TValueType, TField, TFieldValue>, new() where TField : TextValueField<TFieldValue>, new()
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
            inputField.SetEnabled(!readOnly);
        }

        public void SetValue(object value)
        {
            inputField.SetValueWithoutNotify((TValueType)value);
        }
    }
}
