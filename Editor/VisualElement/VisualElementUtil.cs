using UnityEngine;
using UnityEngine.UIElements;

public static class VisualElementUtil
{
    public static void SetBorderColor(this VisualElement element, Color color)
    {
        var style = element.style;
        style.borderLeftColor = color;
        style.borderRightColor = color;
        style.borderTopColor = color;
        style.borderBottomColor = color;
    }

    public static void SetBorderWidth(this VisualElement element, float width)
    {
        var style = element.style;
        style.borderLeftWidth = width;
        style.borderRightWidth = width;
        style.borderTopWidth = width;
        style.borderBottomWidth = width;
    }
}
