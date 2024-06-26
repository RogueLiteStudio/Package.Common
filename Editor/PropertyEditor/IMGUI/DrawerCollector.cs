using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
namespace PropertyEditor
{
    public class DrawerCollector
    {
        static DrawerCollector _instance;
        private Dictionary<Type, Type> drawerTypes = new Dictionary<Type, Type>();
        public static DrawerCollector Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DrawerCollector();
                }
                return _instance;
            }
        }

        private DrawerCollector()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                if (assembly.FullName.StartsWith("Unity") 
                    || assembly.FullName.StartsWith("com.unity")
                    || assembly.FullName.StartsWith("System")
                    || assembly.FullName.StartsWith("mscorlib") )
                {
                    continue;
                }
                Type[] types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsAbstract || type.IsInterface || type.IsGenericType)
                        continue;
                    if (!typeof(IDrawer).IsAssignableFrom(type))
                        continue;
                    var baseType = type.BaseType;
                    while (baseType != null)
                    {
                        if (baseType.IsGenericType)
                        {
                            drawerTypes[baseType.GenericTypeArguments[0]] = type;
                            break;
                        }
                        baseType = baseType.BaseType;
                    }
                }
            }
        }

        public static IDrawer CreatContainerDrawer(FieldInfo field, Type elememtType)
        {
            var custom = field.GetCustomAttribute<PropertyCustomDrawerAttribute>();
            if (custom != null && custom.TypeCheck(elememtType))
            {
                if (Instance.drawerTypes.TryGetValue(custom.GetType(), out Type drawerType))
                {
                    var drawer = Activator.CreateInstance(drawerType) as CustomDrawerBase;
                    if (drawer != null)
                    {
                        drawer.SetAttribute(custom);
                        return drawer;
                    }
                }
            }
            if (elememtType.IsEnum && field.GetCustomAttribute<EnumMaskAttribute>() != null)
            {
                return new EnumMaskDrawer(elememtType);
            }
            return CreateDrawer(elememtType);
        }

        public static IDrawer CreateDrawer(FieldInfo field)
        {
            if (field.IsStatic || !field.IsPublic 
                || field.GetCustomAttribute<UnityEngine.HideInInspector>() != null
                || field.GetCustomAttribute<InspectorIgnoreAttribute>() != null)
                return null;
            //自定义编辑类型放在最前，可以支持对List类型的重写
            var custom = field.GetCustomAttribute<PropertyCustomDrawerAttribute>();
            if (custom != null && custom.TypeCheck(field.FieldType))
            {
                if (Instance.drawerTypes.TryGetValue(custom.GetType(), out Type drawerType))
                {
                    if (Activator.CreateInstance(drawerType) is CustomDrawerBase drawer)
                    {
                        drawer.SetAttribute(custom);
                        return drawer;
                    }
                }
            }
            if (!IsList(field.FieldType))
            {
                if (field.FieldType.IsEnum && field.GetCustomAttribute<EnumMaskAttribute>() != null)
                {
                    return new EnumMaskDrawer(field.FieldType);
                }
            }
            else
            {
                return new ListDrawer(field);
            }
            return CreateDrawer(field.FieldType);
        }

        public static IDrawer CreateDrawer(Type type)
        {
            if (Instance.drawerTypes.TryGetValue(type, out Type drawerType))
            {
                var drawer = Activator.CreateInstance(drawerType) as IDrawer;
                return drawer;
            }
            if(type == null || type == typeof(object))
                return null;
            if (type.IsEnum)
            {
                return new EnumDrawer(type);
            }
            if (type.IsSubclassOf(typeof(UnityEngine.Object)))
            {
                return new UnityObjectDrawer(type);
            }
            if (type.IsValueType)
            {
                if (type == typeof(short)  || type == typeof(long))
                {
                    return new IntDrawer();
                }
                else if (type == typeof(ushort) || type == typeof(ulong))
                {
                    return new UintDrawer();
                }
                else if (type == typeof(double))
                {
                    return new FloatDrawer();
                }

                return new StructTypeDrawer(type);
            }
            else if (type.IsGenericType && typeof(IEnumerable).IsAssignableFrom(type))
            {
                //只支持List容器
                return null;
            }
            return new ClassTypeDrawer(type);
        }

        public static bool IsList(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }
    }

}
