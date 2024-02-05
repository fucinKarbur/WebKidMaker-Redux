using UnityEngine;
using UnityEngine.UI;

namespace WKMR.System.PointReacts.Reactions
{
    public class MaterialChange : Reaction
    {
        private readonly Material _material;
        private readonly Material _default;
        private readonly Image _image;

        public MaterialChange(Material material, Image image)
        {
            _material = material;
            _image = image;
            _default = image.material;
        }

        public override void React() => _image.material = _material;

        public override void SetDefault() => _image.material = _default;
    }
}