using UnityEngine;

namespace WKMR
{
    [CreateAssetMenu(fileName = "Organ", menuName = "OrganData", order = 3)]
    public class OrganData : ScriptableObject
    {
        [SerializeField] private OrganType _type;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private bool _colorable;
        [SerializeField] private bool _isHealth;

        public OrganType Type => _type;
        public Sprite Icon => _icon;
        public Vector3 Offset => _offset;
        public bool Colorable => _colorable;
        public bool IsHealth => _isHealth;
    }
}