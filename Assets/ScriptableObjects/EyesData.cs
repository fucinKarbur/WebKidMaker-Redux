using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WKMR
{
    [CreateAssetMenu(fileName = "Eyes", menuName = "EyesData", order = 2)]
    public class EyesData : ItemData
    {
        [SerializeField] private List<Sprite> _types;
        [SerializeField] private List<Color> _colors;

        public Sprite ChangeType(Color color)
        {
            if (_colors.Contains(color))
            {
                int index = _colors.IndexOf(color);

                if (index < _types.Count)
                    return _types[index];
            }

            return Icon;
        }
    }
}
