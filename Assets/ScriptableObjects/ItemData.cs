using UnityEngine;

namespace WKMR

{
    [CreateAssetMenu(fileName = "Item", menuName = "ItemData", order = 0)]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private ItemType _type;
        [SerializeField] private Sprite _icon;
        [SerializeField] private bool _colorable;
        [SerializeField] private Vector3 _offset;

        public ItemType Type => _type;
        public Sprite Icon => _icon;
        public Vector3 Offset => _offset;

        public virtual bool Colorable => _colorable;
    }
}