using UnityEngine;
using UnityEngine.UIElements;

namespace PropertyEditor
{
    public class QuaternionElement : IPropertyElement
    {
        private readonly Vector3Field inputField = new Vector3Field();
        private Quaternion Value = Quaternion.identity;
        public VisualElement Element => inputField;

        public void Bind(string label, IPropertyEditorContext context)
        {
            inputField.label = label;
            inputField.RegisterValueChangedCallback((evt) => 
            {
                Value = Quaternion.Euler(evt.newValue);
                context.OnPropertyModify();
            });
        }

        public object GetValue()
        {
            return Value;
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
            Value = (Quaternion)value;
            inputField.SetValueWithoutNotify(Value.eulerAngles);
        }
    }
}
