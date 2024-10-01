using System;
using UnityEngine;

namespace WKMR
{
    [Serializable]
    public class CursorAsset
    {
        [field: SerializeField] public CursorType Type { get; private set; }
        [field: SerializeField] public Texture2D Texture { get; private set; }
    }
}