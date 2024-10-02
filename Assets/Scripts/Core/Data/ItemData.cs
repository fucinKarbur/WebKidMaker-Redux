using UnityEditor;
using UnityEngine;

namespace WKMR

{
    [CreateAssetMenu(fileName = "Item", menuName = "ItemData", order = 0)]
    public class ItemData : ScriptableObject
    {

        [field: SerializeField] public ItemType Type { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public Vector3 Offset { get; private set; }
        [field: SerializeField] public string Path { get; private set; }
        [field: SerializeField] public virtual bool Colorable { get; private set; }
    }
}