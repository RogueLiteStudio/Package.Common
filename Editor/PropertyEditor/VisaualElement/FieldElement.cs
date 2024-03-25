using System.Reflection;
namespace PropertyEditor
{
    public struct FieldElement
    {
        public bool IsValueField;
        public FieldInfo Info;
        public IPropertyElement PropertyElement;
        public MethodInfo ValidMethod;
        public static FieldElement Build(FieldInfo info, IPropertyEditorContext context)
        {
            FieldElement field = new FieldElement();
            field.Info = info;
            do 
            {
                if (!info.IsPublic || info.IsStatic)
                    break;
                if (info.GetCustomAttribute<UnityEngine.HideInInspector>() != null)
                    break;
                field.IsValueField = info.FieldType.IsValueType || info.FieldType == typeof(string);

                field.PropertyElement = PropertyElementBuildUtil.Create(info);
                if (field.PropertyElement == null)
                    break;

                var validFunc = info.GetCustomAttribute<ValidFuncAttribute>();
                if (validFunc != null)
                    field.ValidMethod = info.DeclaringType.GetMethod(validFunc.Name);
                var display = info.GetCustomAttribute<DisplayNameAttribute>();
                string label = display == null ? info.Name : display.Name;
                string toolTip = display != null ? display.ToolTip : "";
                var toolTipAttr = info.GetCustomAttribute<UnityEngine.TooltipAttribute>();
                if (toolTipAttr != null)
                    toolTip = toolTipAttr.tooltip;
                field.PropertyElement.Bind(label, toolTip, context);
            } while (false);
            return field;
        }
    }
}
