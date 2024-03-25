using System;
using UnityEngine.UIElements;

namespace PropertyEditor
{
    public class TRangeIntegerElement : IPropertyElement
    {
        private readonly RangeIntegerField integerField = new RangeIntegerField();
        public VisualElement Element => integerField;

        public TRangeIntegerElement(long minValue, long maxValue)
        {
            integerField.MinVaue = minValue;
            integerField.MaxVaue = maxValue;
        }

        public void Bind(string label, string toolTip, IPropertyEditorContext context)
        {
            integerField.label = label;
            integerField.tooltip = toolTip;
            integerField.RegisterValueChangedCallback(evt => context.OnPropertyModify());
        }

        public object GetValue()
        {
            return integerField.value;
        }

        public void SetLabelActive(bool active)
        {
            integerField.labelElement.style.display = active ? DisplayStyle.Flex : DisplayStyle.None;
        }

        public void SetLabelMinWidth(float minWidth)
        {
            integerField.labelElement.style.minWidth = minWidth;
        }

        public void SetReadOnly(bool readOnly)
        {
            integerField.isReadOnly = readOnly;
        }

        public void SetValue(object value)
        {
            integerField.SetValueWithoutNotify((long)value);
        }
    }
}
