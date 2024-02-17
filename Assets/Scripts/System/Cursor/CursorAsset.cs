using System;
using UnityEngine;

namespace WKMR
{
    [Serializable]
    public class CursorAsset
    {
        [SerializeField] private CursorType _name;
        [SerializeField] private Texture2D _texture;

        public CursorType Name => _name;
        public Texture2D Texture => _texture;
    }
}