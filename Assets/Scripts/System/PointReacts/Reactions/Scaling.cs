using UnityEngine;

namespace WKMR.System.PointReacts.Reactions
{
    public class Scaling : Reaction
    {
        private readonly Transform _transform;
        private Vector3 _changeScale;
        private Vector3 _default;


        public Scaling(Vector3 scaleChange, Transform transform)
        {
            _changeScale = scaleChange;
            _transform = transform;
            _default = _transform.localScale;
        }

        public override void React() => _transform.localScale += _changeScale;

        public override void SetDefault() => _transform.localScale = _default;
    }
}