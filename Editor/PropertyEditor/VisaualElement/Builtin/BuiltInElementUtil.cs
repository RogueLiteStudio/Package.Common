using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace PropertyEditor
{
    public static class BuiltInElementUtil
    {
        public static IPropertyElement Create(Type type)
        {
            if (type == typeof(float))
                return new TInputElement<FloatField, float>();
            else if (type == typeof(double))
                return new TInputElement<DoubleField, double>();
            else if (type == typeof(int))
                return new TInputElement<IntegerField, int>();
            else if (type == typeof(long))
                return new TInputElement<LongField, long>();
            else if (type == typeof(Vector2))
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
            else if (type == typeof(bool))
                return new TBaseFieldElement<Toggle, bool>();
            return null;
        }
    }
}
