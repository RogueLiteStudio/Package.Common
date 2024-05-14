using UnityEngine;


public class PrefabSaveActionInspector : UnityEditor.Editor
{
    //保存前对场景对象的处理
    public virtual void OnPreSave(GameObject sceneObj, string prefabPath)
    {
        // This method is called before the prefab is saved
    }

    //保存后对场景对象的处理
    public virtual void OnPostSave(GameObject sceneObj, string prefabPath)
    {
    }

    //对保存后的Prefab对象的处理
    public virtual void OnPrefabContent(GameObject prefab, string prefabPath)
    {
    }
}
