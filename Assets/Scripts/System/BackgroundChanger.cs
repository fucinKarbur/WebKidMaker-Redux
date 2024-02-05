using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WKMR.System
{
    public class BackgroundChanger : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _backgrounds;
        [SerializeField] private Image _image;

        private List<Sprite> _lastUsed = new();
        private int _halfCount;

        public void ChangeBackground() => _image.sprite = GetRandomSprite();

        private void Awake() => _halfCount = _backgrounds.Count / 2;

        private Sprite GetRandomSprite()
        {
            //var newSprite = _backgrounds.Find(sprite => !_lastUsed.Contains(sprite));
            Sprite newSprite = null;

            while(newSprite == null || _lastUsed.Contains(newSprite))
                newSprite = _backgrounds[Random.Range(0, _backgrounds.Count)];

            _lastUsed.Add(newSprite);

            if (_lastUsed.Count < _halfCount)
                return newSprite;
            else
                _lastUsed.Remove(_lastUsed[0]);

            return newSprite;
        }
    }
}