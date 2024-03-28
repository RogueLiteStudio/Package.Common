using System;
namespace PropertyEditor
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public class CustomElementBuilderAttribute : Attribute
    {
        public readonly Type Type;
    }
}
