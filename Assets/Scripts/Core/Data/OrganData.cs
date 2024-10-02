using UnityEditor;
using UnityEngine;

namespace WKMR
{
    [CreateAssetMenu(fileName = "Organ", menuName = "OrganData", order = 3)]
    public class OrganData : ScriptableObject
    {

        [field: SerializeField] public OrganType Type { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public Vector3 Offset { get; private set; }
        [field: SerializeField] public bool Colorable { get; private set; }
        [field: SerializeField] public bool IsHealth { get; private set; }
    }
}