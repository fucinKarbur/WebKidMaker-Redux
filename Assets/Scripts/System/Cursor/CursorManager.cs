using System.Collections.Generic;
using UnityEngine;

namespace WKMR
{
    public class CursorManager : MonoBehaviour
    {
        public static CursorManager Instance;

        [SerializeField] private List<CursorAsset> _assets;
        [SerializeField] private Vector2 _offset;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start() => ChangeCursor(CursorType.Default);

        public void ChangeCursor(CursorType type)
        {
            var cursor = GetTexture(type);

            if (cursor != null)
            {
                Cursor.SetCursor(cursor, _offset, CursorMode.Auto);
            }
        }

        private Texture2D GetTexture(CursorType type)
        {
            foreach (var cursor in _assets)
                if (cursor.Type == type)
                    return cursor.Texture;

            return null;
        }
    }
}