using UnityEngine;

/* Prefab����ʱ�Ĵ���
 * ��Ҫ�ҵ�����������
 * ������Ҫ����Editor���̳�PrefabSaveActionInspector
 * ��Editor��ʵ��OnPreSave��OnPostSave��OnPrefabContent����
 */
public abstract class PrefabSaveAction : MonoBehaviour
{
    public abstract bool SaveToPrefab { get; }
}
