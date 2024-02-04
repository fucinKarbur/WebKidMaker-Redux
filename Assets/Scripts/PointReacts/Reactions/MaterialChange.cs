using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace WKMR.PointReacts.Reactions
{
    public class MaterialChange : Reaction
    {
        private Material _material;
        private Material _default;
        private Image _image;

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