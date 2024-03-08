using UnityEngine;
using UnityEngine.UIElements;

public static class VisualElementUtil
{
    public static VisualElement SetBorderColor(this VisualElement element, Color color)
    {
        var style = element.style;
        style.borderLeftColor = color;
        style.borderRightColor = color;
        style.borderTopColor = color;
        style.borderBottomColor = color;
        return element;
    }

    public static VisualElement SetBorderWidth(this VisualElement element, float width)
    {
        var style = element.style;
        style.borderLeftWidth = width;
        style.borderRightWidth = width;
        style.borderTopWidth = width;
        style.borderBottomWidth = width;
        return element;
    }

    public static VisualElement SetTextAlign(this VisualElement element, TextAnchor anchor)
    {
        element.style.unityTextAlign = anchor;
        return element;
    }

    public static VisualElement SetTextStyle(this VisualElement element, FontStyle style)
    {
        element.style.unityFontStyleAndWeight = style;
        return element;
    }
}
