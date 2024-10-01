using UnityEngine;

namespace WKMR.System
{
    public static class PositionRandomiser
    {
        private static float _minY;
        private static float _maxY;
        private static float _minX;
        private static float _maxX;

        public static Vector3 GetRandomPosition(Canvas canvas)
        {
            var transform = canvas.GetComponent<RectTransform>(); 
            float width = transform.rect.width;
            float height = transform.rect.height;

            _minX = -width / 2;
            _maxX = width / 2;
            _minY = -height / 2;
            _maxY = height / 2;

            return new(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY), 0);
        }
    }
}