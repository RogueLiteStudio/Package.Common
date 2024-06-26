using System.Reflection;
using UnityEngine;
namespace PropertyEditor
{
    public class FieldDrawer
    {
        public FieldInfo Info;
        public IDrawer Drawer;
        public bool ExpendInParent;
        private readonly GUIContent Content;
        private readonly MethodInfo ValidMethod;

        public FieldDrawer(FieldInfo info, IDrawer drawer)
        {
            Info = info;
            Drawer = drawer;
            var display = info.GetCustomAttribute<DisplayNameAttribute>();
            Content = new GUIContent(display == null ? info.Name : display.Name, display != null ? display.ToolTip : "");
            var validFunc = info.GetCustomAttribute<ValidFuncAttribute>();
            if (validFunc != null)
            {
                ValidMethod = info.DeclaringType.GetMethod(validFunc.Name); 
            }
            ExpendInParent = info.GetCustomAttribute<ExpandInParentAttribute>() != null;
        }

        public bool Draw(object data, IPropertyEditorContext context)
        {
            if (Drawer == null || ValidMethod != null && !(bool)ValidMethod.Invoke(data, null))
                return false;
            if (Drawer.Draw(ExpendInParent ? null : Content, Info.GetValue(data), context))
            {
                context.OnPropertyModify();
                Info.SetValue(data, Drawer.GetValue());
                return true;
            }
            return false;
        }

        public static FieldDrawer Create(FieldInfo info)
        {
            IDrawer drawer = DrawerCollector.CreateDrawer(info);
            if (drawer == null)
                return null;
            return new FieldDrawer(info, drawer);
        }
    }

}