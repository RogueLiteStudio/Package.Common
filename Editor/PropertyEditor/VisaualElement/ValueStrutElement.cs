using System;
using UnityEngine.UIElements;

namespace PropertyEditor
{
    public class ValueStrutElement : IPropertyElement
    {
        public VisualElement Element => throw new NotImplementedException();

        public void Bind(string label, string toolTip, IPropertyEditorContext context)
        {
            throw new NotImplementedException();
        }

        public object GetValue()
        {
            throw new NotImplementedException();
        }

        public void SetLabelActive(bool active)
        {
            throw new NotImplementedException();
        }

        public void SetLabelMinWidth(float minWidth)
        {
            throw new NotImplementedException();
        }

        public void SetReadOnly(bool readOnly)
        {
            throw new NotImplementedException();
        }

        public void SetValue(object value)
        {
            throw new NotImplementedException();
        }
    }
}
