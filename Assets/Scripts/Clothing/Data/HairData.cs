using UnityEngine;

namespace WKMR
{
    [CreateAssetMenu(fileName = "Hair", menuName = "HairData", order = 1)]
    public class HairData : ItemData
    {
        private readonly bool _ableToColor = true;

        public override bool Colorable => _ableToColor;
    }
}