using System.Collections.Generic;

public class EmptyArray<T>
{
    public static readonly T[] Instance = new T[0];
}

public static class CollectionUtil
{
    public static bool IsEmpty<T>(this T[] array)
    {
        return array == null || array.Length == 0;
    }

    public static bool IsEmpty<T>(this List<T> list)
    {
        return list == null || list.Count == 0;
    }
}
