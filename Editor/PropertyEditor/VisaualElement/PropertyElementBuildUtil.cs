using System;
using System.Reflection;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace PropertyEditor
{
    public static class PropertyElementBuildUtil
    {
        private static IPropertyElement CreateByNumberType(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    return new TBaseFieldElement<Toggle, bool>();
                case TypeCode.SByte:
                    return new TRangeIntegerElement(sbyte.MinValue, sbyte.MaxValue);
                case TypeCode.Byte:
                    return new TRangeIntegerElement(byte.MinValue, byte.MaxValue);
                case TypeCode.UInt16:
                    return new TRangeIntegerElement(ushort.MinValue, ushort.MaxValue);
                case TypeCode.Int16:
                    return new TRangeIntegerElement(short.MinValue, short.MaxValue);
                case TypeCode.UInt32:
                    return new TRangeIntegerElement(uint.MinValue, uint.MaxValue);
                case TypeCode.Int32:
                    return new TInputElement<IntegerField, int>();
                case TypeCode.Int64:
                    return new TInputElement<LongField, long>();
                case TypeCode.UInt64:
                    return new TRangeIntegerElement(0, long.MaxValue);//临时使用long最大值
                case TypeCode.Single:
                    return new TInputElement<FloatField, float>();
                case TypeCode.Double:
                    return new TInputElement<DoubleField, double>();
                    case TypeCode.String:
                    return new TextFieldElement();
            }
            return null;
        }

        public static IPropertyElement Create(Type type)
        {
            var pe = CreateByNumberType(type);
            if (pe != null)
                return pe;
            if (type == typeof(Vector2))
                return new TCompositeElement<Vector2Field, Vector2, FloatField, float>();
            else if (type == typeof(Vector2Int))
                return new TCompositeElement<Vector2IntField, Vector2Int, IntegerField, int>();
            else if (type == typeof(Vector3))
                return new TCompositeElement<Vector3Field, Vector3, FloatField, float>();
            else if (type == typeof(Vector3Int))
                return new TCompositeElement<Vector3IntField, Vector3Int, IntegerField, int>();
            else if (type == typeof(Vector4))
                return new TCompositeElement<Vector4Field, Vector4, FloatField, float>();
            else if (type == typeof(Quaternion))
                return new QuaternionElement();
            else if (type == typeof(Color))
                return new TBaseFieldElement<ColorField, Color>();
            return null;
        }

        public static IPropertyElement Create(FieldInfo fieldInfo)
        {
            return null;
        }

    }
}
