using UnityEngine;

/* Prefab保存时的处理
 * 需要挂到场景对象上
 * 处理需要创建Editor，继承PrefabSaveActionInspector
 * 在Editor中实现OnPreSave、OnPostSave、OnPrefabContent方法
 */
public abstract class PrefabSaveAction : MonoBehaviour
{
    public abstract bool SaveToPrefab { get; }
}
