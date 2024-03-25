using UnityEngine.UIElements;

namespace PropertyEditor
{
    public class TextFieldElement : TextField, IPropertyElement
    {
        public VisualElement Element => this;

        public void Bind(string label, string toolTip, IPropertyEditorContext context)
        {
            this.label = label;
            this.tooltip = toolTip;
            this.RegisterValueChangedCallback(evt => context.OnPropertyModify());
        }

        public object GetValue()
        {
            return value;
        }

        public void SetLabelActive(bool active)
        {
            labelElement.style.display = active ? DisplayStyle.Flex : DisplayStyle.None;
        }

        public void SetLabelMinWidth(float minWidth)
        {
            labelElement.style.minWidth = minWidth;
        }

        public void SetReadOnly(bool readOnly)
        {
            isReadOnly = readOnly;
        }

        public void SetValue(object value)
        {
            string v = value as string;
            if (v == null)
                v = string.Empty;
            SetValueWithoutNotify(v);
        }
    }
}
