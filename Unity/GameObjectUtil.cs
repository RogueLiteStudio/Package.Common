using UnityEngine;

public static class GameObjectUtil
{
    public static Transform RecursiveFindChild(this Transform root, string name, bool ignoreCase = false)
    {
        if (!root)
            return null;
        for (int i=0; i<root.childCount; ++i)
        {
            var child = root.GetChild(i);
            if (ignoreCase)
            {
                if (child.name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                    return child;
            }
            else
            {
                if (child.name == name)
                    return child;
            }
            var find = RecursiveFindChild(child, name, ignoreCase);
            if (find)
                return find;
        }
        return null;
    }

    public static Transform RecursiveFindChild(this GameObject root, string name, bool ignoreCase = false)
    {
        return RecursiveFindChild(root.transform, name, false);
    }
}
